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
using System.Windows.Shapes;

namespace OknovaAplikace
{
    /// <summary>
    /// Interakční logika pro Přehled.xaml
    /// </summary>
    public partial class Přehled : Window
    {
        public Přehled()
        {
            InitializeComponent();
        }

        private void PrehledNacten(object sender, RoutedEventArgs e)
        {
            txtBlock1.Text = Data.Data.Vysledky.Count.ToString();
        }
    }
}
