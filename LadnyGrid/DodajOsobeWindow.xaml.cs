using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logika interakcji dla klasy DodajOsobeWindow.xaml
    /// </summary>
    public partial class DodajOsobeWindow : Window
    {
        ZarzadcaBazy zb;
        string IdOsoby;

        public DodajOsobeWindow(string id)
        {   
            InitializeComponent();
            zb = new ZarzadcaBazy();
            UzupelnijComboBoxa();
            IdOsoby = id;
            if(!id.Equals(""))
            {
                WczytajDane(id);
            }
            
        }

        bool SprawdzDane()
        {
            if (ImieText.Text.Length == 0)
                return false;
            if (NazwiskoText.Text.Length == 0)
                return false;
            if (EmailText.Text.Length == 0)
                return false;

            return true;
        }

        void UzupelnijComboBoxa()
        {
            for (int i = 0; i <= 100; i++)
            {
                WiekComboBox.Items.Add(i);
            }
            WiekComboBox.SelectedItem = 1;
        }

        void WczytajDane(string id)
        {
            try
            { 
            DataTable osoba = zb.WykonajZapytanieTSQL("select * from dbo.osoby where id  = " + id);

            string imie = osoba.Rows[0][1].ToString();
            string nazwisko = osoba.Rows[0][2].ToString();
            int wiek = Int32.Parse(osoba.Rows[0][3].ToString());
            bool wZwiazku = bool.Parse(osoba.Rows[0][4].ToString());
            string email = osoba.Rows[0][5].ToString();
            string plec = osoba.Rows[0][6].ToString();

            ImieText.Text = imie;
            NazwiskoText.Text = nazwisko;
            WiekComboBox.SelectedItem = wiek;
            wZwiazkuCheckBox.IsChecked = wZwiazku;
            EmailText.Text = email;

            if (plec.Equals("K"))
                KobietaRadioButton.IsChecked = true;
            else
                MezycznaRadioButton.IsChecked = true;
            }
            catch(Exception ex)
            {

            }
        }

        #region Funckcja Dodania nowej osoby

        bool DodajNowaOsobe()
        {
            try
            {
                int id = -1;
                Int32.TryParse(zb.WykonajZapytanieSkalar("select max(id)+1 as maxId from [Test].[dbo].[Osoby]"), out id);
                if (id > 0)
                {
                    string plec;
                    if (MezycznaRadioButton.IsChecked == true)
                        plec = "M";
                    else plec = "K";

                    if (zb.WykonajZapytanie("insert into [Test].[dbo].[Osoby] values(" + id + ",'" + ImieText.Text + "','" + NazwiskoText.Text + "'," + WiekComboBox.SelectedValue.ToString() + ",'" + wZwiazkuCheckBox.IsChecked + "','" + EmailText.Text + "','" + plec + "')"))
                        return true;
                    else
                        MessageBox.Show("Błąd podczas insertu do bazy", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    MessageBox.Show("Błąd podczas wprowadzania kolejnego ID", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas próby dodania nowej osoby do bazy", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
        #endregion

        bool EdytujOsobe()
        {
            try
            {
                string plec;
                if (MezycznaRadioButton.IsChecked == true)
                    plec = "M";
                else plec = "K";

                if (zb.WykonajZapytanie("update [Test].[dbo].[Osoby] set  imie='" + ImieText.Text + "',nazwisko='" + NazwiskoText.Text + "',wiek =" + WiekComboBox.SelectedValue.ToString() + ", wzwiazku ='" + wZwiazkuCheckBox.IsChecked + "',email ='" + EmailText.Text + "',plec ='" + plec + "' where id = " + IdOsoby))
                    return true;
                else
                {
                    MessageBox.Show("Błąd podczas update'u do bazy", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd podczas próby edytowania osoby w bazie", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzDane())
            {
                if(IdOsoby.Equals(""))
                {
                    if (DodajNowaOsobe())
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                }
               else
                {
                    if (EdytujOsobe())
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Wszystkie pola muszą być uzupełnione!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }


}
