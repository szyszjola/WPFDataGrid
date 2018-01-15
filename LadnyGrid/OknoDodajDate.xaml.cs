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

namespace LadnyGrid
{
    /// <summary>
    /// Logika interakcji dla klasy OknoDodajDate.xaml
    /// </summary>
    public partial class OknoDodajDate : Window
    {
        ZarzadcaBazy zb;
        DateTime wybranaData = new DateTime(2017, 9, 12);

        public OknoDodajDate(DateTime data)
        {
            zb = new ZarzadcaBazy();
            InitializeComponent();
            Przypisz(out wybranaData, data);
             
        }

        void Przypisz(out DateTime wybranaData, DateTime data)
        {
            wybranaData = data;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (Dodajto(wybranaData))
            {
                this.DialogResult = true;
                this.Close();
            }
           
           
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        bool Dodajto(DateTime dataWybrana)
        {
            string dacior = dataWybrana.ToShortDateString();
            dacior.Replace('.', '/');
            string dzien = dacior.Substring(0, 2);
            string miesiac = dacior.Substring(3, 2);
            string rok = dacior.Substring(6, 4);
            string wyszlo = rok + "-" + miesiac + "-" + dzien;
            try
            {
                if (OpisText.Text.Length == 0)
                    return false;

                int id = -1;
                Int32.TryParse(zb.WykonajZapytanieSkalar("select max(id)+1 as maxId from [Test].[dbo].[datyy]"), out id);
                if (id > 0)
                {
                    //if (zb.WykonajZapytanie("insert into [dbo].[datyy] values( " + id + ",PARSE(" + dataWybrana + "AS DATE USING 'pl-PL')," + 1 + ",'" + OpisText.Text + "')"))
                    //    return true;
                    if (zb.WykonajZapytanie("insert into [dbo].[datyy] values( " + id + ",'" + wyszlo + "'," + 1 + ",'" + OpisText.Text + "')"))
                        return true;
                    else
                    {
                        MessageBox.Show("Błąd podczas insertu do bazy", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                      
                }
                else
                {
                    MessageBox.Show("Błąd podczas wprowadzania kolejnego ID", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Błąd podczas próby dodania nowej daty do bazy", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

       
    }
}
