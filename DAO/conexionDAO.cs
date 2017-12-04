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
        public SqlConnection visa = new SqlConnection("server=.;database=BD_VISA;uid=sa;pwd=sql");
        public SqlConnection master = new SqlConnection("server=.;database=BD_MASTER;uid=sa;pwd=sql");
    }
}
