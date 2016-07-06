using System;
using System.IO;
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
using System.Globalization;
//using System.Collections.Generic;

namespace kursovaTPR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new dictionary of inputs: doubles with string keys.
                Dictionary<string, double> inputs = new Dictionary<string, double>();
                //read inputs from the textboxes
                //resource 1  - расход
                double gL11 = double.Parse(gL11w.Text, CultureInfo.InvariantCulture);//get value from the textbox, type conversion, empty fields are not excepted
                double gL21 = double.Parse(gL21w.Text, CultureInfo.InvariantCulture); //Global standards, both , and . decimal separators are excepted
                double gL31 = double.Parse(gL31w.Text, CultureInfo.InvariantCulture);
                double gH11 = double.Parse(gH11w.Text, CultureInfo.InvariantCulture);
                double gH21 = double.Parse(gH21w.Text, CultureInfo.InvariantCulture);
                double gH31 = double.Parse(gH31w.Text, CultureInfo.InvariantCulture);
                inputs.Add("gL11", gL11);
                inputs.Add("gL21", gL21);
                inputs.Add("gL31", gL31);
                inputs.Add("gH11", gH11);
                inputs.Add("gH21", gH21);
                inputs.Add("gH31", gH31);
                //resource 2
                double gL12 = double.Parse(gL12w.Text, CultureInfo.InvariantCulture);//get value from the textbox, type conversion, empty fields are not excepted
                double gL22 = double.Parse(gL22w.Text, CultureInfo.InvariantCulture); //Global standards, both , and . decimal separators are excepted
                double gL32 = double.Parse(gL32w.Text, CultureInfo.InvariantCulture);
                double gH12 = double.Parse(gH12w.Text, CultureInfo.InvariantCulture);
                double gH22 = double.Parse(gH22w.Text, CultureInfo.InvariantCulture);
                double gH32 = double.Parse(gH32w.Text, CultureInfo.InvariantCulture);
                inputs.Add("gL12", gL12);
                inputs.Add("gL22", gL22);
                inputs.Add("gL32", gL32);
                inputs.Add("gH12", gH12);
                inputs.Add("gH22", gH22);
                inputs.Add("gH32", gH32);
                //resource 3
                double gL13 = double.Parse(gL13w.Text, CultureInfo.InvariantCulture);//get value from the textbox, type conversion, empty fields are not excepted
                double gL23 = double.Parse(gL23w.Text, CultureInfo.InvariantCulture); //Global standards, both , and . decimal separators are excepted
                double gL33 = double.Parse(gL33w.Text, CultureInfo.InvariantCulture);
                double gH13 = double.Parse(gH13w.Text, CultureInfo.InvariantCulture);
                double gH23 = double.Parse(gH23w.Text, CultureInfo.InvariantCulture);
                double gH33 = double.Parse(gH33w.Text, CultureInfo.InvariantCulture);
                inputs.Add("gL13", gL13);
                inputs.Add("gL23", gL23);
                inputs.Add("gL33", gL33);
                inputs.Add("gH13", gH13);
                inputs.Add("gH23", gH23);
                inputs.Add("gH33", gH33);
                //resource 4
                double gL14 = double.Parse(gL14w.Text, CultureInfo.InvariantCulture);//get value from the textbox, type conversion, empty fields are not excepted
                double gL24 = double.Parse(gL24w.Text, CultureInfo.InvariantCulture); //Global standards, both , and . decimal separators are excepted
                double gL34 = double.Parse(gL34w.Text, CultureInfo.InvariantCulture);
                double gH14 = double.Parse(gH14w.Text, CultureInfo.InvariantCulture);
                double gH24 = double.Parse(gH24w.Text, CultureInfo.InvariantCulture);
                double gH34 = double.Parse(gH34w.Text, CultureInfo.InvariantCulture);
                inputs.Add("gL14", gL14);
                inputs.Add("gL24", gL24);
                inputs.Add("gL34", gL34);
                inputs.Add("gH14", gH14);
                inputs.Add("gH24", gH24);
                inputs.Add("gH34", gH34);
                //resource 5
                double gL15 = double.Parse(gL15w.Text, CultureInfo.InvariantCulture);//get value from the textbox, type conversion, empty fields are not excepted
                double gL25 = double.Parse(gL25w.Text, CultureInfo.InvariantCulture); //Global standards, both , and . decimal separators are excepted
                double gL35 = double.Parse(gL35w.Text, CultureInfo.InvariantCulture);
                double gH15 = double.Parse(gH15w.Text, CultureInfo.InvariantCulture);
                double gH25 = double.Parse(gH25w.Text, CultureInfo.InvariantCulture);
                double gH35 = double.Parse(gH35w.Text, CultureInfo.InvariantCulture);
                inputs.Add("gL15", gL15);
                inputs.Add("gL25", gL25);
                inputs.Add("gL35", gL35);
                inputs.Add("gH15", gH15);
                inputs.Add("gH25", gH25);
                inputs.Add("gH35", gH35);
                //productivity a
                double a1 = double.Parse(a1w.Text, CultureInfo.InvariantCulture);
                double a2 = double.Parse(a2w.Text, CultureInfo.InvariantCulture);
                double a3 = double.Parse(a3w.Text, CultureInfo.InvariantCulture);
                inputs.Add("a1", a1);
                inputs.Add("a2", a2);
                inputs.Add("a3", a3);
                //resources available
                double b1 = double.Parse(b1w.Text, CultureInfo.InvariantCulture); //Global standards, both , and . decimal separators are excepted
                double b2 = double.Parse(b2w.Text, CultureInfo.InvariantCulture);
                double b3 = double.Parse(b3w.Text, CultureInfo.InvariantCulture);
                double b4 = double.Parse(b4w.Text, CultureInfo.InvariantCulture);
                double b5 = double.Parse(b5w.Text, CultureInfo.InvariantCulture);
                inputs.Add("b1", b1);
                inputs.Add("b2", b2);
                inputs.Add("b3", b3);
                inputs.Add("b4", b4);
                inputs.Add("b5", b5);
                foreach (var n in inputs) 
                {
                    if (n.Value<0)
                    {
                        x1w.Text = "Неправильні дані!";
                        x2w.Text = "Неправильні дані!";
                        x3w.Text = "Неправильні дані!";
                        return;
                    }
                }
                Calc newCalc = new Calc();
                Tuple<double, double, double, double> result = newCalc.calc(inputs);//perform calculations
                x1w.Text = result.Item1.ToString();
                x2w.Text = result.Item2.ToString();
                x3w.Text = result.Item3.ToString();
                maxOutput.Text = result.Item4.ToString();

            }
            catch (Exception exc)
            {
                x1w.Text = "Неправильні дані!";
                x2w.Text = "Неправильні дані!";
                x3w.Text = "Неправильні дані!";
            }

        }

    }
}
