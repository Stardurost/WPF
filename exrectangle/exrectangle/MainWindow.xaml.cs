using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exrectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double x1, y1, x2, y2, x3, y3, x4, y4, alen, blen, clen, dlen, k1, k2, k3, k4;
            string a, b, c, d;
            string[] a1, b1, c1, d1;

            try
            {
                a = Convert.ToString(ATxt.Text);
                b = Convert.ToString(BTxt.Text);
                c = Convert.ToString(CTxt.Text);
                d = Convert.ToString(DTxt.Text);


                a1 = a.Split(';');
                x1 = Convert.ToDouble(a1[0]);
                y1 = Convert.ToDouble(a1[1]);

                b1 = b.Split(';');
                x2 = Convert.ToDouble(b1[0]);
                y2 = Convert.ToDouble(b1[1]);

                c1 = c.Split(';');
                x3 = Convert.ToDouble(c1[0]);
                y3 = Convert.ToDouble(c1[1]);

                d1 = d.Split(';');
                x4 = Convert.ToDouble(d1[0]);
                y4 = Convert.ToDouble(d1[1]);

                alen = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
                blen = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
                clen = Math.Sqrt(Math.Pow((x4 - x3), 2) + Math.Pow((y4 - y3), 2));
                dlen = Math.Sqrt(Math.Pow((x1 - x4), 2) + Math.Pow((y1 - y4), 2));

                k1 = (y2 - y1) / (x2 - x1);
                k2 = (y3 - y2) / (x3 - x2);
                k3 = (y4 - y3) / (x4 - x3);
                k4 = (y1 - y4) / (x1 - x4);

                if ((alen == blen) & (alen == dlen) & (alen == clen) & (blen == clen) & (blen == dlen) & (clen == dlen))
                {
                    if ((x1 * x2 + y1 * y2) == 0)
                    {
                        Result.Content = "Квадрат";
                    }
                    else
                    {
                        Result.Content = "Ромб";
                    }
                }
                else if ((alen == clen) & (blen == dlen))
                {
                    if ((x1 * x2 + y1 * y2) == 0)
                    {
                        Result.Content = "Прямоугольник";
                    }
                    else
                    {
                        Result.Content = "Параллелограмм";
                    }
                }
                else if ((alen == clen)
                    & ((x4 - x1) / dlen == (x3 - x2) / blen) || ((blen == dlen)
                    & ((x3 - x4) / clen == (x2 - x1) / alen)) || ((alen == clen) & (blen == dlen)) || ((blen == dlen) & (clen == alen)))
                {
                    Result.Content = "Равнобедренная трапеция";
                }
                else if ((k1 == k3) || (k2 == k4))
                {
                    if (((x1 * x2 + y1 * y2) == 0) | ((x2 * x3 + y2 * y3) == 0)
                       | ((x3 * x4 + y3 * y4) == 0) | ((x4 * x1 + y4 * y1) == 0))
                    {
                        Result.Content = "Прямоугольная трапеция";
                    }
                    else
                    {
                        Result.Content = "Трапеция";
                    }
                }
                else
                {
                    Result.Content = "Многоугольник";
                }

            }
            catch
            {
                MessageBox.Show("Неверно введены координаты");
            }
        }

        private void ATxt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ATxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (IsNumber(e.Text) == false & e.Text != "," & e.Text != "-" & e.Text != ";")
                {
                    e.Handled = true;
                }

            }
        }


        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);

        }

    }
}
