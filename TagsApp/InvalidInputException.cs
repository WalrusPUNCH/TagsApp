using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public class InvalidInputException:Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
