using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitcrm.Exceptions
{
    public class MetadataNotFoundException : ApplicationException
    {
        public MetadataNotFoundException()
        {
        }

        public MetadataNotFoundException(string message) : base(message)
        {
        }
    }
}
