using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace eMZi.Gaming.Minecraft
{
    /// <summary>
    /// Represents retrieved Minecraft Server information
    /// </summary>
    public sealed class MinecraftServerInfo
    {
        /// <summary>
        /// Gets the server's MOTD
        /// </summary>
        public string ServerMotd { get; private set; }

        /// <summary>
        /// Gets the server's MOTD converted into HTML
        /// </summary>
        public string ServerMotdHtml { get { return this.MotdHtml(); } }

        /// <summary>
        /// Gets the server's max player count
        /// </summary>
        public int MaxPlayerCount { get; private set; }

        /// <summary>
        /// Gets the server's current player count
        /// </summary>
        public int CurrentPlayerCount { get; private set; }

        /// <summary>
        /// Gets the server's Minecraft version
        /// </summary>
        public Version MinecraftVersion { get; private set; }

        /// <summary>
        /// Gets HTML colors associated with specific formatting codes
        /// </summary>
        private static Dictionary<char, string> MinecraftColors { get { return new Dictionary<char, string>() { { '0', "#000000" }, { '1', "#0000AA" }, { '2', "#00AA00" }, { '3', "#00AAAA" }, { '4', "#AA0000" }, { '5', "#AA00AA" }, { '6', "#FFAA00" }, { '7', "#AAAAAA" }, { '8', "#555555" }, { '9', "#5555FF" }, { 'a', "#55FF55" }, { 'b', "#55FFFF" }, { 'c', "#FF5555" }, { 'd', "#FF55FF" }, { 'e', "#FFFF55" }, { 'f', "#FFFFFF" } }; } }

        /// <summary>
        /// Gets HTML styles associated with specific formatting codes
        /// </summary>
        private static Dictionary<char, string> MinecraftStyles { get { return new Dictionary<char, string>() { { 'k', "none;font-weight:normal;font-style:normal" }, { 'm', "line-through;font-weight:normal;font-style:normal" }, { 'l', "none;font-weight:900;font-style:normal" }, { 'n', "underline;font-weight:normal;font-style:normal;" }, { 'o', "none;font-weight:normal;font-style:italic;" }, { 'r', "none;font-weight:normal;font-style:normal;color:#FFFFFF;" } }; } }

        /// <summary>
        /// Creates a new instance of <see cref="MinecraftServerInfo"/> with specified values
        /// </summary>
        /// <param name="motd">Server's MOTD</param>
        /// <param name="maxplayers">Server's max player count</param>
        /// <param name="playercount">Server's current player count</param>
        /// <param name="version">Server's Minecraft version</param>
        private MinecraftServerInfo(string motd, int maxplayers, int playercount, Version mcversion)
        {
            this.ServerMotd = motd;
            this.MaxPlayerCount = maxplayers;
            this.CurrentPlayerCount = playercount;
            this.MinecraftVersion = mcversion;
        }

        /// <summary>
        /// Gets the server's MOTD formatted as HTML
        /// </summary>
        /// <returns>HTML-formatted MOTD</returns>
        private string MotdHtml()
        {
            Regex regex = new Regex("§([k-oK-O])(.*?)(§[0-9a-fA-Fk-oK-OrR]|$)");
            string s = this.ServerMotd;
            while (regex.IsMatch(s))
                s = regex.Replace(s, m =>
                {
                    string ast = "text-decoration:" + MinecraftStyles[m.Groups[1].Value[0]];
                    string html = "<span style=\"" + ast + "\">" + m.Groups[2].Value + "</span>" + m.Groups[3].Value;
                    return html;
                });
            regex = new Regex("§([0-9a-fA-F])(.*?)(§[0-9a-fA-FrR]|$)");
            while (regex.IsMatch(s))
                s = regex.Replace(s, m =>
                {
                    string ast = "color:" + MinecraftColors[m.Groups[1].Value[0]];
                    string html = "<span style=\"" + ast + "\">" + m.Groups[2].Value + "</span>" + m.Groups[3].Value;
                    return html;
                });
            return s;
        }

        /// <summary>
        /// Gets the information from specified server
        /// </summary>
        /// <param name="endpoint">IP and Port of the server to get information from</param>
        /// <returns>A <see cref="MinecraftServerInformation"/> instance with retrieved data</returns>
        /// <exception cref="System.Exception">Upon failure, throws exception with descriptive information and InnerException with details</exception>
        public static MinecraftServerInfo GetServerInformation(IPEndPoint endpoint)
        {
            if (endpoint == null)
                throw new ArgumentNullException("endpoint");
            try
            {
                string[] packetdat = null;
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(endpoint);
                    using (NetworkStream ns = client.GetStream())
                    {
                        ns.Write(new byte[] { 0xFE, 0x01 }, 0, 2);
                        byte[] buff = new byte[2048];
                        int br = ns.Read(buff, 0, buff.Length);
                        if (buff[0] != 0xFF)
                            throw new InvalidDataException("Received invalid packet");
                        string packet = Encoding.BigEndianUnicode.GetString(buff, 3, br - 3);
                        if (!packet.StartsWith("§"))
                            throw new InvalidDataException("Received invalid data");
                        packetdat = packet.Split('\u0000');
                        ns.Close();
                    }
                    client.Close();
                }
                return new MinecraftServerInfo(packetdat[3], int.Parse(packetdat[5]), int.Parse(packetdat[4]), Version.Parse(packetdat[2]));
            }
            catch (SocketException ex)
            {
                throw new Exception("There was a connection problem, look into InnerException for details", ex);
            }
            catch (InvalidDataException ex)
            {
                throw new Exception("The data received was invalid, look into InnerException for details", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem, look into InnerException for details", ex);
            }
        }

        /// <summary>
        /// Gets the information from specified server
        /// </summary>
        /// <param name="ip">IP of the server to get info from</param>
        /// <param name="port">Port of the server to get info from</param>
        /// <returns>A <see cref="MinecraftServerInformation"/> instance with retrieved data</returns>
        /// <exception cref="System.Exception">Upon failure, throws exception with descriptive information and InnerException with details</exception>
        public static MinecraftServerInfo GetServerInformation(IPAddress ip, int port)
        {
            return GetServerInformation(new IPEndPoint(ip, port));
        }
    }
}