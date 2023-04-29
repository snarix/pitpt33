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

namespace PITPT_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private void CalcTask1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(xTask1.Text, out int x))
            {
                double y1 = Math.Round(Math.Sin(x) + Math.Pow(Math.Abs(Math.Pow(x, 2) + 1), 5) - Math.Sqrt(Math.Abs(Math.Pow(x, 2) / Math.Pow(x, 2) + 5)), 3);
                rezTask1.Text = y1.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void AboutTask1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вычислить: y = sinx + |x^2 + 1|^5 - √|x^2 / x^2+5|");
        }

        private void CalcTask2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(xTask2.Text, out int x))
            {
                double a = 54 * Math.Pow(10, -3);
                double y2 = Math.Round(Math.Log10(Math.Sin(x) * Math.Sqrt(1 + Math.Cos(a / x) / a * x * Math.Sin(a * x)) + x * Math.Sqrt(Math.Sin(x))), 3);
                rezTask2.Text = y2.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void AboutTask2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вычислить: y = ln |sinx * √(1+cos a/x) / a * x * sinx(ax))| + x * √sinx, гду а = 54 * 10^-3");
        }

        private void CalcTask3(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(diapozon.Text, out int x))
            {
                double sum = 0;
                for (int i = 1; i < x; i++)
                {
                    sum += 1 / Math.Pow(i, 2);
                }
                rezTask3.Text = sum.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void AboutTask3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вычислить сумму ряда S = Е 1/i^2 с погрешностью E > 0");
        }

        int[] mas;
        private void ArrTask4(object sender, RoutedEventArgs e)
        {
            string a = "";
            if (int.TryParse(xTask4.Text, out int x))
            {
                mas = new int[x];
                Random rnd = new Random();
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = rnd.Next(-10, 10);
                    a += mas[i] + " ";
                }
            }
            rezTask4.Text = a;
        }

        private void CalcTask4(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 0)
                {
                    sum += mas[i];
                }
            }

            int proizv = 1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    proizv *= mas[i];
                }
            }
            int kol = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 0)
                {
                    kol++;
                }
            }
            MessageBox.Show("Сумма отрицательных чисел - " + sum + "\nПроизведение положиетльных чисел - " + proizv + "\nКол-во нулевых значений - " + kol);
        }

        private void AboutTask4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Написать программу вычисления суммы отрицательных, произведения положительных и количества нулевых значений в одномерном массиве.");
        }

        private void MatrixTask5(object sender, RoutedEventArgs e)
        {
            int[,] OldMatrix = new int[4, 6];
            Random rnd = new Random();
            for (int i = 0; i < OldMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < OldMatrix.GetLength(1); j++)
                {
                    OldMatrix[i, j] = rnd.Next(10);
                }
            }
            OldMatrixGrid.ItemsSource = OldMatrix.ToDataTable().DefaultView;

            int x;
            for (int i = 0; i < OldMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < OldMatrix.GetLength(1); j++)
                {
                    if (j < OldMatrix.GetLength(1) / 2)
                    {
                        x = OldMatrix[i, j];
                        OldMatrix[i, j] = OldMatrix[i, OldMatrix.GetLength(1) - j - 1];
                        OldMatrix[i, OldMatrix.GetLength(1) - j - 1] = x;   
                    }             
                }
            }
            NewMatrixGrid.ItemsSource = OldMatrix.ToDataTable().DefaultView;
        }

        private void AboutTask5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Получить матрицу [Bij], i, j=1,  из матрицы [Aij], i, j = 1 путем перестановки столбцов - первого с последним, второго с предпоследним и т.д.");
        }
    }
}
