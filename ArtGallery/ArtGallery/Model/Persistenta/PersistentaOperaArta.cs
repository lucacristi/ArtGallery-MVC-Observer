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
    public class PersistentaOperaArta
    {
        private SqlConnection connection;

        public PersistentaOperaArta()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Opere"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public bool AdaugareOperaArta(OperaArta operaArta)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand query = getInsertSqlCommand(operaArta);
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

        public bool StergereOperaArta(string titlu, string numeArtist)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand query = getRemoveSqlCommand(titlu, numeArtist);
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

        public bool ActualizareOperaArta(string titlu, OperaArta operaArta)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand query = getUpdateSqlCommand(titlu, operaArta);
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

        public List<OperaArta> ListareOpere()
        {
            List<OperaArta> opereArta = new List<OperaArta>();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand query = new SqlCommand("Select * from OperaArta order by [Titlu Opera]", connection);

                SqlDataAdapter dateCitite = new SqlDataAdapter(query);
                DataTable tabelOpere = new DataTable();
                dateCitite.Fill(tabelOpere);
                connection.Close();
                return conversie(tabelOpere);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare vizualizare");
                return null;
            }
        }

        public List<OperaArta> FiltrareOpereTip(string tipOpera)
        {
            return filtrareOpere("Tip Opera", tipOpera);
        }

        public List<OperaArta> FiltrareOpereTitlu(string titluOpera)
        {
            return filtrareOpere("Titlu Opera", titluOpera);
        }

        public List<OperaArta> FiltrareOpereArtist(string numeArtist)
        {
            return filtrareOpere("Nume Artist", numeArtist);
        }

        public List<OperaArta> FiltrareOpereAn(string anRealizare)
        {
            return filtrareOpere("An Realizare", anRealizare);
        }

        public List<OperaArta> FiltrareOpereGenPictura(string genPictura)
        {
            return filtrareOpere("Gen Pictura", genPictura);
        }

        public List<OperaArta> FiltrareOpereTehnicaPictura(string tehnicaPictura)
        {
            return filtrareOpere("Tehnica Pictura", tehnicaPictura);
        }

        public List<OperaArta> FiltrareOpereTipSculptura(string tipSculptura)
        {
            return filtrareOpere("Tip Sculptura", tipSculptura);
        }

        public OperaArta CautaOpera(string titluOpera)
        {
            List<OperaArta> opere = filtrareOpere("Titlu Opera", titluOpera);
            if(opere.Count == 0)
            {
                return null;
            }
            return opere[0];
        }


        private SqlCommand getInsertSqlCommand(OperaArta operaArta)
        {
            SqlCommand query = null;
            if (operaArta is Tablou)
            {
                Tablou tablou = (Tablou)operaArta;
                query = new SqlCommand("insert into OperaArta values('Tablou','" + tablou.GetTitlu() + "','" + tablou.GetNumeArtist() + "','" + tablou.GetAnRealizare() + "','" + tablou.GetGenPictura() + "','" + tablou.GetTehnica() + "','')", connection);
            }
            else if (operaArta is Sculptura)
            {
                Sculptura sculptura = (Sculptura)operaArta;
                query = new SqlCommand("insert into OperaArta values('Sculptura','" + sculptura.GetTitlu() + "','" + sculptura.GetNumeArtist() + "','" + sculptura.GetAnRealizare() + "','','','" + sculptura.GetTip() + "')", connection);

            }
            else if (operaArta is OperaArta)
            {
                query = new SqlCommand("insert into OperaArta values('Opera de Arta','" + operaArta.GetTitlu() + "','" + operaArta.GetNumeArtist() + "','" + operaArta.GetAnRealizare() + "','','','')", connection);
            }


            return query;
        }
        private SqlCommand getRemoveSqlCommand(string titlu, string numeArtist)
        {
            SqlCommand query = new SqlCommand("delete from OperaArta where [Titlu Opera]='" + titlu + "' AND [Nume Artist]='" + numeArtist + "'", connection);

            return query;
        }
        private SqlCommand getUpdateSqlCommand(string titlu, OperaArta operaArta)
        {
            SqlCommand query = null;

            if (operaArta is Tablou)
            {
                Tablou tablou = (Tablou)operaArta;
                query = new SqlCommand("update OperaArta set [Titlu Opera]='" + tablou.GetTitlu() + "', [Nume Artist] ='" + tablou.GetNumeArtist() + "', [An Realizare] = '" + tablou.GetAnRealizare() + "', [Gen Pictura] ='" + tablou.GetGenPictura() + "', [Tehnica Pictura] ='" + tablou.GetTehnica() + "' where [Titlu Opera] ='" + titlu + "'", connection);
            }
            else if (operaArta is Sculptura)
            {
                Sculptura sculptura = (Sculptura)operaArta;
                query = new SqlCommand("update OperaArta set [Titlu Opera]='" + sculptura.GetTitlu() + "', [Nume Artist] ='" + sculptura.GetNumeArtist() + "', [An Realizare] = '" + sculptura.GetAnRealizare() + "', [Tip Sculptura] ='" + sculptura.GetTip() + "' where [Titlu Opera] ='" + titlu + "'", connection);
            }
            else if (operaArta is OperaArta)
            {
                query = new SqlCommand("update OperaArta set [Titlu Opera]='" + operaArta.GetTitlu() + "', [Nume Artist] ='" + operaArta.GetNumeArtist() + "', [An Realizare] = '" + operaArta.GetAnRealizare() + "' where [Titlu Opera] ='" + titlu + "'", connection);
            }

            return query;
        }
        private List<OperaArta> conversie(DataTable opere)
        {
            List<OperaArta> lista = new List<OperaArta>();

            foreach (DataRow dataRow in opere.Rows)
            {
                OperaArta operaArta = null;

                string tipOpera = (string)dataRow["Tip Opera"];
                string titluOpera = (string)dataRow["Titlu Opera"];
                string numeArtist = (string)dataRow["Nume Artist"];
                int anRealizare = (int)dataRow["An Realizare"];


                if (tipOpera.Equals("Tablou"))
                {
                    string genPictura = (string)dataRow["Gen Pictura"];
                    string tehnicaPictura = (string)dataRow["Tehnica Pictura"];

                    operaArta = new Tablou(titluOpera, numeArtist, anRealizare, genPictura, tehnicaPictura);
                }
                else if (tipOpera.Equals("Sculptura"))
                {
                    string tipSculptura = (string)dataRow["Tip Sculptura"];

                    operaArta = new Sculptura(titluOpera, numeArtist, anRealizare, tipSculptura);
                }
                else if (tipOpera.Equals("Opera de Arta"))
                {
                    operaArta = new OperaArta(titluOpera, numeArtist, anRealizare);
                }

                lista.Add(operaArta);
            }
            return lista;
        }
        private List<OperaArta> filtrareOpere(string criteriu, string informatie)
        {
            try
            {
                List<OperaArta> opere = new List<OperaArta>();
                SqlCommand query = null;

                switch (criteriu)
                {
                    case "Tip Opera":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                    case "Titlu Opera":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                    case "Nume Artist":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                    case "An Realizare":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                    case "Gen Pictura":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                    case "Tehnica Pictura":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                    case "Tip Sculptura":
                        query = new SqlCommand("Select * from OperaArta where [" + criteriu + "] = '" + informatie + "'", connection);
                        break;
                }

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlDataAdapter dateCitite = new SqlDataAdapter(query);
                DataSet dataSet = new DataSet();
                dateCitite.Fill(dataSet, "vizualizareOpere");
                DataTable opereTabel = dataSet.Tables["vizualizareOpere"];
                connection.Close();
                return conversie(opereTabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare cautare dupa " + criteriu);
                return null;
            }
        }
    }
}
