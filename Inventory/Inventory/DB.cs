using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
    public class DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=FLIPSTER;Initial Catalog=dbtest;Integrated Security=True");
    }
}
