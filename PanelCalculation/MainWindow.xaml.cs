using System;
using System.Collections.Generic;
using System.Diagnostics;
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
             // "12 мм" />
             // "15 мм" />
             // "18 мм" />
             // "24 мм" />
             //  "27 мм" />
             //    < ListBoxItem Content = "30 мм" />

            Faneras = new Dictionary<string, int>();
            Faneras.Add("12 мм", 12);
            Faneras.Add("15 мм", 15);
            Faneras.Add("18 мм", 18);
            Faneras.Add("24 мм", 24);
            Faneras.Add("27 мм", 27);


            Obshivka_nar = new Dictionary<string, int>();
            Obshivka_nar.Add("Импортный", 2);
            Obshivka_nar.Add("Внутренний ТЦ", 2);
            Obshivka_nar.Add("Наружный ТЦ", 2);
            Obshivka_nar.Add("Цинк", 1);

            Pol_panel = new Dictionary<string, double>();
            Pol_panel.Add("Заливка", 5);
            Pol_panel.Add("Алюминий 1.5", 1.5);
            Pol_panel.Add("Алюминий 2", 2);
            Pol_panel.Add("Алюминий 3", 3);



            DataContext = this;
        }

        public Dictionary<string, int> Faneras { get; set; }
        public Dictionary<string, int> Obshivka_nar { get; set; }
        public Dictionary<string, double> Pol_panel { get; set; }

        //private int _selectedFaneraIndex;
        //public int SelectedFaneraIndex
        //{
        //    get { return _selectedFaneraIndex; }
        //    set
        //    {
        //        _selectedFaneraIndex = value;
        //        Debug.WriteLine("Selected Fanera Index=" + _selectedFaneraIndex);
        //    }
        //}



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
                    ut_per.Text = "80";
                    ut_dv.Text = "80";
                    ut_pol.Text = "80";
                    break;
                case "0,7":
                    ut_kr.Text = "50";
                    ut_st.Text = "50";
                    ut_per.Text = "50";
                    ut_dv.Text = "50";
                    ut_pol.Text = "50";
                    break;

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double Length, dutkr, dutdv, dpodk_dv, dnar_obsh_dv, dvn_obsh_dv, Height,
                dfanera, dutpol, dnar_obsh_pol, dvn_obsh_pol, dpodk_pol, Width,
                dnar_obsh_bok, dvn_obsh_bok, dutbok, dpodk_bok,
                dnar_obsh_per, dvn_obsh_per, dutper, dpodk_per,
                dh_platform; 


            double.TryParse(L.Text, out Length);
            double.TryParse(H.Text, out Height);
            double.TryParse(B.Text, out Width);

            double.TryParse(ut_kr.Text, out dutkr);            
            double.TryParse(ut_dv.Text, out dutdv);
            double.TryParse(ut_pol.Text, out dutpol);

            double.TryParse(podk_dv.Text, out dpodk_dv);
            double.TryParse(podk_pol.Text, out dpodk_pol); 
                       
            double.TryParse(nar_obsh_dv.SelectedValue.ToString(), out dnar_obsh_dv);
            double.TryParse(vn_obsh_dv.SelectedValue.ToString(), out dvn_obsh_dv);
            double.TryParse(fanera.SelectedValue.ToString(), out dfanera);
            double.TryParse(vn_obsh_pol.SelectedValue.ToString(), out dvn_obsh_pol);
            double.TryParse(nar_obsh_pol.SelectedValue.ToString(), out dnar_obsh_pol);

            double.TryParse(nar_obsh_st.SelectedValue.ToString(), out dnar_obsh_bok);
            double.TryParse(vn_obsh_st.SelectedValue.ToString(), out dvn_obsh_bok);
            double.TryParse(podk_st.Text, out dpodk_bok);
            double.TryParse(ut_st.Text, out dutbok);

            double.TryParse(nar_obsh_per.SelectedValue.ToString(), out dnar_obsh_per);
            double.TryParse(vn_obsh_per.SelectedValue.ToString(), out dvn_obsh_per);
            double.TryParse(podk_per.Text, out dpodk_per);
            double.TryParse(ut_per.Text, out dutper);

            double.TryParse(h_platform.Text, out dh_platform);


            double length_bok = Length + dutdv + dpodk_dv + dnar_obsh_dv + dvn_obsh_dv;
            double height_bok = Height + dutpol + dfanera + dpodk_pol + dnar_obsh_pol + dvn_obsh_pol + dh_platform;
            double tolsh_bok = dnar_obsh_bok + dvn_obsh_bok + dutbok + dpodk_bok;
            double width_nar = Width + 2 * tolsh_bok;

            double tolsh_per = dnar_obsh_per + dvn_obsh_per + dutper + dpodk_per;

            double length_kr = length_bok + tolsh_per;

            double s_per = height_bok * width_nar;
            double s_bok = length_bok * height_bok;
            double s_dv = Width * Height;
            double s_kr = width_nar * length_kr;
            double s_pol = length_bok * Width;

            double s_nar = s_bok * 2 + s_per + s_dv;
            double s_vn = s_nar + s_kr * 2 + s_pol; //если пластик


            //Peredn. stenka

            //MessageBox.Show(length_kr.ToString());
            MessageBox.Show(fanera.SelectedValue.ToString());

        }
    }
}
