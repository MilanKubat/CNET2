using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            
        }

        private async void btnNacist_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ProgresLista1.Value = 0;

            TextoveOknoDebug.Text += "\nZačátek po  kliknutí";
            var stopky = new Stopwatch();
            stopky.Start();


            var CestaBigFiles = @"c:\DATA\Programovani\REPO2\Bigfiles\";
            //var soubory = Knihy.SouboryVAdresari(@"c:\DATA\Programovani\REPO2\Knihy\");
            
            var soubory = Knihy.SouboryVAdresari(CestaBigFiles);
            TextoveOkno.Text = "";

            
            foreach (string soubor in soubory)
            {
                var KompletniSeznam = new Dictionary<string, int>();
                var Top10 = new Dictionary<string, int>();
                KompletniSeznam = await Knihy.FrekvenceSlovAsync(soubor);
                Top10 = Knihy.Nejcastejsi(KompletniSeznam, 10);

               
                TextoveOkno.Text += "SOUBOR:   " + soubor + Environment.NewLine;
                TextoveOkno.Text += "-------------------------------------" + Environment.NewLine;
                TextoveOkno.Text += Knihy.SeznamDoStringu(Top10);
                TextoveOkno.Text += Environment.NewLine;
                
                TextoveOknoDebug.Text += "\nSoubor hotový " + stopky.ElapsedMilliseconds + " ms";

                //SkrolovaciTextoveOkno.Text = TextoveOkno.Text;

                ProgresLista1.Value += 100/soubory.Count();

                Data.Data.Vysledky.Add(new Model.StatistickeVysledky() { Zdroj = soubor, Nejcastejsich10 = Top10 });
            }
            stopky.Stop();
            TextoveOknoDebug.Text += "\nKonec po  kliknutí";
            TextoveOknoDebug.Text += "\nCelé to trvalo " + stopky.ElapsedMilliseconds + " ms";
            Mouse.OverrideCursor = null;
            ProgresLista1.Value = 100;
        }

        private void btnNacistParalelne_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            TextoveOknoDebug.Text += "\nZačátek paralelního zpracování";
            var stopky = new Stopwatch();
            stopky.Start();


            var CestaBigFiles = @"c:\DATA\Programovani\REPO2\Bigfiles\";
            //var soubory = Knihy.SouboryVAdresari(@"c:\DATA\Programovani\REPO2\Knihy\");

            var soubory = Knihy.SouboryVAdresari(CestaBigFiles);
            TextoveOkno.Text = "";
            var GlobalniSeznam = new Dictionary<string, int>();
            var Top10 = new Dictionary<string, int>();

            foreach (string soubor in soubory)
            {
                var KompletniSeznam = new Dictionary<string, int>();
                
                KompletniSeznam = Knihy.FrekvenceSlov(soubor);

                Knihy.Spoj(KompletniSeznam, GlobalniSeznam);

                TextoveOknoDebug.Text += "\nSoubor hotový " + stopky.ElapsedMilliseconds + " ms";

                //SkrolovaciTextoveOkno.Text = TextoveOkno.Text;

            }
            Top10 = Knihy.Nejcastejsi(GlobalniSeznam, 10);

            TextoveOkno.Text += "SOUBOR:   " + Environment.NewLine;
            TextoveOkno.Text += "-------------------------------------" + Environment.NewLine;
            TextoveOkno.Text += Knihy.SeznamDoStringu(Top10);
            TextoveOkno.Text += Environment.NewLine;

            TextoveOknoDebug.Text += "\nSoubor hotový " + stopky.ElapsedMilliseconds + " ms";

            stopky.Stop();
            TextoveOknoDebug.Text += "\nKonec paralelního zpracování";
            TextoveOknoDebug.Text += "\nCelé paralelní zpracování trvalo " + stopky.ElapsedMilliseconds + " ms";
            Mouse.OverrideCursor = null;
        }

        private void btnOtevriPrehled_Click(object sender, RoutedEventArgs e)
        {
            var okno = new Přehled();
            okno.Show();
        }
    }
}
