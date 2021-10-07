using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Tecser.Business.Network
{
    public static class IpAddress
    {
        public static string GetIpV4Address(string computerName)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(computerName);
            IPAddress ipAddress = ipHostInfo.AddressList
                .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            if (ipAddress != null)
                return ipAddress.ToString();
            return "0.0.0.0";
        }

        public static PingReply GetPingStatus(string ipAddressV4)
        {
            var ip = IPAddress.Parse(ipAddressV4);
            var ping = new Ping();
            PingReply pr = ping.Send(ip);

            Console.WriteLine("Respuesta desde (0): bytes:(1) tiempo=(2) ((3))",
                pr.Address, pr.Buffer.Length, pr.RoundtripTime,
                pr.Status.ToString());

            return pr;
        }
















    }
}
