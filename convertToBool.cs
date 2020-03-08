using System;
using System.Collections.Generic;
using System.Text;

namespace Chisel
{
    class convertToBool
    {
        public bool stringToBool(string stringToBool)
        {
            if (stringToBool == "true" || stringToBool == "True")
            {
                return true;
            }
            else if (stringToBool == "false" || stringToBool == "False")
            {
                return false;
            }
            return false;
        }
    }
}
