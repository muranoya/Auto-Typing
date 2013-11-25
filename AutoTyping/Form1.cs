using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace AutoTyping
{
    public partial class Form1 : Form
    {
        private int fps = 400; //1回あたりの処理時間
        private bool stopRequest; //Stop要求があればtrue;

        private struct TemplateUnit
        {
            private int[,] templateimage;
            public int[,] TemplateImage
            {
                get { return this.templateimage; }
            }

            private char character;
            public char Character
            {
                get { return this.character; }
            }

            private int area;
            public int Threshold
            {
                get { return area - 1; }
            }

            public override string ToString()
            {
                return "\"" + Character + "\" " 
                    + " img:" + TemplateImage.GetLength(0) + "x" + TemplateImage.GetLength(1)
                    + " Area:" + TemplateImage.GetLength(0) * TemplateImage.GetLength(1);
            }

            public TemplateUnit(int[,] templateimage, char character)
            {
                this.templateimage = templateimage;
                this.area = templateimage.GetLength(0) * templateimage.GetLength(1);
                this.character = character;
            }
        }

        private struct TemplateResult
        {
            private Rectangle machingpoint;
            public Rectangle MachingPoint
            {
                get { return machingpoint; }
            }

            private char character;
            public Char Character
            {
                get { return character; }
            }

            public override string ToString()
            {
                return "Point:(" + MachingPoint.X + ", " + MachingPoint.Y + ") "
                    + "Rect:(" + MachingPoint.Width + ", " + MachingPoint.Height + ") "
                    + "c = " + Character;
            }

            public TemplateResult(Rectangle rect, char c)
            {
                this.machingpoint = rect;
                this.character = c;
            }
        }

        private static void CapcherScreen(Point p, Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(p.X, p.Y, 0, 0, bmp.Size);
            }
        }

        private int[,] GetBinaryImage(Bitmap bmp)
        {
            //2値画像を作る
            int[,] bimg = new int[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int m = (c.R + c.G + c.B) / 3;
                    bimg[x, y] = (m > 128) ? 0 : 1;
                }
            }

            return bimg;
        }

        //private List<TemplateUnit> MakeFontTemplate()
        //{
        //    char[] chars = new char[26 * 1 + 3]; //a-z,-,!,?
        //    var list = new List<TemplateUnit>();

        //    {
        //        int index = 0;
        //        for (int i = 0; i <= 'z' - 'a'; i++, index++)
        //            chars[index] = (char)('a' + i);
        //        //for (int i = 0; i <= 'Z' - 'A'; i++, index++)
        //        //    chars [index] = (char)('A' + i);
        //        chars[index++] = '!';
        //        chars[index++] = '-';
        //        chars[index++] = '?';
        //    }

        //    Bitmap tmp = new Bitmap(100, 100);
        //    Graphics g = Graphics.FromImage(tmp);
        //    foreach (var c in chars)
        //    {
        //        g.FillRectangle(Brushes.Black, 0, 0, 100, 100);
        //        SizeF size = g.MeasureString(c.ToString(), font);
        //        g.DrawString(c.ToString(), font, Brushes.White, new PointF(0, 0));

        //        Bitmap tmplate = new Bitmap((int)size.Width, (int)size.Height);
        //        Graphics g2 = Graphics.FromImage(tmplate);
        //        g2.DrawImageUnscaled(tmp, 0, 0, (int)size.Width, (int)size.Height);
        //        g2.Dispose();

        //        var bimg = GetBinaryImage(tmplate);
        //        list.Add(new TemplateUnit(bimg, GetDotsCount(bimg), c));
        //    }
        //    g.Dispose();
        //    tmp.Dispose();

        //    return list;
        //}

        private List<TemplateUnit> MakeFontTemplate()
        {
            var files = Directory.GetFiles("template");
            var list = new List<TemplateUnit>();

            foreach (var f in files)
            {
                string str = Path.GetFileNameWithoutExtension(f);
                if ("！".Equals(str))
                {
                    str = "!";
                }
                else if ("？".Equals(str))
                {
                    str = "?";
                }
                var bmp = GetBinaryImage((Bitmap)Bitmap.FromFile(f));
                list.Add(new TemplateUnit(bmp, str.ToCharArray()[0]));
            }

            return list;
        }

        private string TemplateMatching(List<TemplateUnit> list, int[,] bimg, Bitmap bmp)
        {
            int img_width = bimg.GetLength(0);
            int img_height = bimg.GetLength(1);
            var result = new List<TemplateResult>();
            object syncobj = new object();

            Parallel.ForEach(list, (template) =>
            {
                int s;
                int[,] timg = template.TemplateImage;
                int t_width = timg.GetLength(0);
                int t_height = timg.GetLength(1);

                for (int x = 0; x < img_width - t_width; x++)
                {
                    for (int y = 0; y < img_height - t_height; y++)
                    {
                        s = 0;
                        for (int x2 = 0; x2 < t_width; x2++)
                        {
                            for (int y2 = 0; y2 < t_height; y2++)
                            {
                                if (timg[x2, y2] == bimg[x + x2, y + y2])
                                {
                                    s++;
                                }
                            }
                        }
                        if (s > template.Threshold)
                        {
                            var rect = new Rectangle(x, y, t_width, t_height);
                            lock (syncobj)
                            {
                                result.Add(new TemplateResult(rect, template.Character));
                                DrawMatchingRect(rect, bmp);
                            }
                        }
                    }
                }
            });

            return AlignmentMaching(result);
        }

        private string AlignmentMaching(List<TemplateResult> list)
        {
            string str = "";

            list.Sort((a, b) => a.MachingPoint.X - b.MachingPoint.X);

            foreach (var e in list)
                str += e.Character;

            return str;
        }

        private void DrawMatchingRect(Rectangle rect, Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawRectangle(Pens.Green, rect);
            }
        }

        private bool IsIncludeBefore(string before, string after)
        {
            if (before.Length > after.Length)
            {
                string str = before.Substring(before.Length - after.Length, after.Length);
                if (str.Equals(after))
                    return true;
            }
            return false;
        }

        private void AdjustPictureBox()
        {
            int height = this.ClientRectangle.Height - controlPanel.Height;
            capturePBox.Height = height / 2;
        }

        private void ChangeGUIEnabled(bool isprocessing)
        {
            startButton.Enabled = !isprocessing;
            stopButton.Enabled = isprocessing;
            label2.Enabled = !isprocessing;
            label3.Enabled = !isprocessing;
            fpsChangeNumericBox.Enabled = !isprocessing;

            this.fps = (int)fpsChangeNumericBox.Value;
            this.stopRequest = !isprocessing;

            if (resultPBox.Image != null)
                resultPBox.Image.Dispose();
            resultPBox.Image = null;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.stopRequest = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ChangeGUIEnabled(true);

            //テンプレート作成
            var template = MakeFontTemplate();

            Task.Factory.StartNew(() =>
            {
                int t;
                Rectangle panel_rect = capturePBox.ClientRectangle;
                Bitmap bmp = new Bitmap(panel_rect.Width, panel_rect.Height);
                string before = "";

                for (; !stopRequest; )
                {
                    t = Environment.TickCount;

                    //画面をキャプチャ
                    capturePBox.Invoke(new Action(
                        () => CapcherScreen(capturePBox.RectangleToScreen(panel_rect).Location, bmp)));
                    int[,] bimg = GetBinaryImage(bmp);

                    //パターンマッチング
                    var result = TemplateMatching(template, bimg, bmp);
                    resultPBox.Invoke(new Action(() =>
                    {
                        if (resultPBox.Image != null)
                            resultPBox.Image.Dispose();
                        resultPBox.Image = (Image)bmp.Clone();
                    }));

                    //結果の送信
                    if (result.Length > 0 && !IsIncludeBefore(before, result))
                    {
                        resultTextBox.Invoke(new Action(() => resultTextBox.Text = result));
                        SendKeys.SendWait(result + "{ENTER}");
                        before = result;

                        //処理速度にあわせて待機
                        int span = fps - Environment.TickCount + t;
                        if (span > 0)
                            Thread.Sleep(span);
                    }
                }

                startButton.Invoke(new Action(() => ChangeGUIEnabled(false)));
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdjustPictureBox();
            this.fpsChangeNumericBox.Value = this.fps;
            ChangeGUIEnabled(false);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AdjustPictureBox();
        }
    }
}
