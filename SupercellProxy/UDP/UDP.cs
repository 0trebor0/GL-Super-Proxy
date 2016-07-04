using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SupercellProxy
{
    internal class UDP
    {
        public static IPEndPoint MListenEp;
        public static EndPoint MConnectedClientEp;
        public static IPEndPoint MSendEp;
        public static Socket MUdpListenSocket;
        public static Socket MUdpSendSocket;

        public UDP(string IP, int port)
        {
            new Thread(() =>
            {
                // Creates Listener UDP Server
                MListenEp = new IPEndPoint(IPAddress.Any, 9339);
                MUdpListenSocket = new Socket(MListenEp.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                MUdpListenSocket.Bind(MListenEp);
                Console.WriteLine("[GUP]    Proxy started on " + MListenEp);

                //Connect to zone IP EndPoint
                MSendEp = new IPEndPoint(IPAddress.Parse(IP), port);
                MConnectedClientEp = new IPEndPoint(IPAddress.Any, 0);

                byte[] data = new byte[2048];

                while (true)
                {
                    if (MUdpListenSocket.Available > 0)
                    {
                        int size = MUdpListenSocket.ReceiveFrom(data, ref MConnectedClientEp);
                        Console.WriteLine("[GUP]    New UDP Request from Client :");
                        Console.WriteLine("[GUP]            Length  -> " + size);
                        Console.WriteLine("[GUP]            IP      -> " + ((IPEndPoint) MConnectedClientEp).Address);
                        Console.WriteLine("[GUP]            Port    -> " + ((IPEndPoint) MConnectedClientEp).Port);

                        if (MUdpSendSocket == null)
                        {
                            MUdpSendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        }
                        MUdpSendSocket.SendTo(data, size, SocketFlags.None, MSendEp);
                    }

                    if (MUdpSendSocket != null && MUdpSendSocket.Available > 0)
                    {
                        int size = MUdpSendSocket.Receive(data);
                        Console.WriteLine("[GUP]    New UDP Request from Supercell :");
                        Console.WriteLine("[GUP]            Length  -> " + size);
                        Console.WriteLine("[GUP]            IP      -> " + ((IPEndPoint) MConnectedClientEp).Address);
                        Console.WriteLine("[GUP]            Port    -> " + ((IPEndPoint) MConnectedClientEp).Port);

                        MUdpListenSocket.SendTo(data, size, SocketFlags.None, MConnectedClientEp);
                    }
                }
            }).Start();
        }
    }
}