using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name, object key):base($"{name} ({key}) is not found!")
        {

        }
    }
}
