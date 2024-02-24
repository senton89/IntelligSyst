using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class BD
    {
        SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=Examen
; Integrated Security=True");
    }
}
