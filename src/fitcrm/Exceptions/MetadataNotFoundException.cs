using System;

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
