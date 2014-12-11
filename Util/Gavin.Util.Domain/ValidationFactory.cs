using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gavin.Util;
using Gavin.Util.Validations;
using Gavin.Util.Validations.EntLib;

namespace Gavin.Util.Domain
{
    public class ValidationFactory
    {
        public static IValidation Create()
        {
            return new Validation();
        }
    }
}
