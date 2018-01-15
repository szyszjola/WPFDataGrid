using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadnyGrid
{
    public class ZarzadcaBazy
    {

        string connectionString;
        SqlConnection polaczenie;
        public static bool IsAvailable;

        #region konstruktor
        public ZarzadcaBazy()
        {
            IsAvailable = false;
            try
            {

                string serwer = @"NB-03\SQLEXPRESS";
                string baza = "Test";
                //string uzytkownik = "ITEGER_Callbacki";
                //string haslo = "In4orm@tYka12";
                connectionString = "Data Source=" + serwer + ";Initial Catalog=" + baza + ";integrated security = true;Connect Timeout=5";
                polaczenie = new SqlConnection(@connectionString);
                IsSqlAvailable();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region procedury
        public void WykonajProcedureSql(SqlCommand pSqlCmd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    pSqlCmd.Connection = con;
                    pSqlCmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable WykonajProcedureSqlTable(SqlCommand pSqlCmd)
        {
            DataTable dt = new DataTable();
            if (IsAvailable)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            con.Open();
                            pSqlCmd.Connection = con;
                            da.SelectCommand = pSqlCmd;

                            DataSet ds = new DataSet();
                            da.Fill(ds, "wynik");

                            dt = ds.Tables["wynik"];

                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    dt = new DataTable();
                    dt.Columns.Add("Status", s.GetType());
                    dt.Columns.Add("Komunikat", s.GetType());
                    dt.Rows.Add("ERROR", s);
                }
            }
            else
            {
                string s = "Brak połączenia z bazą";
                dt = new DataTable();
                dt.Columns.Add("Status", s.GetType());
                dt.Columns.Add("Komunikat", s.GetType());
                dt.Rows.Add("ERROR", s);
            }
            return dt;
        }
        #endregion

        #region dostępność bazy
        public bool IsSqlAvailable()
        {
            try
            {
                var conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                IsAvailable = true;
                return true;
            }
            catch (Exception)
            {
                IsAvailable = false;
                return false;
            }
        }
        #endregion

        #region zwykłe zapytania SQL
        public DataTable WykonajZapytanieTSQL(string Rozkaz)
        {
            DataTable t = new DataTable();
            if (IsAvailable)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlDataAdapter DataAdapter = new SqlDataAdapter(Rozkaz, con))
                        {
                            DataAdapter.Fill(t);
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    return t;
                }
            }
            return t;
        }

        public String WykonajZapytanieSkalar(string Rozkaz)
        {
            String wynik = "";
            if (IsAvailable)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(Rozkaz, con);
                        string tmp = cmd.ExecuteScalar().ToString();
                        if (tmp != null)
                        {
                            wynik = tmp.ToString();
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            return wynik;
        }

        public bool WykonajZapytanie(string Rozkaz)
        {
            if (IsAvailable)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(Rozkaz, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    string x = ex.Message;
                    return false;
                }
            }
            else
                return false;
        }
        #endregion

    }
}
