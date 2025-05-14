using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsCurrenciesData
    {

        static public DataTable GetAllCurrencies()
        {
            DataTable dtCurrenciesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM Currencies;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtCurrenciesList.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dtCurrenciesList;
        }

        static public bool GetCurrencyInfoByID(int CurrencyID, ref string CurrencyName, ref string Currency, ref string CurrencySymbol, ref Double ExchangeRatePerUSD)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Currencies WHERE CurrencyID =@CurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CurrencyName = (string)Reader["CurrencyName"];
                    Currency = (string)Reader["Currency"];
                    CurrencySymbol = (string)Reader["CurrencySymbol"];
                    ExchangeRatePerUSD = (Double)Reader["ExchangeRatePerUSD"];


                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }

        static public bool GetCurrencyInfoByID(ref int CurrencyID, ref string CurrencyName, string Currency, ref string CurrencySymbol, ref Double ExchangeRatePerUSD)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Currencies WHERE Currency =@Currency;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Currency", Currency);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CurrencyName = (string)Reader["CurrencyName"];
                    CurrencyID = (int)(byte)Reader["CurrencyID"];
                    CurrencySymbol = (string)Reader["CurrencySymbol"];
                    ExchangeRatePerUSD = (Double)Reader["ExchangeRatePerUSD"];


                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }


        static public bool GetCurrencyInfoByCurrency(ref int CurrencyID, ref string CurrencyName,  string Currency, ref string CurrencySymbol, ref Double ExchangeRatePerUSD)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Currencies WHERE Currency =@Currency;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Currency", Currency);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    CurrencyID = (int)(byte)Reader["CurrencyID"];
                    CurrencyName = (string)Reader["CurrencyName"];
                    CurrencySymbol = (string)Reader["CurrencySymbol"];
                    ExchangeRatePerUSD = (Double)Reader["ExchangeRatePerUSD"];


                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }
       
        static public int AddNewCurrency(string CurrencyName, string Currency, string CurrencySymbol, Double ExchangeRatePerUSD)
        {
            int CurrencyID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Currencies
                                         (CurrencyName, Currency, CurrencySymbol, ExchangeRatePerUSD)
                                   VALUES
                                         (@CurrencyName, @Currency, @CurrencySymbol, @ExchangeRatePerUSD);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            Command.Parameters.AddWithValue("@Currency", Currency);
            Command.Parameters.AddWithValue("@CurrencySymbol", CurrencySymbol);
            Command.Parameters.AddWithValue("@ExchangeRatePerUSD", ExchangeRatePerUSD);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    CurrencyID = ID;
                }
            }
            catch (Exception ex)
            {
                CurrencyID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return CurrencyID;
        }

        static public bool UpdateCurrency(int CurrencyID, string CurrencyName, string Currency, string CurrencySymbol, Double ExchangeRatePerUSD)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Currencies 
SET CurrencyName = @CurrencyName
, Currency = @Currency
, CurrencySymbol = @CurrencySymbol
, ExchangeRatePerUSD = @ExchangeRatePerUSD
WHERE CurrencyID = @CurrencyID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            Command.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            Command.Parameters.AddWithValue("@Currency", Currency);
            Command.Parameters.AddWithValue("@CurrencySymbol", CurrencySymbol);
            Command.Parameters.AddWithValue("@ExchangeRatePerUSD", ExchangeRatePerUSD);


            try
            {
                Connection.Open();
                RowsEfacts = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return RowsEfacts > 0;
        }

        static public bool DeleteCurrency(int CurrencyID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Currencies WHERE CurrencyID = @CurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                Connection.Open();
                RowsEfacts = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowsEfacts > 0;
        }

        static public bool IsCurrencyExist(int CurrencyID)
        {
            bool IsCurrencyExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Currencies WHERE CurrencyID = @CurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsCurrencyExist = true;
                }
            }
            catch (Exception ex)
            {
                IsCurrencyExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsCurrencyExist;
        }

    }

}
