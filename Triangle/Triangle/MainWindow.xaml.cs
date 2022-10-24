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

namespace Triangle
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
            try
            {
                double a = Convert.ToDouble(ATxt.Text);
                double b = Convert.ToDouble(BTxt.Text);
                double c = Convert.ToDouble(CTxt.Text);
                char flag; bool flag2;
                flag = MaxFunc(a, b, c);

                /*if (flag == 'a' & (a > b + c) || (flag == 'b' & (b > a + c)) || (flag == 'c' & (c > b + a)))
                { 
                     Result.Content = "Треугольник не существует";
                }*/
                // проверка на существование треугольника

                if ((a == b) || (a == c) || (b == c))
                {
                    if ((a == b) & (a == c) & (b == c))
                    {
                        Result.Content = "Треугольник равносторонний";
                    }
                    else
                    {
                        Result.Content = "Треугольник равнобедренный";
                    }
                }
                else if ((c * c == a * a + b * b) || (a * a == b * b + c * c) || (b * b == a * a + c * c))
                {
                    Result.Content = "Треугольник прямоугольный";
                }
                else
                {
                    Result.Content = "Треугольник разносторонний";
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод значений длины.");
            }
        }

        private char MaxFunc(double x1, double x2, double x3)
        {
            char flaq;
            double max;
            max = x1;
            flaq = 'a';
            if (x2 > max) {flaq = 'b'; }
            if (x3 > max) {flaq = 'c'; }

            return flaq;
        }

        private void ATxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (IsNumber(e.Text) == false && e.Text != "," & e.Text != "-")      // длина не может быть отрицательной
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
