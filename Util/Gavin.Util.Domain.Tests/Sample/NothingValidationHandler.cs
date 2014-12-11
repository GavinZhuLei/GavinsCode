using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gavin.Util.Validations;

namespace Gavin.Util.Domain.Tests.Sample
{
    public class NothingValidationHandler: IValidationHandler
    {

        public void Handle(ValidationResultCollection results)
        {
            //throw new NotImplementedException();
        }
    }
}
