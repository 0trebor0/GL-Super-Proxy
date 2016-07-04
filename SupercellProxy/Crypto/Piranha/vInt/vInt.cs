using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClashRoyaleProxy
{
    /// <summary>
    /// All methods reversed by Lasertrap00
    /// </summary>
    static class vInt
    {
        public static int ReadVInt(this BinaryReader br)
        {
            int v5;
            var b = br.ReadByte();
            v5 = b & 0x80;
            var _LR = b & 0x3F;

            if ((b & 0x40) != 0)
            {
                if (v5 != 0)
                {
                    b = br.ReadByte();
                    v5 = (b << 6) & 0x1FC0 | _LR;
                    if ((b & 0x80) != 0)
                    {
                        b = br.ReadByte();
                        v5 = v5 | (b << 13) & 0xFE000;
                        if ((b & 0x80) != 0)
                        {
                            b = br.ReadByte();
                            v5 = v5 | (b << 20) & 0x7F00000;
                            if ((b & 0x80) != 0)
                            {
                                b = br.ReadByte();
                                _LR = (int) (v5 | (b << 27) | 0x80000000);
                            }
                            else
                            {
                                _LR = (int) (v5 | 0xF8000000);
                            }
                        }
                        else
                        {
                            _LR = (int) (v5 | 0xFFF00000);
                        }
                    }
                    else
                    {
                        _LR = (int) (v5 | 0xFFFFE000);
                    }
                }
            }
            else
            {
                if (v5 != 0)
                {
                    b = br.ReadByte();
                    _LR |= (b << 6) & 0x1FC0;
                    if ((b & 0x80) != 0)
                    {
                        b = br.ReadByte();
                        _LR |= (b << 13) & 0xFE000;
                        if ((b & 0x80) != 0)
                        {
                            b = br.ReadByte();
                            _LR |= (b << 20) & 0x7F00000;
                            if ((b & 0x80) != 0)
                            {
                                b = br.ReadByte();
                                _LR |= b << 27;
                            }
                        }
                    }
                }
            }
            return _LR;
        }

        public static void AddVInt(this List<byte> data, int v2)
        {
            var stream = new MemoryStream(5);

            if (v2 <= -1)
            {
                if (!((v2 + 63 < 0) ^ true))
                {
                    stream.WriteByte((byte) (v2 & 0x3F | 0x40));
                    data.AddRange(stream.ToArray());
                    return;
                }
                if (v2 >= -8191)
                {
                    stream.WriteByte((byte) (v2 | 0xC0));
                    v2 >>= 6 & 0x7F;
                    stream.WriteByte((byte) v2);
                    data.AddRange(stream.ToArray());
                    return;
                }
                if (v2 >= -1048575)
                {
                    stream.WriteByte((byte) (v2 | 0xC0));
                    stream.WriteByte((byte) (v2 >> 6 | 0x80));
                    v2 >>= 13 & 0x7F;
                    stream.WriteByte((byte) v2);
                    data.AddRange(stream.ToArray());
                    return;
                }
                stream.WriteByte((byte) (v2 | 0xC0));
                stream.WriteByte((byte) (v2 >> 6 | 0x80));
                stream.WriteByte((byte) (v2 >> 13 | 0x80));
                v2 >>= 20;
                if (v2 <= -134217728)
                {
                    stream.WriteByte((byte) (v2 | 0x80));
                    v2 >>= 27 & 0xF;
                    stream.WriteByte((byte) v2);
                    data.AddRange(stream.ToArray());
                    return;
                }
                stream.WriteByte((byte) (v2 & 0x7F));
                data.AddRange(stream.ToArray());
                return;
            }
            if (v2 > 63)
            {
                if (v2 < 0x2000)
                {
                    stream.WriteByte((byte) (v2 & 0x3F | 0x80));

                    v2 >>= 6 & 0x7F;
                    stream.WriteByte((byte) v2);
                    data.AddRange(stream.ToArray());
                    return;
                }
                if (v2 < 0x100000)
                {
                    stream.WriteByte((byte) (v2 & 0x3F | 0x80));

                    stream.WriteByte((byte) (v2 >> 6 | 0x80));
                    v2 >>= 13 & 0x7F;
                    stream.WriteByte((byte) v2);
                    data.AddRange(stream.ToArray());
                    return;
                }
                stream.WriteByte((byte) (v2 & 0x3F | 0x80));
                stream.WriteByte((byte) (v2 >> 6 | 0x80));
                stream.WriteByte((byte) (v2 >> 13 | 0x80));
                v2 >>= 20;

                if (v2 >= 0x8000000)
                {
                    stream.WriteByte((byte) (v2 | 0x80));
                    v2 >>= 27 & 0xF;
                    stream.WriteByte((byte) v2);
                    data.AddRange(stream.ToArray());
                    return;
                }

                stream.WriteByte((byte) (v2 & 0x7F));
                data.AddRange(stream.ToArray());
                return;
            }

            v2 = v2 & 0x3F;
            stream.WriteByte((byte) v2);
            data.AddRange(stream.ToArray());
        }

        public static void AddVInt(this List<byte> data, long l)
        {
            var stream = new MemoryStream(6);
            byte temp = 0;
            temp = (byte) ((l >> 57) & 0x40L);
            l = l ^ (l >> 63);
            temp |= (byte) (l & 0x3FL);
            l >>= 6;
            if (l != 0)
            {
                temp |= 0x80;
                stream.WriteByte(temp);
                while (true)
                {
                    temp = (byte) (l & (0x7FL));
                    l >>= 7;
                    temp |= (byte) ((l != 0 ? 1 : 0) << 7);
                    stream.WriteByte(temp);
                    if (l == 0)
                        break;
                }
            }
            else
            {
                stream.WriteByte(temp);
            }

            data.Add(0x00); // mmh ?
            data.AddRange(stream.ToArray());
        }

        public static long ReadVInt64(this BinaryReader br)
        {
            var temp = br.ReadByte();
            long i = 0;
            int Sign = (temp >> 6) & 1;
            i = temp & 0x3FL;

            do
            {
                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7 + 7);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7 + 7 + 7);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7 + 7 + 7 + 7);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7 + 7 + 7 + 7 + 7);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7 + 7 + 7 + 7 + 7 + 7);

                if ((temp & 0x80) == 0)
                    break;
                temp = br.ReadByte();
                i |= (temp & (0x7FL)) << (6 + 7 + 7 + 7 + 7 + 7 + 7 + 7);
            }
            while (false);


            br.ReadByte(); //that 0x00 byte
            i ^= -Sign;
            return i;
        }
    }
}