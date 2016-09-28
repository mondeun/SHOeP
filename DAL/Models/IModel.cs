using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public interface IModel
    {
        void FromSqlReader(SqlDataReader reader);
    }
}
