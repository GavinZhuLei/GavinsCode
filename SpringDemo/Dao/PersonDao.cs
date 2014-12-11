using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Interface;

namespace Dao
{
    public class PersonDao : IPersonDao
    {
        public void Save()
        {
            Console.WriteLine("保存 Person");
        }
    }
}
