using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLineLibrary.Setup
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandHelpAttribute : Attribute
    {
    }
}
