using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Shapes;

namespace LadnyGrid
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login
    {
        #region Usuwanie z okna przycisków exit minimalize...

        //// Prep stuff needed to remove close button on window
        //private const int GWL_STYLE = -16;
        //private const int WS_SYSMENU = 0x80000;
        //[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        //private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);



        //void ToolWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // Code to remove close box from window
        //    var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
        //    SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        //}

        #endregion

        ObservableCollection<Uzytkownik> uzytkownicy = new ObservableCollection<Uzytkownik>();
        ZarzadcaBazy zb;

        public Login()
        {
           // 46.171.13.242
            //Loaded += ToolWindow_Loaded; // usuwanie przycisków - wywołanie
            InitializeComponent();
            zb = new ZarzadcaBazy();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        private void login_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           LoginText.ItemsSource = uzytkownicy;
 
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = zb.WykonajZapytanieTSQL(@"select id, login.Login, Haslo from Test.dbo.login");
            for(int i = 0; i<dataTable.Rows.Count; i++)
            {
                int id = Int32.Parse(dataTable.Rows[i][0].ToString());
                string login = dataTable.Rows[i][1].ToString();
                string haslo = dataTable.Rows[i][2].ToString();

                uzytkownicy.Add(new Uzytkownik(id, login, haslo));
            }
        }
        string[] haslo = { "81dc9bdb52d04dc20036dbd8313ed055", "c3530a3f72f21d41cacc2d68987b5a4a", "" };
        SolidColorBrush orgKolor = Brushes.Beige;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            FirstRing.IsActive = false;
            if (Logowanie())
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            // else MessageBox.Show("Zly login");
            InvalidPassword.Visibility = Visibility.Visible;
        }

        private void LoginText_GotFocus(object sender, RoutedEventArgs e)
        {
            ComboBox s = sender as ComboBox;
            InvalidPassword.Visibility = Visibility.Hidden;
           
        }

        bool Logowanie()
        {
            if (LoginText.SelectedItem == null)
                return false;

            foreach(Uzytkownik uzytkownik in uzytkownicy)
            {
                if(uzytkownik.Login.Equals(LoginText.Text))
                {
                    if(uzytkownik.Haslo.Equals(MD5Algorithm.GetHash(HasloText.Password.ToString())))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void HasloText_GotFocus(object sender, RoutedEventArgs e)
        {
            HasloLabel.Visibility = Visibility.Hidden;
            FirstRing.IsActive = true;
            InvalidPassword.Visibility = Visibility.Hidden;
        }

        
       private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                HasloText.Focus();
            }
    }

    private void HasloText_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                Button_Click(this, new RoutedEventArgs());
                kk.Background = Brushes.DarkViolet;
            }
        }

        private void HasloText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            keyinfo.Visibility = Visibility.Hidden;
            InvalidPassword.Visibility = Visibility.Hidden;
            kk.Background = orgKolor;
        }

        private void LoginText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kk.Background = orgKolor;
        }

      
    }
}
