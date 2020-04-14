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

namespace WpfAppIB1A_07042020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KoffieDBDataContext db = new KoffieDBDataContext();
        public MainWindow()
        {
            InitializeComponent();
            //Datagrid vullen met data vanuit de database
            dgKoffie.ItemsSource = db.kofsmaaks.ToList();
        }

        private void BtnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            //Nieuw object aanmaken/instantieren
            koffie deKoffie = new koffie();
            deKoffie.koffienaam = txtKoffie.Text;

            //Nieuw object aanmaken/instantieren
            smaak deSmaak = new smaak();
            deSmaak.smaaknaam = txtSmaak.Text;

            //Nieuw object aanmaken met daarin het koffieobject en het smaakobject
            kofsmaak deKofSmaak = new kofsmaak();
            deKofSmaak.koffie = deKoffie;
            deKofSmaak.smaak = deSmaak;

            //InsertOnSubmit zet de toe te voegen data in de wachtrij 
            //om opgeslagen te worden. Hij neemt nu zowel de koffie als 
            //smaak mee in de database
            db.kofsmaaks.InsertOnSubmit(deKofSmaak);
            //Daadwerkelijk opslaan
            db.SubmitChanges();

            //Bron aanpassen met nieuwe data
            dgKoffie.ItemsSource = db.kofsmaaks.ToList();

            
        }
    }
}
