using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsCountriesData
    {
        static public DataTable GetListOfNationalities()
        {
            DataTable dtCountriesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT Nationality FROM Countries ORDER BY Nationality ASC;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtCountriesList.Load(Reader);
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


            return dtCountriesList;
        }

        static public DataTable GetListOfCountriesName()
        {
            DataTable dtCountriesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT CountryName FROM Countries ORDER BY CountryName ASC;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtCountriesList.Load(Reader);
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


            return dtCountriesList;
        }

        static public byte GetCountryID_ByNationalityText(string Nationality)
        {
            byte PersonID = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT CountryID FROM Countries WHERE Nationality =@Nationality;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Nationality", Nationality);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && byte.TryParse(Result.ToString(), out byte ID))
                {
                    PersonID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return PersonID;
        }

        static public byte GetCountryID_ByCountryNameText(string countryName)

        {
            byte PersonID = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT CountryID FROM Countries WHERE countryName =@countryName;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@countryName", countryName);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && byte.TryParse(Result.ToString(),out byte ID))
                {
                    PersonID = ID;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                Connection.Close();
            }


            return PersonID;
        }

        static public bool GetCountryInfoByID(byte CountryID, ref string CountryName, ref string Nationality, ref string PhoneCode, ref byte CurrencyID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Countries WHERE CountryID =@CountryID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CountryName = (string)Reader["CountryName"];
                    Nationality = (string)Reader["Nationality"];
                    PhoneCode = (string)Reader["PhoneCode"];
                    CurrencyID = (byte)Reader["CurrencyID"];


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

        static public bool GetCountryInfoByCountryName(ref byte CountryID, string CountryName, ref string Nationality, ref string PhoneCode, ref byte CurrencyID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Countries WHERE CountryName =@CountryName;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CountryID = (byte)Reader["CountryID"];
                    Nationality = (string)Reader["Nationality"];
                    PhoneCode = (string)Reader["PhoneCode"];
                    CurrencyID = (byte)Reader["CurrencyID"];


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
        static public byte AddNewCountry(string CountryName, string Nationality, string PhoneCode, byte CurrencyID)
        {
            byte CountryID = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Countries
                                         (CountryName, Nationality, PhoneCode, CurrencyID)
                                   VALUES
                                         (@CountryName, @Nationality, @PhoneCode, @CurrencyID);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);
            Command.Parameters.AddWithValue("@Nationality", Nationality);
            Command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && byte.TryParse(Result.ToString(), out byte ID))
                {
                    CountryID = ID;
                }
            }
            catch (Exception ex)
            {
                CountryID = 0;
            }
            finally
            {
                Connection.Close();
            }


            return CountryID;
        }

        static public bool UpdateCountry(byte CountryID, string CountryName, string Nationality, string PhoneCode, byte CurrencyID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Countries 
SET CountryName = @CountryName
, Nationality = @Nationality
, PhoneCode = @PhoneCode
, CurrencyID = @CurrencyID
WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            Command.Parameters.AddWithValue("@CountryName", CountryName);
            Command.Parameters.AddWithValue("@Nationality", Nationality);
            Command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
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

        static public bool DeleteCountry(byte CountryID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Countries WHERE CountryID = @CountryID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

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

        static public bool IsCountryExist(byte CountryID)
        {
            bool IsCountryExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Countries WHERE CountryID = @CountryID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsCountryExist = true;
                }
            }
            catch (Exception ex)
            {
                IsCountryExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsCountryExist;
        }



    }


}
