using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO {
    public class conexionDAO {
        public SqlConnection getcn = new SqlConnection("server=.;database=BD_SITTPR;uid=sa;pwd=sql");
    }
}
