using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeIsUp
{
    class MiscFunction
    {
        public static String LastError;

        public MiscFunction()
        {

        }

        public static SqlConnection OpenConnection(String ConnectionString)
        {
            SqlConnection CN = new SqlConnection(ConnectionString);
            try
            {
                CN.Open();
            }
            catch (SqlException e)
            {
                LastError = e.Message;
            }

            return CN;
        }
    }
}
