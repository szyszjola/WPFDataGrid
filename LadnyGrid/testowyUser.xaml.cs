using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for testowyUser.xaml
    /// </summary>
    public partial class testowyUser : UserControl
    {
        ZarzadcaBazy zb;
        int id;

        public testowyUser()
        {
            InitializeComponent();
            zb = new ZarzadcaBazy();
        }

        bool CzyDanyLoginIstnieje()
        {
            try
            {
                int id = 0;
                Int32.TryParse(zb.WykonajZapytanieSkalar("select id from Test.dbo.login where Login = '" + PodajLoginTxt.Text + "'"), out id);
                if (id != 0)
                {
                    zlelogin.Visibility = Visibility.Visible;
                    zlelogin.ToolTip = "Dany login jest już zajęty!";
                    ZatwierdzButton.IsEnabled = false;
                    return true;
                }
                else
                {
                    zlelogin.Visibility = Visibility.Collapsed;
                    return false;
                }         
            }
            catch { return false; }
        }

        bool DodajUzytkownika()
        {
            try
            {
                int id = -1;
                Int32.TryParse(zb.WykonajZapytanieSkalar("select max(id)+1 from Test.dbo.login"), out id);
                if (id > 0)
                {
                    if (zb.WykonajZapytanie("insert into Test.dbo.login values(" + id + ",'" + PodajLoginTxt.Text + "','" + MD5Algorithm.GetHash(PodajHasloTxt.Password.ToString()) + "')"))
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private void ZatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if (DodajUzytkownika())
            {
                MessageBox.Show("Dodano Użytkownika");
            }
            PodajLoginTxt.Clear();
            PodajHasloTxt.Clear();
            PowtorzHasloTxt.Clear();
        }

        private void PodajLoginTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PodajLoginTxt.Text.Length < 3)
            {
                zlelogin.Visibility = Visibility.Visible;
 
            }
                if (PokazButtonZatwierdz())
                {
                    ZatwierdzButton.IsEnabled = true;
                }
                else
                {
                    ZatwierdzButton.IsEnabled = false;
                }
        }

        private void PodajHasloTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PodajHasloTxt.Password.Length >= 8)
            {
                if (!Regex.IsMatch(PodajHasloTxt.Password.ToString(), @"^(?=.*[A-Z])(?=.*[!@_+^#$&*])(?=.*[0-9])(?=.*[a-z]).{8,}$"))
                {
                    zlehaslo.Visibility = Visibility.Visible;
                    zlehaslo.ToolTip = "Hasło musi zawierać przynajmniej jedną małą literę,jedną dużą, jedną cyfrę oraz jeden znak specjalny (!@_+^#$&*) ";
                }
                /* ^
                 * (?=.*[A-Z])  na pewno duża
                 * (?=.*[!@-_+^#$&*]) na pewno raz specjalny znak
                 *(?=.*[0-9]) na pewno jedna cyfra             (?=.*[0-9].*[0-9]) na pewno dwie cyfry
                 * (?=.*[a-z]) na pewno ma jedną małą cyfre
                 * .{8}$
                 */ //Giermek0#
                    //Dsf44&Sa
                else
                {
                    ZatwierdzButton.IsEnabled = false;
                }
            }
            else
            {
                zlehaslo.Visibility = Visibility.Visible;
                zlehaslo.ToolTip = "Hasło musi składać się co najmniej z 8 znaków";
            }
            if (!PowtorzHasloTxt.Password.Equals(PodajHasloTxt.Password))
            {
                zlepowtorzhaslo.Visibility = Visibility.Visible;
                correcthaslo.Visibility = Visibility.Collapsed;
            }
            else zlepowtorzhaslo.Visibility = Visibility.Collapsed;

            if (PokazButtonZatwierdz())
            {
                ZatwierdzButton.IsEnabled = true;
            }
            else
            {
                ZatwierdzButton.IsEnabled = false;
            }
        }

        private bool PokazButtonZatwierdz()
        {
            if (PodajLoginTxt.Text.Length >= 3)
            {
                if(!CzyDanyLoginIstnieje())
                {
                    if (PodajHasloTxt.Password.Length >= 8 && Regex.IsMatch(PodajHasloTxt.Password.ToString(), @"^(?=.*[A-Z])(?=.*[!@-_+^#$&*])(?=.*[0-9])(?=.*[a-z]).{8,}$"))
                    {
                        if (PowtorzHasloTxt.Password.Equals(PodajHasloTxt.Password))
                        {
                            correcthaslo.Visibility = Visibility.Visible;
                            return true;
                        }
                    }
                }  
            }
            correcthaslo.Visibility = Visibility.Collapsed;
            return false;
        }

        private void PodajHasloTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            zlehaslo.Visibility = Visibility.Collapsed;

            if (PokazButtonZatwierdz())
            {
                ZatwierdzButton.IsEnabled = true;
            }
            else
            {
                ZatwierdzButton.IsEnabled = false;
            }
        }

        private void PodajLoginTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            zlelogin.Visibility = Visibility.Hidden;
 
            if (PokazButtonZatwierdz())
            {
                ZatwierdzButton.IsEnabled = true;
            }
            else
            {
                ZatwierdzButton.IsEnabled = false;
            }

        }

        private void PowtorzHasloTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            zlepowtorzhaslo.Visibility = Visibility.Collapsed;

            if (PokazButtonZatwierdz())
            {
                ZatwierdzButton.IsEnabled = true;
            }
            else
            {
                ZatwierdzButton.IsEnabled = false;
            }
        }

        private void PowtorzHasloTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!PowtorzHasloTxt.Password.Equals(PodajHasloTxt.Password))
            {
                zlepowtorzhaslo.Visibility = Visibility.Visible;
            }

            if (PokazButtonZatwierdz())
            {
                ZatwierdzButton.IsEnabled = true;
            }
            else
            {
                ZatwierdzButton.IsEnabled = false;
            }
        }
    }
}
//metroapijuju