using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    internal class clsConnectionSettings
    {
        static public string ConnectionString = @"Server =.; DataBase = BANK; User ID = sa; Password = 123456;";

    }
}
