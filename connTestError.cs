using System;
using System.Collections.Generic;
using System.Text;

namespace Chisel
{
    class connTestError
    {
        public string pingErrorCode(int pingResult)
        {
            // return statuses
            // code 10: ping success
            // code 11: timeout
            // code 12: ping exception
            // code 13: no interconnection found
            // code 14: failure for unknown reason
            // code 15: socket exception

            //declare an empty string
            string returnResult = string.Empty;

            if (pingResult == 11)
            {
                returnResult = "ERROR 11. PING TIMEOUT.\n";
            }
            else if (pingResult == 12)
            {
                returnResult = "ERROR 12. PING EXCEPTION THROWN.\n";
            }
            else if (pingResult == 13)
            {
                returnResult = "ERROR 13. UNABLE TO ESTABLISH INTERNET LINK. CHECK INTERNET CONNECTION.\n";
            }
            else if (pingResult == 14)
            {
                returnResult = "ERROR 14. PING FAILURE. UNKNOWN REASON.\n";
            }
            else if (pingResult == 15)
            {
                returnResult = "ERROR 15. SOCKET EXCEPTION THROWN.\n";
            }
            else
            {
                returnResult = "ERROR 21. INVALID ADDRESS.\n";
            }
            return returnResult;
        }
    }
}
