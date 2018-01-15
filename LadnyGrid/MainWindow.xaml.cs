using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Threading;
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;

namespace LadnyGrid
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<KalendarzDat> czasowaKolekcja = new ObservableCollection<KalendarzDat>();
        ZarzadcaBazy zb; //do kalendarz
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();



        public MainWindow()
        {
            InitializeComponent();
            zb = new ZarzadcaBazy();
            CzasLabel.Content = DateTime.Now;
            PokazDane();
            Zegar();
            ButtonRezerwuj.IsEnabled = false; //kalendarz
          
         

        }

        #region Ustawienia Czasu
        void Zegar()
        {
            DispatcherTimer czas = new DispatcherTimer();
            czas.Start();
            czas.Interval = TimeSpan.FromMilliseconds(1000);
            czas.Tick += OdswiezCzas;
        }

        private void OdswiezCzas(object sender, EventArgs e)
        {
            CzasLabel.Content = DateTime.Now;


        }
        #endregion

        #region ZAKŁADKA KALENDARZ

        void PokazDane()
        {
            
            DataTable dataTableCzas = new DataTable();
            dataTableCzas = zb.WykonajZapytanieTSQL("select * from dbo.datyy order by daty");

            czasowaKolekcja.Clear();
            foreach (DataRow r in dataTableCzas.Rows)
            {
               
                int id = Int32.Parse(r[0].ToString());
                DateTime data = DateTime.Parse(r[1].ToString());
                bool rezerwacja = bool.Parse(r[2].ToString());
                string opis = r[3].ToString();

                if (rezerwacja == true) //wyczarnianie kalendarza
                {   try
                    {
                        Kalendarzyk.BlackoutDates.Add(new CalendarDateRange(data));
                    }
                    catch { };
                   
                }

                czasowaKolekcja.Add(new KalendarzDat(id, data, opis));

            }

            DatyGrida.ItemsSource = czasowaKolekcja;
        }


        private void ButtonRezerwuj_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.3;
            DateTime zaznaczonaData = (DateTime)Kalendarzyk.SelectedDate;
            OknoDodajDate oknoDaty = new OknoDodajDate(zaznaczonaData);
            if (oknoDaty.ShowDialog() == true)
            {
             
                PokazDane();
                MessageBox.Show("Dodano nowy wpis", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            this.Opacity = 1;

            //if (kalendarzyk.selecteddate.hasvalue)
            //{
            //    selecteddatescollection kolekcjaselectdates = kalendarzyk.selecteddates;

            //    try
            //    {
            //        if (kalendarzyk.selecteddate == null) return;
            //        datetime dtbo = (datetime)kalendarzyk.selecteddate;
            //        kalendarzyk.selecteddate = null;
            //    }  kalendarzyk.blackoutdates.add(new calendardaterange(dtbo));
            //  catch (exception ex)
            //    {
            //        messagebox.show(ex.tostring());
            //    }
            //}


            }

        private void Kalendarzyk_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonRezerwuj.IsEnabled = true;
        }

        private void Kalendarzyk_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Kalendarzyk.SelectedDate != null)
                {
                    this.Opacity = 0.3;
                    DateTime zaznaczonaData = (DateTime)Kalendarzyk.SelectedDate;
                    OknoDodajDate oknoDaty = new OknoDodajDate(zaznaczonaData);
                    if (oknoDaty.ShowDialog() == true)
                    {

                        PokazDane();
                        MessageBox.Show("Dodano nowy wpis", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    this.Opacity = 1;
                }
            }
            catch { };
        }

#endregion

        private void Otworz_Click(object sender, RoutedEventArgs e)
        {
            string plik = "";
            RichBox.Document.Blocks.Clear();
         
            if (openFileDialog.ShowDialog() == true)
            {            
                plik = openFileDialog.FileName;
                #region wczytywanie ze streamreadera
                StreamReader reader = new StreamReader(plik, Encoding.Default);
                while (!reader.EndOfStream)
                {
                    RichBox.Document.Blocks.Add(new Paragraph(new Run(reader.ReadLine())));
                }
                reader.Close();
                #endregion
                #region Wczytywanie po linii z File
                //ContentRichBoxa.Text = File.ReadAllText(plik,Encoding.Default); //wczytywanie wsioooo za jednym zamachem
                // string[] osoba;
                ////string[] linie = File.ReadAllLines(plik, Encoding.Default);
                ////for (int i = 0; i < linie.Length; i++)
                ////{
                ////    osoba = linie[i].Split(' ');

                ////    for (int j = 0; j < osoba.Length; j++)
                ////    {
                ////        ContentRichBoxa.Text += osoba[j] + " ";
                ////    }
                ////    ContentRichBoxa.Text += "\n";

                ////}


                /// /// wczytywanie z streaamaaa 
                ///                     //calosc = reader.ReadLine().Split(' ');
                //for (int i = 0; i < calosc.Length; i++) //{

                // RichBox.Document.Blocks.Add(new Paragraph(new Run(calosc[i])));
                //}
                //  ContentRichBoxa.Text += "\n";
                #endregion

            }
        }

        #region Zapisywanie do Rich Boca

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {

            string plik = "";
            if (saveFileDialog.ShowDialog() == true)
            {
                plik = saveFileDialog.FileName;
                string richText = new TextRange(RichBox.Document.ContentStart, RichBox.Document.ContentEnd).Text;
                StreamWriter writer = new StreamWriter(plik, false, Encoding.Default);
                writer.WriteLine(richText);
                writer.Close();
            }
        }

#endregion



        private void ButtonPokazDaty_Click(object sender, RoutedEventArgs e)
        {

            DateTime dateStart = (DateTime) DatePickerStart.SelectedDate;
            DateTime dateEnd = (DateTime)DatePickerEnd.SelectedDate;
            string dateStartstring = String.Format("{0:yyyy-MM-dd}", dateStart);
            string dateEndstring = String.Format("{0:yyyy-MM-dd}", dateEnd);
            DataTable dataTableCzas = new DataTable();
            //dataTableCzas = zb.WykonajZapytanieTSQL("select * from Test.dbo.datyy where daty between convert(date,'" + DatePickerStart.SelectedDate  +"', 120) and convert(date,'" + DatePickerEnd.SelectedDate + "',120)  order by daty");
            dataTableCzas = zb.WykonajZapytanieTSQL("select * from Test.dbo.datyy where daty between '" + dateStartstring + "' and '" + dateEndstring  + "' order by daty");
            czasowaKolekcja.Clear();
            foreach (DataRow r in dataTableCzas.Rows)
            {

                int id = Int32.Parse(r[0].ToString());
                DateTime data = DateTime.Parse(r[1].ToString());
                bool rezerwacja = bool.Parse(r[2].ToString());
                string opis = r[3].ToString();

                if (rezerwacja == true) //wyczarnianie kalendarza
                {
                    try
                    {
                        Kalendarzyk.BlackoutDates.Add(new CalendarDateRange(data));
                    }
                    catch(Exception ex)
                    {
                        string t = ex.Message;
                    };

                }

                czasowaKolekcja.Add(new KalendarzDat(id, data, opis));

            }

            DatyGrida.ItemsSource = czasowaKolekcja;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TestTabItem.IsSelected)
            {
                testowyUser testy = new testowyUser();
                Rodzic.Children.Add(testy);


            }
        }


        #region Modyfikacja zachowań okna (książka)

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Czy na pewno chcesz zakończyć pracę programu?", "Komunikat", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                e.Cancel = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            /// Zapisanie postępów aplikacji
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            //Pobranie zapisanych postępów
        }

        #endregion


    }
}

