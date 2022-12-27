using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSkills.Classes
{
    class ConnectDb
    {
        SqlConnection Con = new SqlConnection(@"DATA SOURCE=localhost\SQLEXPRESS;initial catalog = BlagodatAlibekov195;integrated security=true");

        public void OpenConnection()
        {
            if (Con.State==System.Data.ConnectionState.Closed)
            {
                Con.Open();
            }
        }

        public SqlConnection GetConnection()
        {
            return Con;
        }
        public void CloseConnection()
        {

        }
    }
}
