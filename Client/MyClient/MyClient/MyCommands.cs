using System;
using System.Drawing;
using System.Linq;
using System.Text;
namespace CSCS1
{
    public class Commands
    {
        //************ClearDisplay************
        public byte[] ClearDisplayEncode(byte command, string hexcolor)
        {
            byte[] commandbyte = { command };
            Int16 color = Convert.ToInt16(hexcolor, 16);
            return commandbyte.Concat(BitConverter.GetBytes(color)).ToArray();
        }
        public void ClearDisplayDecode(byte[] result, out byte command, out string
        hexcolor)
        {
            command = result[0];
            hexcolor = ByteToHexColor(result, 1);
        }
        //************Pixel************
        public byte[] PixelEncode(byte command, Int16 x0, Int16 y0, string
        hexcolor)
        {
            byte[] commandbyte = { command };
            Int16 color = Convert.ToInt16(hexcolor, 16);
            return
            commandbyte.Concat(BitConverter.GetBytes(x0)).Concat(BitConverter.GetBytes(y0)).Concat(BitConverter.GetBytes(color)).ToArray();
        }
        public void PixelDecode(byte[] result, out byte command, out Int16 x0, out
        Int16 y0, out string hexcolor)
        {
            command = result[0];
            x0 = BitConverter.ToInt16(result, 1);
            y0 = BitConverter.ToInt16(result, 3);
            hexcolor = ByteToHexColor(result, 5);
        }
        //************FourNumbers************
        public byte[] FourNumbersEncode(byte command, Int16 x0, Int16 y0, Int16
        x1, Int16 y1, string hexcolor)
        {
            byte[] commandbyte = { command };
            Int16 color = Convert.ToInt16(hexcolor, 16);
            return
            commandbyte.Concat(BitConverter.GetBytes(x0)).Concat(BitConverter.GetBytes(y0)).Concat(BitConverter.GetBytes(x1)).Concat(BitConverter.GetBytes(y1)).Concat(BitConverter.GetBytes(color)).ToArray();
        }
        public void FourNumbersDecode(byte[] result, out byte command, out Int16
        x0, out Int16 y0, out Int16 x1, out Int16 y1, out string hexcolor)
        {
            command = result[0];
            x0 = BitConverter.ToInt16(result, 1);
            y0 = BitConverter.ToInt16(result, 3);
            x1 = BitConverter.ToInt16(result, 5);
            y1 = BitConverter.ToInt16(result, 7);
            hexcolor = ByteToHexColor(result, 9);
        }
        //************Circle************
        public byte[] CircleEncode(byte command, Int16 x0, Int16 y0, Int16 radius,
        string hexcolor)
        {
            byte[] commandbyte = { command };
            Int16 color = Convert.ToInt16(hexcolor, 16);
            return
            commandbyte.Concat(BitConverter.GetBytes(x0)).Concat(BitConverter.GetBytes(y0)).Concat(BitConverter.GetBytes(radius)).Concat(BitConverter.GetBytes(color)).ToArray()
        ;
        }
        public void CircleDecode(byte[] result, out byte command, out Int16 x0,
        out Int16 y0, out Int16 radius, out string hexcolor)
        {
            command = result[0];
            x0 = BitConverter.ToInt16(result, 1);
            y0 = BitConverter.ToInt16(result, 3);
            radius = BitConverter.ToInt16(result, 5);
            hexcolor = ByteToHexColor(result, 7);
        }
        //************RoundedRect************
        public byte[] RoundedRectEncode(byte command, Int16 x0, Int16 y0, Int16
        x1, Int16 y1, Int16 radius, string hexcolor)
        {
            byte[] commandbyte = { command };
            Int16 color = Convert.ToInt16(hexcolor, 16);
            return
            commandbyte.Concat(BitConverter.GetBytes(x0)).Concat(BitConverter.GetBytes(y0)).Concat(BitConverter.GetBytes(x1)).Concat(BitConverter.GetBytes(y1)).Concat(BitConverter.GetBytes(radius)).Concat(BitConverter.GetBytes(color)).ToArray();
        }
        public void RoundedRectDecode(byte[] result, out byte command, out Int16
       x0, out Int16 y0, out Int16 x1, out Int16 y1, out Int16 radius, out string
       hexcolor)
        {
            command = result[0];
            x0 = BitConverter.ToInt16(result, 1);
            y0 = BitConverter.ToInt16(result, 3);
            x1 = BitConverter.ToInt16(result, 5);
            y1 = BitConverter.ToInt16(result, 7);
            radius = BitConverter.ToInt16(result, 9);
            hexcolor = ByteToHexColor(result, 11);
        }
        //************Text************
        public byte[] TextEncode(byte command, Int16 x0, Int16 y0, string
        hexcolor, Int16 x1, Int16 y1, string text)
        {
            byte[] commandbyte = { command };
            Int16 color = Convert.ToInt16(hexcolor, 16);
            return
            commandbyte.Concat(BitConverter.GetBytes(x0)).Concat(BitConverter.GetBytes(y0)).Concat(BitConverter.GetBytes(color)).Concat(BitConverter.GetBytes(x1)).Concat(BitConverter.GetBytes(y1)).Concat(Encoding.Unicode.GetBytes(text)).ToArray();
        }
        public void TextDecode(byte[] result, out byte command, out Int16 x0, out
        Int16 y0, out string hexcolor, out Int16 x1, out Int16 y1, out string text)
        {
            command = result[0];
            x0 = BitConverter.ToInt16(result, 1);
            y0 = BitConverter.ToInt16(result, 3);
            hexcolor = ByteToHexColor(result, 5);
            x1 = BitConverter.ToInt16(result, 7);
            y1 = BitConverter.ToInt16(result, 9);
            text = Encoding.Unicode.GetString(result.Skip(11).Take(y1 *
            2).ToArray());
        }
        //************Image************
        public byte[] ImageEncode(byte command, Int16 x0, Int16 y0, Int16 x1,
        Int16 y1, string data)
        {
            byte[] commandbyte = { command };
            Color[] colors = ColorsEncode(new Bitmap(data, true), x1, y1);
            byte[] byteColors = ColorsToByte(colors);
            return
            commandbyte.Concat(BitConverter.GetBytes(x0)).Concat(BitConverter.GetBytes(y0)).Concat(BitConverter.GetBytes(x1)).Concat(BitConverter.GetBytes(y1)).Concat(byteColors).ToArray();
        }
        public void ImageDecode(byte[] result, out byte command, out Int16 x0, out
        Int16 y0, out Int16 x1, out Int16 y1, out Color[,] colors)
        {
            command = result[0];
            x0 = BitConverter.ToInt16(result, 1);
            y0 = BitConverter.ToInt16(result, 3);
            x1 = BitConverter.ToInt16(result, 5);
            y1 = BitConverter.ToInt16(result, 7);
            colors = ByteToColors(result.Skip(9).Take(x1 * y1 * 4).ToArray(), x1,
            y1);
        }
        //***********************SECONDARY FUNCTIONS***********************
        public static string ByteToHexColor(byte[] value, int startIndex)
        {
            Int16 color = BitConverter.ToInt16(value, startIndex);
            return color.ToString("X");
        }
        public static Color[] ColorsEncode(Bitmap source, Int16 w, Int16 h)
        {
            Bitmap bmp = new Bitmap(source, w, h); Color[] result = new Color[w * h];
            int counter = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    result[counter] = bmp.GetPixel(j, i);
                    counter++;
                }
            }
            return result;
        }
        public static byte[] ColorsToByte(Color[] colors)
        {
            int length = colors.Length;
            byte[] result = new byte[0];
            byte[] Combine(byte[] first, byte[] second)
            {
                byte[] ret = new byte[first.Length + second.Length];
                Buffer.BlockCopy(first, 0, ret, 0, first.Length);
                Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
                return ret;
            }
            for (int i = 0; i < length; i++)
            {
                result = Combine(result,
                BitConverter.GetBytes(colors[i].ToArgb()));
            }
            return result;
        }
        public static Color[,] ByteToColors(byte[] byteColors, Int16 w, Int16 h)
        {
            Color[,] result = new Color[w, h];
            int counter = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    result[j, i] = Color.FromArgb(BitConverter.ToInt32(byteColors,
                    4 * counter));
                    counter++;
                }
            }
            return result;
        }
    }
}
