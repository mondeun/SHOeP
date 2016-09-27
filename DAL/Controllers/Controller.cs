using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class Controller
    {
        protected readonly DbConnection Connection;

        protected Controller()
        {
            Connection = new DbConnection();
        }
    }
}
