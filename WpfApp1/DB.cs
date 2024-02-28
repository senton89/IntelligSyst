using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static class DB
    {
        public static void ClearDataBase()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=Intelligsyst
; Integrated Security=True");
            connection.Open();
            SqlCommand commandTL = new SqlCommand($"DELETE FROM trafficLights", connection);
            SqlCommand commandC = new SqlCommand($"DELETE FROM Cars", connection);
            commandTL.ExecuteNonQuery();
            commandC.ExecuteNonQuery();
            connection.Close();
        }
    }
}
