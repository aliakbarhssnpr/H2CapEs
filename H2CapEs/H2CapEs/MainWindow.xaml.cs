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

namespace H2CapEs
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
        private void Get_Energy_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                double p1 = 0,
                       p2 = 0,
                       p3 = 0,
                       p4 = 0,
                       d = 0;


                p1 = double.Parse(T1.Text);
                p2 = double.Parse(T2.Text);
                p3 = double.Parse(T3.Text);
                p4 = double.Parse(T4.Text);


                switch (StorageType.SelectedIndex)
                {
                    case 0:

                        p1 *= 28316846.592; //BCF to m3
                        p1 *= 0.66575624 / (p2 / (8.3145 * p3) * 1000 * 16.04); //Standard condition to reservoir condition                    
                        d = p2 / (8.3145 * (p3) + 15.84 * p2) * 1000; //hydrogen density mol/l
                        d *= 2.016;//hydrogen density kg/m3
                        d *= p1; //hydrogen capacity kg
                        d *= (1 - p4 / 100); // hydrogen capacity excluding cushion gas
                        d *= 141.86; //Hydrogen capacity MJ
                        d *= 2.7777777777778E-10;// Hydrogen Energy Density TWH
                        Tf.Text = d.ToString("E04");

                        break;

                    case 1:

                        d = p3 / (8.3145 * (p4) + 15.84 * p3) * 1000; //hydrogen density mol/l
                        d *= 2.016;//hydrogen density kg/m3
                        d *= p1 * p2; //hydrogen capacity kg
                        d *= 141.86; //Hydrogen capacity MJ
                        d *= 2.7777777777778E-10;// Hydrogen Energy Density TWH
                        Tf.Text = d.ToString("E04");

                        break;

                    case 2:

                        d = p3 / (8.3145 * (p4) + 15.84 * p3) * 1000; //hydrogen density mol/l
                        d *= 2.016;//hydrogen density kg/m3
                        d *= p1 * 1000 * (p2 * p2 * 3.14 * .25); //hydrogen capacity kg
                        d *= 141.86; //Hydrogen capacity MJ
                        d *= 2.7777777777778E-10;// Hydrogen Energy Density TWH
                        Tf.Text = d.ToString("E04");

                        break;

                    case 3:

                        d = p1 * 70.8; //hydrogen density kg
                        d *= 141.86; //Hydrogen capacity MJ
                        d *= 2.7777777777778E-10;// Hydrogen Energy Density TWH
                        Tf.Text = d.ToString("E04");

                        break;

                    case 4:
                        d = p3 / (8.3145 * (p4) + 15.84 * p3) * 1000; //hydrogen density mol/l
                        d *= 2.016;//hydrogen density kg/m3
                        d *= p1 * p2; //hydrogen capacity kg
                        d *= 141.86; //Hydrogen capacity MJ
                        d *= 2.7777777777778E-10;// Hydrogen Energy Density TWH
                        Tf.Text = d.ToString();

                        break;

                    default:
                        break;

                }
            }
            catch
            {

            }
        }

        private void StorageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            P1.IsEnabled = false;
            T1.IsEnabled = false;
            P1.Visibility = Visibility.Collapsed;
            T1.Visibility = Visibility.Collapsed;
            T1.Text = "0";

            P2.IsEnabled = false;
            T2.IsEnabled = false;
            P2.Visibility = Visibility.Collapsed;
            T2.Visibility = Visibility.Collapsed;
            T2.Text = "0";

            P3.IsEnabled = false;
            T3.IsEnabled = false;
            P3.Visibility = Visibility.Collapsed;
            T3.Visibility = Visibility.Collapsed;
            T3.Text = "0";

            P4.IsEnabled = false;
            T4.IsEnabled = false;
            P4.Visibility = Visibility.Collapsed;
            T4.Visibility = Visibility.Collapsed;
            T4.Text = "0";

            switch (StorageType.SelectedIndex)
            {
                case 0:
                    P1.Content = "Initial Recoverable Natural Gas (BCF)";
                    P1.IsEnabled = true;
                    T1.IsEnabled = true;
                    P1.Visibility = Visibility.Visible;
                    T1.Visibility = Visibility.Visible;

                    P2.Content = "Pressure (Mpa)";
                    P2.IsEnabled = true;
                    T2.IsEnabled = true;
                    P2.Visibility = Visibility.Visible;
                    T2.Visibility = Visibility.Visible;

                    P3.Content = "Temperature (K)";
                    P3.IsEnabled = true;
                    T3.IsEnabled = true;
                    P3.Visibility = Visibility.Visible;
                    T3.Visibility = Visibility.Visible;

                    P4.Content = "Cushion Gas Volume%";
                    P4.IsEnabled = true;
                    T4.IsEnabled = true;
                    P4.Visibility = Visibility.Visible;
                    T4.Visibility = Visibility.Visible;


                    break;
                case 1:

                    P1.Content = "Number of Caverns";
                    P1.IsEnabled = true;
                    T1.IsEnabled = true;
                    P1.Visibility = Visibility.Visible;
                    T1.Visibility = Visibility.Visible;

                    P2.Content = "Salt Cavern Volume(m3)";
                    P2.IsEnabled = true;
                    T2.IsEnabled = true;
                    P2.Visibility = Visibility.Visible;
                    T2.Visibility = Visibility.Visible;

                    P3.Content = "Pressure (Mpa)";
                    P3.IsEnabled = true;
                    T3.IsEnabled = true;
                    P3.Visibility = Visibility.Visible;
                    T3.Visibility = Visibility.Visible;

                    P4.Content = "Temperature (K)";
                    P4.IsEnabled = true;
                    T4.IsEnabled = true;
                    P4.Visibility = Visibility.Visible;
                    T4.Visibility = Visibility.Visible;
                    break;
                case 2:
                    P1.Content = "Pipe Lenght(Km)";
                    P1.IsEnabled = true;
                    T1.IsEnabled = true;
                    P1.Visibility = Visibility.Visible;
                    T1.Visibility = Visibility.Visible;

                    P2.Content = "Pipe Diameter (m)";
                    P2.IsEnabled = true;
                    T2.IsEnabled = true;
                    P2.Visibility = Visibility.Visible;
                    T2.Visibility = Visibility.Visible;

                    P3.Content = "Pressure (Mpa)";
                    P3.IsEnabled = true;
                    T3.IsEnabled = true;
                    P3.Visibility = Visibility.Visible;
                    T3.Visibility = Visibility.Visible;

                    P4.Content = "Temperature (K)";
                    P4.IsEnabled = true;
                    T4.IsEnabled = true;
                    P4.Visibility = Visibility.Visible;
                    T4.Visibility = Visibility.Visible;
                    break;
                case 3:
                    P1.Content = "Volume (m3)";
                    P1.IsEnabled = true;
                    T1.IsEnabled = true;
                    P1.Visibility = Visibility.Visible;
                    T1.Visibility = Visibility.Visible;
                    break;
                case 4:
                    P1.Content = "Number of Gasometers";
                    P1.IsEnabled = true;
                    T1.IsEnabled = true;
                    P1.Visibility = Visibility.Visible;
                    T1.Visibility = Visibility.Visible;

                    P2.Content = "Gasometer Volume (m3)";
                    P2.IsEnabled = true;
                    T2.IsEnabled = true;
                    P2.Visibility = Visibility.Visible;
                    T2.Visibility = Visibility.Visible;

                    P3.Content = "Pressure (Mpa)";
                    P3.IsEnabled = true;
                    T3.IsEnabled = true;
                    P3.Visibility = Visibility.Visible;
                    T3.Visibility = Visibility.Visible;

                    P4.Content = "Temperature (K)";
                    P4.IsEnabled = true;
                    T4.IsEnabled = true;
                    P4.Visibility = Visibility.Visible;
                    T4.Visibility = Visibility.Visible;
                    break;
                default:
                    break;

            }
        }

    }
}
