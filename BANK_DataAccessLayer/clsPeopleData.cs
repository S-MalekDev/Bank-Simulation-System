using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BANK_DataAccessLayer
{
    public static class clsPeopleData
    {

        static public DataTable GetAllPeople()
        {
            DataTable dtPeopleList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM PeopleList;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPeopleList.Load(Reader);
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


            return dtPeopleList;
        }

        static public DataTable GetPeopleListByPersonIDLikeTheNumber(string TextOfNum)
        {
            DataTable dtPeopleList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM PeopleList WHERE ID LIKE ''+ @TextOfNum +'%' ;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TextOfNum", TextOfNum);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPeopleList.Load(Reader);
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


            return dtPeopleList;
        }

        static public bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string MedName, ref string LastName, ref bool Gendor, ref DateTime DateOfBirth, ref string NationalNumber, ref byte Nationality, ref string Email, ref string Phone, ref byte CountryOfResidence, ref string Address, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM People WHERE PersonID =@PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    FirstName = (string)Reader["FirstName"];

                    if (Reader["MedName"] != DBNull.Value)
                        MedName = (string)Reader["MedName"];

                    LastName = (string)Reader["LastName"];
                    Gendor = (bool)Reader["Gendor"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    NationalNumber = (string)Reader["NationalNumber"];
                    Nationality = (byte)Reader["Nationality"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];

                    Phone = (string)Reader["Phone"];
                    CountryOfResidence = (byte)Reader["CountryOfResidence"];
                    Address = (string)Reader["Address"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];



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

        static public bool GetPersonInfoByNationalNo(ref int PersonID, ref string FirstName, ref string MedName, ref string LastName, ref bool Gendor, ref DateTime DateOfBirth, string NationalNumber, ref byte Nationality, ref string Email, ref string Phone, ref byte CountryOfResidence, ref string Address, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM People WHERE NationalNumber =@NationalNumber;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];

                    if (Reader["MedName"] != DBNull.Value)
                        MedName = (string)Reader["MedName"];

                    LastName = (string)Reader["LastName"];
                    Gendor = (bool)Reader["Gendor"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Nationality = (byte)Reader["Nationality"];

                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];

                    Phone = (string)Reader["Phone"];
                    CountryOfResidence = (byte)Reader["CountryOfResidence"];
                    Address = (string)Reader["Address"];

                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)Reader["ImagePath"];



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

        static public int AddNewPerson(string FirstName, string MedName, string LastName, bool Gendor, DateTime DateOfBirth, string NationalNumber, byte Nationality, string Email, string Phone, byte CountryOfResidence, string Address, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO People
                                         (FirstName, MedName, LastName, Gendor, DateOfBirth, NationalNumber, Nationality, Email, Phone, CountryOfResidence, Address, ImagePath)
                                   VALUES
                                         (@FirstName, @MedName, @LastName, @Gendor, @DateOfBirth, @NationalNumber, @Nationality, @Email, @Phone, @CountryOfResidence, @Address, @ImagePath);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);

            if (string.IsNullOrEmpty(MedName))
                Command.Parameters.AddWithValue("@MedName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@MedName", MedName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            Command.Parameters.AddWithValue("@Nationality", Nationality);

            if (string.IsNullOrEmpty(Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@CountryOfResidence", CountryOfResidence);
            Command.Parameters.AddWithValue("@Address", Address);

            if (string.IsNullOrEmpty(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);



            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    PersonID = ID;
                }
            }
            catch (Exception ex)
            {
                PersonID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return PersonID;
        }

        static public bool UpdatePerson(int PersonID, string FirstName, string MedName, string LastName, bool Gendor, DateTime DateOfBirth, string NationalNumber, byte Nationality, string Email, string Phone, byte CountryOfResidence, string Address, string ImagePath)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE People 
SET FirstName = @FirstName
, MedName = @MedName
, LastName = @LastName
, Gendor = @Gendor
, DateOfBirth = @DateOfBirth
, NationalNumber = @NationalNumber
, Nationality = @Nationality
, Email = @Email
, Phone = @Phone
, CountryOfResidence = @CountryOfResidence
, Address = @Address
, ImagePath = @ImagePath
WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);

            if (string.IsNullOrEmpty(MedName))
                Command.Parameters.AddWithValue("@MedName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@MedName", MedName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            Command.Parameters.AddWithValue("@Nationality", Nationality);

            if (string.IsNullOrEmpty(Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@CountryOfResidence", CountryOfResidence);
            Command.Parameters.AddWithValue("@Address", Address);

            if (string.IsNullOrEmpty(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);



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

        static public bool DeletePerson(int PersonID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM People WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

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

        static public bool IsPersonExist(int PersonID)
        {
            bool IsPersonExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM People WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsPersonExist = true;
                }
            }
            catch (Exception ex)
            {
                IsPersonExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsPersonExist;
        }

        static public bool IsPersonExistByNationalNo(string NationalNumber)
        {
            bool IsPersonExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM People WHERE NationalNumber = @NationalNumber;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsPersonExist = true;
                }
            }
            catch (Exception ex)
            {
                IsPersonExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsPersonExist;
        }

    }






}
