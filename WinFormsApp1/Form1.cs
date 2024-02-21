using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Pen pen1, pen2, pen_ax;
        double x0, y0, x1, y1, x2, y2;
        Bitmap canvas;
        Graphics user_Graphics;
        Color user_color;
        int w, h;
        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            user_Graphics = Graphics.FromImage(canvas);
            user_Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            pictureBox1.Image = canvas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            user_color = Color.Red;
            pen_ax = new Pen(Color.Black, 1);
            pen1 = new Pen(user_color, 3);
            pen2 = new Pen(Color.Blue, 2);
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            w = pictureBox1.Width;
            h = pictureBox1.Height;
            x0 = w / 2;
            y0 = h / 2;
            user_Graphics.DrawLine(pen_ax, (float)x0, 5, (float)x0, h);
            user_Graphics.DrawLine(pen_ax, 0, (float)y0, w - 5, (float)y0);
            user_Graphics.DrawLine(pen_ax, w - 10, (float)y0 + 5, w - 5, (float)y0);
            user_Graphics.DrawLine(pen_ax, w - 10, (float)y0 - 5, w - 5, (float)y0);
            user_Graphics.DrawLine(pen_ax, (float)x0 - 5, 10, (float)x0, 5);
            user_Graphics.DrawLine(pen_ax, (float)x0 + 5, 10, (float)x0, 5);
            pictureBox1.Image = canvas;
        }



        private void sin_button_Click(object sender, EventArgs e)
        {

            double t = 0;
            x1 = w / 2;
            y1 = h / 2;
            x2 = x1;
            y2 = y1;
            double a = Double.Parse(this.textBox1.Text);
            double c = Double.Parse(this.textBox2.Text);
            double p = c * c + a * a;
            double templ1 = 0;
            double templ2 = 0;
            bool flag = false;
            
                if(a>c)
                {
                    while (t < 2 * Math.PI)
                    {

                    t += Math.PI / 180;
                    templ1 = c * c * Math.Cos(2 * t);
                    templ2 = Math.Sqrt(c * c * c * c * Math.Cos(2 * t) * Math.Cos(2 * t) + (a * a * a * a - c * c * c * c));

                    if (templ1 > templ2)
                    {
                        p = Math.Sqrt(templ1 - templ2);
                    }
                    else if (templ2 > templ1)
                    {
                        p = Math.Sqrt(templ1 + templ2);
                    }

                    x2 = 10 * p * Math.Cos(t) + w / 2;// - y0* Math.Sin(t);
                    y2 = 10 * p * Math.Sin(t) + h / 2;// + y0 * Math.Cos(t);

                    if (flag) user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y2);
                    flag = true;
                    x1 = x2;
                    y1 = y2;

                    }
                }






                else if(a<c)
                {
                    double step = 0.01;
                    x0 = w / 2;
                    y0 = h / 2;
                    int i = 0;

                    while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) < i * i * step * step + c*c) i++;

                    x1 = x0 + 10 * step * i;
                    y1 = y0;
                    while(Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) >= i * i * step * step + c*c)
                    {
                        x2 = x1 + 10*step;
                        y2 = y0 +10*Math.Sqrt(Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) - i * i * step * step - c * c);
                        user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y2);
                        x1 = x2; y1 = y2;
                        i++;
                    }
                    user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y0);

                //--------------------------------------------------------------------
                i = 0;

                    while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) < i * i * step * step + c * c) i++;

                    x1 = x0 + 10 * step * i;
                    y1 = y0;
                    while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) >= i * i * step * step + c * c)
                    {
                        x2 = x1 + 10*step;
                        y2 = y0 - 10*Math.Sqrt(Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) - i * i * step * step - c * c);

                        user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y2);
                        x1 = x2; y1 = y2;
                        i++;
                    }
                    user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y0);

                //--------------------------------------------------------------------
                 i = 0;

                while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) < i * i * step * step + c * c) i++;

                x1 = x0 - 10*step * i;
                y1 = y0;
                while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) >= i * i * step * step + c * c)
                {
                    x2 = x1 - 10 * step;
                    y2 = y0 + 10 * Math.Sqrt(Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) - i * i * step * step - c * c);
                    user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y2);
                    x1 = x2; y1 = y2;
                    i++;
                }
                user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y0);


                //--------------------------------------------------------------------
                i = 0;

                while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) < i * i * step * step + c * c) i++;

                x1 = x0 - 10 * step * i;
                y1 = y0;
                while (Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) >= i * i * step * step + c * c)
                {
                    x2 = x1 - 10 * step;
                    y2 = y0 - 10 * Math.Sqrt(Math.Sqrt(a * a * a * a + 4 * c * c * i * i * step * step) - i * i * step * step - c * c);

                    user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y2);
                    x1 = x2; y1 = y2;
                    i++;
                }
                user_Graphics.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y0);








            }
            
            pictureBox1.Image = canvas;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphic = Graphics.FromImage(pictureBox1.Image);
            graphic.Clear(Color.White);
        }
    }
}