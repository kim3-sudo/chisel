using System;
using System.Collections.Generic;
using System.Text;

namespace Chisel
{
    class convertToBool
    {
        public bool stringToBool(string stringToBool)
        {
            bool returnBool;
            if (stringToBool == "true" || stringToBool == "True")
            {
                returnBool = true;
            }
            else if (stringToBool == "false" || stringToBool == "False")
            {
                returnBool = false;
            }
            return false;
        }
    }
}
