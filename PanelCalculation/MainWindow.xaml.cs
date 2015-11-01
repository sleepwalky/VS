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

namespace PanelCalculation
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


        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Copy3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void tepl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            
            switch ((e.AddedItems[0] as ComboBoxItem).Content as string)
            {
                case "0,4":
                    ut_kr.Text = "80";
                    ut_st.Text = "60";
                    ut_shit.Text = "80";
                    ut_dv.Text = "80";
                    ut_pol.Text = "80";                    
                    break;
                case "0,7":
                    ut_kr.Text = "50";
                    ut_st.Text = "50";
                    ut_shit.Text = "50";
                    ut_dv.Text = "50";
                    ut_pol.Text = "50";
                    break;
                
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double Length, dutkr, dutdv, dutshit;
            
            double.TryParse(L.Text,out Length);
            double.TryParse(ut_kr.Text, out dutkr);
            double.TryParse(ut_shit.Text, out dutshit);
            double.TryParse(ut_dv.Text, out dutdv);
            double length_kr = Length + dutkr + dutshit + dutdv;
            MessageBox.Show(length_kr.ToString());

        }
    }
}
