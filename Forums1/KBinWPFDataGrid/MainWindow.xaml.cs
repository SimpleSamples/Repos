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

// c# keyboard input in WPF DataGrid
// https://docs.microsoft.com/en-us/answers/questions/322758/c-keyboard-input-in-wpf-datagrid.html?childToView=324357#comment-324357

namespace KBinWPFDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double firstNumber, secondNumber, resultNumber = 0;
        bool calcDone = false;
        Operations operation = Operations.None;
        string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public MainWindow()
        {
            InitializeComponent();

            //Assign to the decimal button the separator from the current culture
            dec.Content = separator;
        }

        //List the possible numeric operations
        private enum Operations
        {
            None,
            Division,
            Multiplication,
            Subtraction,
            Sum
        }

        //Manage number buttons input
    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;

        string s = button.Content.ToString();
        if (s.Length != 2)
            {
                System.Diagnostics.Debug.WriteLine($"NumberButton content is not valid");
                return;
            }

            if (calcDone) //calculation already done
        {
            result.Content = s[1];
            calcDone = false;
        }
        else //calculation not yet done
        {
            if (result.Content.ToString() == "0")
            {
                result.Content = s[1];
            }
            else
            {
                result.Content = result.Content.ToString() + s[1];
            }
        }

    }

        //Manage operation buttons input
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            //Evaluate button pressed
            switch (button.Content.ToString())
            {
                case "AC":
                    result.Content = "0";
                    break;
                case "+/-":
                    if (!(result.Content.ToString() == "0"))
                    {
                        result.Content = Convert.ToDouble(result.Content) * -1;
                    }
                    break;
                case "%":
                    if (!(result.Content.ToString() == "0"))
                    {
                        result.Content = Convert.ToDouble(result.Content) / 100;
                    }
                    break;
                case "÷":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Division;
                    result.Content = "0";
                    break;
                case "×":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Multiplication;
                    result.Content = "0";
                    break;
                case "-":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Subtraction;
                    result.Content = "0";
                    break;
                case "+":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Sum;
                    result.Content = "0";
                    break;
                case "=":
                    switch (operation)
                    {
                        case Operations.Division:
                            if (calcDone)
                            {
                                if (!(result.Content.ToString() == "ERROR"))
                                {
                                    result.Content = Convert.ToDouble(result.Content) / secondNumber;
                                }
                            }
                            else
                            {
                                //Check if division by 0
                                if (result.Content.ToString() == "0")
                                {
                                    result.Content = "ERROR";
                                    calcDone = true;
                                }
                                else
                                {
                                    secondNumber = Convert.ToDouble(result.Content);
                                    resultNumber = firstNumber / secondNumber;
                                    result.Content = resultNumber;
                                    calcDone = true;
                                }
                            }
                            break;
                        case Operations.Multiplication:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) * secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber * secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Subtraction:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) - secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber - secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Sum:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) + secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                MessageBox.Show($"{firstNumber} + {secondNumber}");
                                resultNumber = firstNumber + secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                    }
                    break;
                default:
                    if (!result.Content.ToString().Contains(separator))
                    {
                        result.Content = $"{result.Content}{button.Content}";
                    }
                    break;
            }
        }
    }
}
