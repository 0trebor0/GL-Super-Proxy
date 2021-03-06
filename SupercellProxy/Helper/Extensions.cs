﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SupercellProxy
{
    static class Extensions
    {
        /// <summary>
        /// Uses LINQ to convert a hexlified string to a byte array
        /// </summary>
        public static byte[] ToByteArray(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Converts a byte array to a hexlified string
        /// </summary>
        public static string ToHexString(this byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Increments a nonce
        /// </summary>
        /// <param name="nonce">Nonce to increment</param>
        public static void Increment(this byte[] nonce, int timesToIncrease = 2)
        {
            /*
            int __cdecl sodium_increment(unsigned char nonce, unsigned int nonceLength)
            {
                __int64 v2 = 1i64; // rax@1
                do
                {
                     LODWORD(v2) = *(_BYTE *)(HIDWORD(v2) + a1) + (_DWORD)v2;
                     *(_BYTE *)(HIDWORD(v2)++ + a1) = v2;
                     LODWORD(v2) = (unsigned int)v2 >> 8;
                }
                while ( HIDWORD(v2) < a2 );
             return v2;
            }
            */
            for (int j = 0; j < timesToIncrease; j++)
            {
                ushort c = 1;
                for (UInt32 i = 0; i < nonce.Length; i++)
                {
                    c += (ushort)nonce[i];
                    nonce[i] = (byte)c;
                    c >>= 8;
                }
            }
        }

        /// <summary>
        /// Returns if a socket disconnected
        /// </summary>
        public static bool Disconnected(this Socket socket)
        {
            try
            {
                return (socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException)
            {
                return true;
            }
        }

        // Add datatypes to a generic list of bytes
        public static void AddShort(this List<byte> list, short data)
        {
            list.AddRange(BitConverter.GetBytes(data).Reverse());
        }

        public static void AddInt(this List<byte> list, int data)
        {
            list.AddRange(BitConverter.GetBytes(data).Reverse());
        }

        public static void AddLong(this List<byte> list, long data)
        {
            list.AddRange(BitConverter.GetBytes(data).Reverse());
        }

        public static void AddString(this List<byte> list, string data)
        {
            if (string.IsNullOrEmpty(data))
                list.AddRange(BitConverter.GetBytes(-1).Reverse());
            else
            {
                list.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(data)).Reverse());
                list.AddRange(Encoding.UTF8.GetBytes(data));
            }
        }

        // Read datatypes from a byte array
        public static short ReadShortWithEndian(this BinaryReader br)
        {
            var a16 = br.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a16);
            return BitConverter.ToInt16(a16, 0);
        }
        public static int ReadIntWithEndian(this BinaryReader br)
        {
            var a32 = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a32);
            return BitConverter.ToInt32(a32, 0);
        }

        public static long ReadLongWithEndian(this BinaryReader br)
        {
            var a64 = br.ReadBytes(8);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a64);
            return BitConverter.ToInt64(a64, 0);
        }

        public static string ReadString(this BinaryReader br)
        {
            int lengthOfUTF8Str = br.ReadInt32();
            string UTF8Str;

            if (lengthOfUTF8Str > -1)
            {
                if (lengthOfUTF8Str > 0)
                {
                    var tmp = br.ReadBytes(lengthOfUTF8Str);
                    UTF8Str = Encoding.UTF8.GetString(tmp);
                }
                else
                {
                    UTF8Str = string.Empty;
                }
            }
            else
                UTF8Str = null;
            return UTF8Str;
        }

        public static int ReadMedium(this BinaryReader br)
        {
            var tmp = br.ReadBytes(3);
            return (0x00 << 24) | (tmp[0] << 16) | (tmp[1] << 8) | tmp[2];
        }

        public static ushort ReadUShortWithEndian(this BinaryReader br)
        {
            var a16 = br.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a16);
            return BitConverter.ToUInt16(a16, 0);
        }

        public static uint ReadUIntWithEndian(this BinaryReader br)
        {
            var a32 = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a32);
            return BitConverter.ToUInt32(a32, 0);
        }

        public static ulong ReadULongWithEndian(this BinaryReader br)
        {
            var a64 = br.ReadBytes(8);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a64);
            return BitConverter.ToUInt64(a64, 0);
        }
    }
}
