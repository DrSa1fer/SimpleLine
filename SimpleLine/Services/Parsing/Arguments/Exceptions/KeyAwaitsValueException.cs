using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLineLibrary.Services.Parsing.Exceptions;

namespace SimpleLineLibrary.Services.Parsing.Arguments.Exceptions
{
    internal class KeyAwaitsValueException : ParsingExceptions
    {
        public KeyAwaitsValueException(string key)
            : base($"key {key} awaits value before '='")
        {

        }
    }
}
