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
using AnalyzaTextu;

namespace OknovaAplikace
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

        private void OknoNacteno(object sender, RoutedEventArgs e)
        {
            var soubory = Knihy.SouboryVAdresari(@"c:\DATA\Programovani\REPO2\Knihy\");
            foreach (string soubor in soubory)
            {
                var KompletniSeznam = new Dictionary<string, int>();
                var Top10 = new Dictionary<string, int>();
                KompletniSeznam = Knihy.FrekvenceSlov(soubor);
                Top10 = Knihy.Nejcastejsi(KompletniSeznam, 10);

                TextoveOkno.Text += "SOUBOR:   " + soubor + Environment.NewLine;
                TextoveOkno.Text += "-------------------------------------" + Environment.NewLine;
                TextoveOkno.Text += Knihy.SeznamDoStringu(Top10);
                TextoveOkno.Text += Environment.NewLine;

                //SkrolovaciTextoveOkno.Text = TextoveOkno.Text;

            }
        }
    }
}
