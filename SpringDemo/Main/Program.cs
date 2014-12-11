using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Interface;
using DaoFactory;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonDao dao = ObjectFactory.CreatePersonDao();
            dao.Save();

        }
    }
}
