using Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace LadnyGrid
{
    /// <summary>
    /// Logika interakcji dla klasy Tabela_Osob.xaml
    /// </summary>
    public partial class Tabela_Osob : UserControl
    {
        int countOpacityDwaPrzod = 1;
        int countOpacityPrzod = 1;
        int countOpacityCofnij = 1;
        int countOpacityDwaLewo = 1;
        int strona = 1;
        ObservableCollection<Person> Kolekcja = new ObservableCollection<Person>();
        ZarzadcaBazy zb;




        public Tabela_Osob()
        {
            InitializeComponent();
            zb = new ZarzadcaBazy();
            PokazDane();
            CofnijButton.IsEnabled = false;
            ButtonDwaLewo.IsEnabled = false;
            
            //for(int i = 0; i < 100; i++) // pętelka dodająca nową osobę
            //{
            //  dodajLosowaOsobe();
            //    Thread.Sleep(3); //śpij 3 milisekundy - pętla wykonywała się tak szybko że trzeba było dodać sen by losowanie działało
            //}
        }

        #region Sprawdzanie Danych

        void PokazDane()
        {

            DataTable dataTable = new DataTable();
            dataTable = zb.WykonajZapytanieTSQL(@"select[id]
            ,[imie]
            ,[nazwisko]
            ,[wiek]
            ,[wzwiazku]
            ,[email]
            ,[plec]
              FROM[Test].[dbo].[Osoby]
              where imie +' '+ nazwisko like '%" + Wyszukaj.Text + "%' or nazwisko+' '+imie like '%" + Wyszukaj.Text + "%'  ");

            //dataTable = zb.WykonajZapytanieTSQL(@"with CTE as (select [id],[imie],[nazwisko],[wiek],[wzwiazku],[email],[plec],(FLOOR(ROW_NUMBER() over(order by nazwisko)-1)/10) as stronaFROM [Test].[dbo].[Osoby])
            //select [id],[imie] ,[nazwisko],[wiek],[wzwiazku] ,[email],[plec] from cte where strona = " + (strona - 1)); //SPOSOB SQL - !!!

            StronaTextBlock.Content = strona.ToString();

            Kolekcja.Clear();
            //foreach (DataRow r in dataTable.Rows)
            //{
            //    int id = Int32.Parse(r[0].ToString());
            //    string imie = r[1].ToString();
            //    string nazwisko = r[2].ToString();
            //    int wiek = Int32.Parse(r[3].ToString());
            //    bool wZwiazku = bool.Parse(r[4].ToString());
            //    string email = r[5].ToString();
            //    Person.Gender plec = JakiejPlci(r[6].ToString());
            //    Kolekcja.Add(new Person(id, imie, nazwisko, wiek, wZwiazku, email, plec));
            //}

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i][0].ToString());
                string imie = dataTable.Rows[i][1].ToString();
                string nazwisko = dataTable.Rows[i][2].ToString();
                int wiek = Convert.ToInt32(dataTable.Rows[i][3]);
                bool wZwiazku = bool.Parse(dataTable.Rows[i][4].ToString());
                string email = dataTable.Rows[i][5].ToString();
                Person.Gender plec = JakiejPlci(dataTable.Rows[i][6].ToString());
                Kolekcja.Add(new Person(id, imie, nazwisko, wiek, wZwiazku, email, plec));
            }

            Tabela.ItemsSource = kolekcjaStrona(Kolekcja);
     
            //Tabela.ItemsSource = Kolekcja; // PRZY ROZWIAZANIU SQL STYKAAA
            KolumnaPlec.ItemsSource = Enum.GetValues(typeof(Person.Gender));
            maxStronaLabel.Content = (Kolekcja.Count / 10) + 1;
            Tabela.Columns[0].Visibility = Visibility.Hidden;
        }

        private ObservableCollection<Person> kolekcjaStrona(ObservableCollection<Person> bazowa)
        { 
            ObservableCollection<Person> tmp = new ObservableCollection<Person>();
            int min = (strona - 1) * 10;
            int max = (strona) * 10;
            for (int i = min; i < max; i++)
            {
                if (i < bazowa.Count)
                {
                    tmp.Add(bazowa[i]);
                }
            }

            return tmp;
        }

        Person.Gender JakiejPlci(string plec)
        {
            if (plec.Equals("K"))
                return Person.Gender.Female;
            return Person.Gender.Male;
        }

        #endregion

        #region Dodawanie Nowej Osoby

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajOsobeWindow okno = new DodajOsobeWindow("");
            this.VisualOpacity = 0.3;

            if (okno.ShowDialog() == true)
            {
                MessageBox.Show("Osoba została pomyślnie dodana", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                PokazDane();
            }
            this.VisualOpacity = 1;
        }
        #endregion

        #region Usuwanie Osoby
        private void ButtonUsun_Click(object sender, RoutedEventArgs e)
        {
            this.VisualOpacity = 0.3;
            int i = 0;
            if (CzyUsunieto(out i))
            {
                if (i == 1)
                    MessageBox.Show("Osoba została poprawnie usunięta z bazy", "Komunikat", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (i > 1)
                    MessageBox.Show("Osoby zostały poprawnie usunięte z bazy", "Komunikat", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                PokazDane();
            }
            else
                MessageBox.Show("Nie udało się usunąć!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Error);
            this.VisualOpacity = 1;
        }

        bool CzyUsunieto(out int i)
        {
            try
            {
                i = 0;
                foreach (Person person in Tabela.SelectedItems)
                {
                    int personID = person.ID;
                    zb.WykonajProcedureSql(new SqlCommand("delete from [test].[dbo].[osoby] where id = " + personID));
                    i++;
                }

                return true;
            }
            catch
            {
                i = 0;
                MessageBox.Show("Błąd wyjątku!", "Exceptetion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        #endregion

        #region Edytowanie Osoby

        private void ButtonEdytuj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.VisualOpacity = 0.3;
                Person person = (Person)Tabela.SelectedItem;
                int id = person.ID;
                DodajOsobeWindow okno = new DodajOsobeWindow(person.ID.ToString());
                if (okno.ShowDialog() == true)
                {
                    MessageBox.Show("Zedytowano osobę o ID: " + id, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    PokazDane();
                }
                this.VisualOpacity = 1;
            }
            catch { this.VisualOpacity = 1; }
        }


        #endregion

        #region Wyszukiwanie

        private void ButtonPrzod_Click(object sender, RoutedEventArgs e)
        {
            CofnijButton.IsEnabled = true;
            if (strona >= 10)
                ButtonDwaLewo.IsEnabled = true;
            if ((Math.Floor((double)Kolekcja.Count / 10)) == strona)
            {

                ButtonPrzod.IsEnabled = false;
                ButtonDwaPrzod.IsEnabled = false;
            }

            strona++;
            PokazDane();

            // Kolekcja = 15 elementów  15/10=1 
        }

        private void CofnijButton_Click(object sender, RoutedEventArgs e)
        {
            strona--;
            if (strona == 1)
                CofnijButton.IsEnabled = false;
            if (strona > 10)
                ButtonDwaLewo.IsEnabled = true;
            else
                ButtonDwaLewo.IsEnabled = false;
            ButtonPrzod.IsEnabled = true;
            PokazDane();
            if ((Math.Floor((double)Kolekcja.Count / 10) >= strona + 10))
                ButtonDwaPrzod.IsEnabled = true;
        }

        private void dodajLosowaOsobe()
        {
            string[] imiona = { "Ala", "Ola", "Bartek", "Piotr", "Jakub", "Dżej Dżej", "Ewa", "Urszula", "Kamil", "Przemysław", "Cezary", "Paweł", "Daniel", "Małgorzata", "Andrzej", "Wiesław", "Monika", "Jolanta", "Krzysztof", "Tomasz", "Michał", "Anna", "Bogusława", "Wiesław", "Tadeusz", "Izabella", "Agata" };
            string[] nazwiska = { "Brysiak", "Jastrząb", "Kotkiewicz", "Dąb", "Głąmb", "Wronko", "Baran", "Koza", "Pieseł", "Koteł", "Małpa", "Brzoza", "Radowicz", "Konieczko", "Koczilla", "Plugiewicz", "Sęp", "Cygan", "Dłuto", "Psikuta", "Zawada", "Zawieja", "Trąbka", "Bombka", "Sykieiwcz", "Budko", "Lulewicz", "Mrugała", "Grzygiewicz" };
            string[] domeny = { "gmail.com", "wp.pl", "onet.pl", "iteger.pl" };

            Random rnd = new Random(DateTime.Now.Millisecond);
            int numer = rnd.Next(0, imiona.Length);
            string imie = imiona[numer];
            numer = rnd.Next(0, nazwiska.Length);
            string nazwisko = nazwiska[numer];
            int wiek = rnd.Next(1, 99);
            string plec = "K";
            if (!imie.Substring(imie.Length - 1).Equals("a"))
                plec = "M";
            bool wZwiazku = true;
            if (rnd.Next(0, 100) >= 50)
                wZwiazku = false;

            numer = rnd.Next(0, domeny.Length);
            int id = -1;
            Int32.TryParse(zb.WykonajZapytanieSkalar("select max(id)+1 as maxId from [Test].[dbo].[Osoby]"), out id);
            string eMail = imie.Replace(" ", "") + "." + nazwisko + rnd.Next(1, 999) + "@" + domeny[numer];
            zb.WykonajZapytanie("insert into [Test].[dbo].[Osoby] values(" + id + ",'" + imie + "','" + nazwisko + "'," + wiek + ",'" + wZwiazku + "','" + eMail + "','" + plec + "')");
        }

        private void Wyszukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonPrzod.IsEnabled = false;
            CofnijButton.IsEnabled = false;
            ButtonDwaPrzod.IsEnabled = false;
            ButtonDwaLewo.IsEnabled = false;

            strona = 1;
            PokazDane();
            if ((Math.Floor((double)Kolekcja.Count / 10)) >= strona)
            {
                ButtonPrzod.IsEnabled = true;

            }
            if ((Math.Floor((double)Kolekcja.Count / 10)) > strona + 10)
            {
                ButtonDwaPrzod.IsEnabled = true;

            }


            maxStronaLabel.Content = (Kolekcja.Count / 10) + 1;
        }

        private void ButtonDwaPrzod_Click(object sender, RoutedEventArgs e)
        {
            CofnijButton.IsEnabled = true;
            ButtonDwaLewo.IsEnabled = true;


            if ((Math.Floor((double)Kolekcja.Count / 10)) == strona)
            {
                ButtonPrzod.IsEnabled = false;

            }
            double a = Math.Floor((double)Kolekcja.Count / 10);
            if ((Math.Floor((double)Kolekcja.Count / 10)) <= strona + 19)
            {
                ButtonDwaPrzod.IsEnabled = false;

            }
            strona += 10;
            PokazDane();

        }

        private void ButtonDwaPrzod_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (countOpacityDwaPrzod % 2 == 0)
                ButtonDwaPrzod.Opacity = 1;
            else ButtonDwaPrzod.Opacity = 0.4;

            countOpacityDwaPrzod++;
        }

        private void ButtonPrzod_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (countOpacityPrzod % 2 == 0)
                ButtonPrzod.Opacity = 1;
            else ButtonPrzod.Opacity = 0.4;

            countOpacityPrzod++;
        }

        private void CofnijButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (countOpacityCofnij % 2 == 0)
                CofnijButton.Opacity = 1;
            else CofnijButton.Opacity = 0.4;

            countOpacityCofnij++;
        }


        private void ButtonDwaLewo_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (countOpacityDwaLewo % 2 == 0)
                ButtonDwaLewo.Opacity = 1;
            else ButtonDwaLewo.Opacity = 0.4;

            countOpacityDwaLewo++;
        }

        private void ButtonDwaLewo_Click(object sender, RoutedEventArgs e)
        {
            CofnijButton.IsEnabled = true;

            if ((Math.Floor((double)Kolekcja.Count / 10)) == strona)
            {
                ButtonPrzod.IsEnabled = false;

            }
            double a = Math.Floor((double)Kolekcja.Count / 10);
            if ((Math.Floor((double)Kolekcja.Count / 10)) <= strona + 19)
            {
                ButtonDwaPrzod.IsEnabled = false;


            }
            strona -= 10;
            PokazDane();
            ButtonDwaLewo.IsEnabled = false;
            if (strona > 10)
                ButtonDwaLewo.IsEnabled = true;
            if (strona == 1)
                CofnijButton.IsEnabled = false;
            ButtonDwaPrzod.IsEnabled = true;

        }
        private void lupka_Click(object sender, RoutedEventArgs e)
        {
            Wyszukaj.Focus();
        }



        #endregion


        Microsoft.Office.Interop.Excel.Application excel = null;
        Microsoft.Office.Interop.Excel.Workbook workbook = null;
        Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

        private void ButtonExportuj_Click(object sender, RoutedEventArgs e)
        {
            Tabela.ItemsSource = Kolekcja;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                //excel.ScreenUpdating = false;
                workbook = excel.Workbooks.Add();
                worksheet = workbook.Sheets[1];
                int wiersze = Tabela.Items.Count;
                int kolumny = Tabela.Columns.Count;


                for (int kolumna = 0; kolumna < kolumny; ++kolumna)
                {
                    worksheet.Cells[1, kolumna + 1].Value = Tabela.Columns[kolumna].Header;
                }

                for (int wiersz = 0; wiersz < wiersze; wiersz++)
                {
                    Person p = (Person)Tabela.Items[wiersz];
                    worksheet.Cells[wiersz + 2, 1].Value = p.ID.ToString();
                    worksheet.Cells[wiersz + 2, 2].Value = p.Name;
                    worksheet.Cells[wiersz + 2, 3].Value = p.Surname;
                    worksheet.Cells[wiersz + 2, 4].Value = p.Age.ToString();
                    worksheet.Cells[wiersz + 2, 5].Value = p.Engaged.ToString();
                    worksheet.Cells[wiersz + 2, 6].Value = p.Email;
                    worksheet.Cells[wiersz + 2, 7].Value = p.getSexString();
                }
                PokazDane();
                excel.Visible = true;
                //worksheet.Range["A2"].Resize[wiersze, kolumny].Value = tablica;
                worksheet.Columns[6].ColumnWidth = 55;
                excel.ScreenUpdating = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }



        //private void ZapiszDoExcel()
        //{
        //    SaveFileDialog dialog = new SaveFileDialog();
        //    if (dialog.ShowDialog() == true)
        //    {
        //        FileStream stream = File.Open(dialog.FileName, FileMode.Append, FileAccess.Write);

        //        if (openFileDialog1.FileName.Contains(".xlsx"))
        //            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //        else  //xls
        //            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //        tabeleExcel = excelReader.AsDataSet();

        //        excelReader.Close();
        //        listView1.Clear();
        //        for (int i = 0; i < tabeleExcel.Tables.Count; i++)
        //        {
        //            listView1.Items.Add(tabeleExcel.Tables[i].TableName);
        //        }
        //    }

        //}

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {

        }
        

        private void resultDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.VisualOpacity = 0.3;
                Person person = (Person)Tabela.SelectedItem;
                int id = person.ID;
                DodajOsobeWindow okno = new DodajOsobeWindow(person.ID.ToString());
                if (okno.ShowDialog() == true)
                {
                    MessageBox.Show("Zedytowano osobę o ID: " + id, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    PokazDane();
                }
            }
            catch (Exception ex)
            {
            }
            this.VisualOpacity = 1;
        }

    }
    public  class EngagedTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WZwiazkuTemplate { get; set; }
        public DataTemplate NieWZwiazkuTemplate { get; set; }

      
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Person person = item as Person;

            if (person.Engaged == true)
                return WZwiazkuTemplate;

            return NieWZwiazkuTemplate;
        }
    }
}



