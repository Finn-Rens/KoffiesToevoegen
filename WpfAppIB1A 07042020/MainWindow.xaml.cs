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
         
            dgKoffie.ItemsSource = db.kofsmaaks.ToList();
        }

        private void BtnOpslaan_Click(object sender, RoutedEventArgs e)
        {
         
            koffie deKoffie = new koffie();
            deKoffie.koffienaam = txtKoffie.Text;

         
            smaak deSmaak = new smaak();
            deSmaak.smaaknaam = txtSmaak.Text;

          
            kofsmaak deKofSmaak = new kofsmaak();
            deKofSmaak.koffie = deKoffie;
            deKofSmaak.smaak = deSmaak;

            db.kofsmaaks.InsertOnSubmit(deKofSmaak);
            
            db.SubmitChanges();

            
            dgKoffie.ItemsSource = db.kofsmaaks.ToList();

            
        }
    }
}
