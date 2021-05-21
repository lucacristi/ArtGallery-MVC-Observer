using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ArtGallery.Model.Persistenta
{
    public class PersistentaUtilizatori
    {

        private SqlConnection connection;

        public PersistentaUtilizatori()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Opere"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public bool AdaugareUtilizator(Utilizator utilizator)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand query = getInsertSqlCommand(utilizator);
                if (query.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare Adaugare");
                return false;
            }
        }

        public bool StergereUtilizator(string username)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand query = getRemoveSqlCommand(username);
                if (query.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare Stergere");
                return false;
            }
        }

        public bool ActualizareUtilizator(string username, Utilizator utilizator)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand query = getUpdateSqlCommand(username, utilizator);
                if (query.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare Actualizare");
                return false;
            }
        }

        public List<Utilizator> ListareUtilizatori()
        {
            List<Utilizator> utilizatori = new List<Utilizator>();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand query = new SqlCommand("Select * from Users order by [Username]", connection);

                SqlDataAdapter dateCitite = new SqlDataAdapter(query);
                DataTable tabelUtilizatori = new DataTable();
                dateCitite.Fill(tabelUtilizatori);
                connection.Close();
                return conversie(tabelUtilizatori);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare vizualizare");
                return null;
            }
        }

        public Utilizator CautaUtilizator(string username)
        {
            List<Utilizator> utilizatori = filtrareUtilizatori("Username", username);
            if (utilizatori.Count == 0)
            {
                return null;
            }
            return utilizatori[0];
        }

        public List<Utilizator> FiltrareUtilizatoriUsername(string usernameUtilizator)
        {
            return filtrareUtilizatori("Username", usernameUtilizator);
        }

        public List<Utilizator> FiltrareUtilizatoriTip(string tipUtilizator)
        {
            return filtrareUtilizatori("TipUtilizator", tipUtilizator);
        }        


        private SqlCommand getInsertSqlCommand(Utilizator utilizator) {  
            return new SqlCommand("insert into Users values('" + utilizator.GetUsername() + "','" + utilizator.GetPassword() + "','" + utilizator.GetTipUtilizator() + "')", connection); ;
        }
        private SqlCommand getRemoveSqlCommand(string username)
        { 
            return new SqlCommand("delete from Users where [Username]='" + username + "'", connection);
        }
        private SqlCommand getUpdateSqlCommand(string username, Utilizator utilizator)
        {
            return new SqlCommand("update Users set [Username]='" + utilizator.GetUsername() + "', [Password] ='" + utilizator.GetPassword() + "', [TipUtilizator] = '" + utilizator.GetTipUtilizator() + "' where [Username] ='" + username + "'", connection);
        }
        private List<Utilizator> conversie(DataTable utilizatori)
        {
            List<Utilizator> lista = new List<Utilizator>();

            foreach (DataRow dataRow in utilizatori.Rows)
            {
                Utilizator utilizator = new Utilizator((string)dataRow["Username"], (string)dataRow["Password"], (string)dataRow["TipUtilizator"]);         
                lista.Add(utilizator);
            }
            return lista;
        }
        private List<Utilizator> filtrareUtilizatori(string criteriu, string informatie)
        {
            try
            {
                List<Utilizator> utilizatori = new List<Utilizator>();
                SqlCommand query = null;

                switch (criteriu)
                {
                    case "Username":
                        query = new SqlCommand("Select * from Users where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;                    
                    case "TipUtilizator":
                        query = new SqlCommand("Select * from Users where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                }

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlDataAdapter dateCitite = new SqlDataAdapter(query);
                DataSet dataSet = new DataSet();
                dateCitite.Fill(dataSet, "vizualizareUtilizatori");
                DataTable utilizatoriTabel = dataSet.Tables["vizualizareUtilizatori"];
                connection.Close();
                return conversie(utilizatoriTabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare cautare dupa " + criteriu);
                return null;
            }
        }
    }
}
