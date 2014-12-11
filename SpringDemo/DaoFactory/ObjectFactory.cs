using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Dao.Interface;

namespace DaoFactory
{
    public class ObjectFactory
    {
        public static IPersonDao CreatePersonDao()
        {
            return new PersonDao();
        }
    }
}
