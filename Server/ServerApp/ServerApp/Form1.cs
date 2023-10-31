using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Drawing2D;


namespace CSCS2_Forms
{
    public partial class Form1 : Form
    {
        static Int16 rotation = 0;
        static Int16 penWidth = 2;
        static List<Lines> lines = new List<Lines>();
        static List<Pixels> pixels = new List<Pixels>();
        static List<Rectangles> rectangles = new List<Rectangles>();
        static List<Ellipses> ellipses = new List<Ellipses>();
        static List<RoundedRectangle> roundedRectangles = new
        List<RoundedRectangle>();
        static List<Texts> texts = new List<Texts>();
        static List<Pictures> pictures = new List<Pictures>(); public Form1()
        {
            InitializeComponent();
            try
            {
                new Thread(new ThreadStart(ReceiveMessage)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //***********************CLASSES***********************
        public class Pixels
        {
            public Int16 x0;
            public Int16 y0;
            public Color argb;
            public Pixels(Int16 _x0, Int16 _y0, Color _argb)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.argb = _argb;
            }
        }
        public class Lines
        {
            public Int16 x0;
            public Int16 y0;
            public Int16 x1;
            public Int16 y1;
            public Color argb;
            public Lines(Int16 _x0, Int16 _y0, Int16 _x1, Int16 _y1, Color _argb)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.x1 = _x1;
                this.y1 = _y1;
                this.argb = _argb;
            }
        }
        public class Rectangles
        {
            public Int16 x0;
            public Int16 y0;
            public Int16 w;
            public Int16 h;
            public Color argb;
            public bool isfilled;
            public Rectangles(Int16 _x0, Int16 _y0, Int16 _w, Int16 _h, Color
            _argb, bool _isfilled)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.w = _w;
                this.h = _h;
                this.argb = _argb;
                this.isfilled = _isfilled;
            }
        }
        public class Ellipses
        {
            public Int16 x0;
            public Int16 y0;
            public Int16 radius_x; public Int16 radius_y;
            public Color argb;
            public bool isfilled;
            public Ellipses(Int16 _x0, Int16 _y0, Int16 _radius_x, Int16
            _radius_y, Color _argb, bool _isfilled)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.radius_x = _radius_x;
                this.radius_y = _radius_y;
                this.argb = _argb;
                this.isfilled = _isfilled;
            }
        }
        public class RoundedRectangle
        {
            public Int16 x0;
            public Int16 y0;
            public Int16 w;
            public Int16 h;
            public Int16 radius;
            public Color argb;
            public bool isfilled;
            public RoundedRectangle(Int16 _x0, Int16 _y0, Int16 _w, Int16 _h,
            Int16 _radius, Color _argb, bool _isfilled)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.w = _w;
                this.h = _h;
                this.radius = _radius;
                this.argb = _argb;
                this.isfilled = _isfilled;
            }
        }
        public class Texts
        {
            public Int16 x0;
            public Int16 y0;
            public Color argb;
            public Int16 fontSize;
            public string text;
            public Texts(Int16 _x0, Int16 _y0, Color _argb, Int16 _fontSize,
            string _text)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.argb = _argb;
                this.fontSize = _fontSize;
                this.text = _text;
            }
        }
        /*public class TextLines : Texts
        {
            public List<int[,]> symbols = new List<int[,]>();
            public TextLines(Int16 _x0, Int16 _y0, Color _argb, Int16 _fontSize,
            string _text)
            : base(_x0, _y0, _argb, _fontSize, _text)
            {
                Chars s = new Chars();
                short x = x0;
                foreach (var symbol in text)
                {
                    symbols.Add(s.GetCharCoords(symbol, x, y0, fontSize));
                    x = Convert.ToInt16(x + fontSize * 0.8);
                }
            }
        }*/
        public class Pictures
        {
            public Int16 x0;
            public Int16 y0;
            public Int16 w;
            public Int16 h;
            public Color[,] argb;
            public Pictures(Int16 _x0, Int16 _y0, Int16 _w, Int16 _h, Color[,]
            _argb)
            {
                this.x0 = _x0;
                this.y0 = _y0;
                this.w = _w;
                this.h = _h;
                this.argb = _argb;
            }
        }
        //***********************RENDERING***********************
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            graphics.RotateTransform(rotation);
            graphics.TranslateTransform(-this.Width / 2, -this.Height / 2);
            foreach (var pixel in pixels.ToArray())
            {
                graphics.FillRectangle(new SolidBrush(pixel.argb), pixel.x0 +
                this.Width / 2, pixel.y0 + this.Height / 2, 1, 1);
            }
            foreach (var line in lines.ToList())
            {
                graphics.DrawLine(new Pen(line.argb, penWidth), line.x0 +
                this.Width / 2, line.y0 + this.Height / 2, line.x1 + this.Width / 2, line.y1 +
                this.Height / 2);
            }
            foreach (var rectangle in rectangles.ToList())
            {
                if (rectangle.isfilled)
                {
                    graphics.FillRectangle(new SolidBrush(rectangle.argb),
                    rectangle.x0 + this.Width / 2 - rectangle.w / 2, rectangle.y0 + this.Height / 2 -
                    rectangle.h / 2, rectangle.w, rectangle.h);
                }
                else
                {
                    graphics.DrawRectangle(new Pen(rectangle.argb, penWidth),
                    rectangle.x0 + this.Width / 2 - rectangle.w / 2, rectangle.y0 + this.Height / 2 -
                    rectangle.h / 2, rectangle.w, rectangle.h);
                }
            }
            foreach (var ellipse in ellipses.ToList())
            {
                if (ellipse.isfilled)
                {
                    graphics.FillEllipse(new SolidBrush(ellipse.argb), ellipse.x0
                    + this.Width / 2 - ellipse.radius_x / 2, ellipse.y0 + this.Height / 2 -
                    ellipse.radius_y / 2, ellipse.radius_x, ellipse.radius_y);
                }
                else
                {
                    graphics.DrawEllipse(new Pen(ellipse.argb, penWidth),
                    ellipse.x0 + this.Width / 2 - ellipse.radius_x / 2, ellipse.y0 + this.Height / 2 -
                    ellipse.radius_y / 2, ellipse.radius_x, ellipse.radius_y);
                }
            }
            foreach (var roundedRectangle in roundedRectangles.ToList())
            {
                if (roundedRectangle.isfilled)
                {
                    graphics.FillPath(new SolidBrush(roundedRectangle.argb),
                    RoundedRect(new Rectangle(roundedRectangle.x0 + this.Width / 2 -
                    roundedRectangle.w / 2, roundedRectangle.y0 + this.Height / 2 - roundedRectangle.h
                    / 2, roundedRectangle.w, roundedRectangle.h), roundedRectangle.radius));
                }
                else
                {
                    graphics.DrawPath(new Pen(roundedRectangle.argb, penWidth),
                    RoundedRect(new Rectangle(roundedRectangle.x0 + this.Width / 2 -
                    roundedRectangle.w / 2, roundedRectangle.y0 + this.Height / 2 - roundedRectangle.h
                    / 2, roundedRectangle.w, roundedRectangle.h), roundedRectangle.radius));
                }
            }
            foreach (var text in texts.ToList())
            {
                graphics.DrawString(text.text, new Font("Arial", text.fontSize),
                new SolidBrush(text.argb), text.x0 + this.Width / 2, text.y0 + this.Height / 2,
                new StringFormat());
            }
            foreach (var picture in pictures.ToList())
            {
                graphics.SmoothingMode = SmoothingMode.Default;
                Int16 x = picture.x0;
                Int16 y = picture.y0;
                for (int i = 0; i < picture.h; i++)
                {
                    x = picture.x0;
                    for (int j = 0; j < picture.w; j++)
                    {
                        graphics.FillRectangle(new SolidBrush(picture.argb[j, i]),
                        x + this.Width / 2, y + this.Height / 2, 3, 3);
                        x += 3;
                    }
                    y += 3;
                }
            }
        }
        //***********************RECEIVE MESSAGE***********************
        private void ReceiveMessage()
        {
            int port = 8080;
            CSCS1.Commands commands = new CSCS1.Commands();
            UdpClient receiver = new UdpClient(port);
            IPEndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint iPEndPoint;
            byte commandNum;
            byte command;
            Int16 x0, y0;
            Int16 x1, y1;
            Int16 radius;
            string text;
            string hexcolor;
            Color argb;
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    commandNum = data[0];
                    switch (commandNum)
                    {
                        case 1:
                            commands.ClearDisplayDecode(data, out command, out
                            hexcolor);
                            Console.WriteLine($"Recieved command: clear display; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            DeleteAllGraphics();
                            this.BackColor = argb;
                            Invalidate();
                            break;
                        case 2:
                            commands.PixelDecode(data, out command, out x0, out
                            y0, out hexcolor);
                            Console.WriteLine($"Recieved command: draw pixel; x: { x0}; y: { y0}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            pixels.Add(new Pixels(x0, y0, argb));
                            Invalidate();
                            break;
                        case 3:
                            commands.FourNumbersDecode(data, out command, out x0,
                            out y0, out x1, out y1, out hexcolor);
                            Console.WriteLine($"Recieved command: draw line; x0: { x0}; y0: { y0}; x1: { x1}; y1: { y1}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            lines.Add(new Lines(x0, y0, x1, y1, argb));
                            Invalidate();
                            break;
                        case 4:
                            commands.FourNumbersDecode(data, out command, out x0,
                            out y0, out x1, out y1, out hexcolor);
                            Console.WriteLine($"Recieved command: draw rectangle; x: { x0}; y: { y0}; width: { x1}; height: { y1}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            rectangles.Add(new Rectangles(x0, y0, x1, y1, argb,
                            false));
                            Invalidate();
                            break;
                        case 5:
                            commands.FourNumbersDecode(data, out command, out x0,
                            out y0, out x1, out y1, out hexcolor);
                            Console.WriteLine($"Recieved command: fill rectangle; x: { x0}; y: { y0}; width: { x1}; height: { y1}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            rectangles.Add(new Rectangles(x0, y0, x1, y1, argb,
                            true));
                            Invalidate();
                            break;
                        case 6:
                            commands.FourNumbersDecode(data, out command, out x0,
                            out y0, out x1, out y1, out hexcolor);
                            Console.WriteLine($"Recieved command: draw ellipse; x: { x0}; y: { y0}; radius x: { x1}; radius y: { y1}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            ellipses.Add(new Ellipses(x0, y0, x1, y1, argb,
                            false));
                            Invalidate();
                            break;
                        case 7:
                            commands.FourNumbersDecode(data, out command, out x0,
                     out y0, out x1, out y1, out hexcolor);
                            Console.WriteLine($"Recieved command: fill ellipse; x: { x0}; y: { y0}; radius x: { x1}; radius y: { y1}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            ellipses.Add(new Ellipses(x0, y0, x1, y1, argb,
                            true));
                            Invalidate();
                            break;
                        case 8:
                            commands.CircleDecode(data, out command, out x0, out
                            y0, out radius, out hexcolor);
                            Console.WriteLine($"Recieved command: draw circle; x: { x0}; y: { y0}; radius: { radius}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            ellipses.Add(new Ellipses(x0, y0, radius, radius,
                            argb, false));
                            Invalidate();
                            break;
                        case 9:
                            commands.CircleDecode(data, out command, out x0, out
                            y0, out radius, out hexcolor);
                            Console.WriteLine($"Recieved command: fill circle; x: { x0}; y: { y0}; radius: { radius}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            ellipses.Add(new Ellipses(x0, y0, radius, radius,
                            argb, true));
                            Invalidate();
                            break;
                        case 10:
                            commands.RoundedRectDecode(data, out command, out x0,
                            out y0, out x1, out y1, out radius, out hexcolor);
                            Console.WriteLine($"Recieved command: draw rounded rectangle; x: { x0}; y: { y0}; width: { x1}; height: { y1}; radius: { radius}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            roundedRectangles.Add(new RoundedRectangle(x0, y0, x1,
                            y1, radius, argb, false));
                            Invalidate();
                            break;
                        case 11:
                            commands.RoundedRectDecode(data, out command, out x0,
                            out y0, out x1, out y1, out radius, out hexcolor);
                            Console.WriteLine($"Recieved command: fill rounded rectangle; x: { x0}; y: { y0}; width: { x1}; height: { y1}; radius: { radius}; color: 0x{ hexcolor}; ");
                    argb = ColorConvert(hexcolor);
                            roundedRectangles.Add(new RoundedRectangle(x0, y0, x1,
                            y1, radius, argb, true));
                            Invalidate();
                            break;
                        case 12:
                            commands.TextDecode(data, out command, out x0, out y0,
                            out hexcolor, out x1, out y1, out text);
                            Console.WriteLine($"Recieved command: draw text; x: { x0}; y: { y0}; color: 0x{ hexcolor}; font number: { x1}; length: { y1}; text:{ text}; ");
                    argb = ColorConvert(hexcolor);
                            texts.Add(new Texts(x0, y0, argb, x1, text));
                            Invalidate();
                            break;
                        case 13:
                            commands.ImageDecode(data, out command, out x0, out
                            y0, out x1, out y1, out Color[,] colors);
                            Console.WriteLine($"Recieved command: draw image; x: { x0}; y: { y0}; width: { x1}; height: { y1}; colors: ");
                    pictures.Add(new Pictures(x0, y0, x1, y1, colors)); Invalidate();
                            break;
                        case 14:
                            rotation =
                            BitConverter.ToInt16(data.Skip(1).Take(2).ToArray(), 0);
                            Console.WriteLine($"Recieved command: set orientation; rotation angle: { rotation}; ");
                    Invalidate();
                            break;
                        case 15:
                            data =
                            BitConverter.GetBytes(Convert.ToInt16(this.Width));
                            Console.WriteLine($"Recieved command: get width;");
                            iPEndPoint = new IPEndPoint(remoteIp.Address,
                            remoteIp.Port);
                            receiver.Send(data, data.Length, iPEndPoint);
                            break;
                        case 16:
                            data =
                            BitConverter.GetBytes(Convert.ToInt16(this.Height));
                            Console.WriteLine($"Recieved command: get height;");
                            iPEndPoint = new IPEndPoint(remoteIp.Address,
                            remoteIp.Port);
                            receiver.Send(data, data.Length, iPEndPoint);
                            break;
                        case 17:
                            penWidth =
                            BitConverter.ToInt16(data.Skip(1).Take(2).ToArray(), 0);
                            Console.WriteLine($"Recieved command: set pen width; width: { penWidth}; ");
                    Invalidate();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                receiver.Close();
            }
        }
        //***********************SECONDARY FUNCTIONS***********************
        static void DeleteAllGraphics()
        {
            pixels.Clear();
            lines.Clear();
            rectangles.Clear();
            ellipses.Clear();
            roundedRectangles.Clear();
            texts.Clear();
            pictures.Clear();
        }
        static public Color ColorConvert(string hexcolor)
        {
            Int16 color = Convert.ToInt16(hexcolor, 16);
            string bits = Convert.ToString(color, 2).PadLeft(16, '0');
            int R = Convert.ToInt32(bits.Substring(0, 5).PadRight(8, '0'), 2);
            int G = Convert.ToInt32(bits.Substring(5, 6).PadRight(8, '0'), 2);
            int B = Convert.ToInt32(bits.Substring(11, 5).PadRight(8, '0'), 2);
            return Color.FromArgb(R, G, B);
        }
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();
            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }
            // top left arc
            path.AddArc(arc, 180, 90);
            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        { }
    }
}
