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

namespace equation
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

                double x1 = 0; double x2 = 0;

                double a = Convert.ToDouble(ATxt.Text);
                double b = Convert.ToDouble(BTxt.Text);
                double c = Convert.ToDouble(CTxt.Text);


                Result.Content = "x1 =" + "x2 = ";

                /*if (a == 0)                                       Проверка деления на ноль
                {
                    MessageBox.Show("Делить на ноль нельзя");
                }*/


                if ((b * b - 4 * a * c) >= 0)
                {

                    x1 = (-1 * b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                    x2 = (-1 * b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

                    if ((b * b - 4 * a * c) == 0)
                    {
                        Result.Content = "x = " + Math.Round(x1, 2);
                    }
                    else
                    {
                        Result.Content = "x1 = " + x1;
                        Result.Content += "     x2 = " + Math.Round(x2, 2);
                    }
                }
                else
                {
                    Result.Content = "Вещественных корней не найдено.";
                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод коэфициентов");
            }
          
        }

        private void ATxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (IsNumber(e.Text) == false && e.Text != "," & e.Text != "-")
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
