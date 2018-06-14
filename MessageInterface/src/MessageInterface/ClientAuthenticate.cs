using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageInterface
{
    public static class ClientAuthenticate
    {
        static int startRange = 0;
        static int endRange = 3000;
        public static int GetId()
        {
            Random rnd = new Random();
            return rnd.Next(startRange, endRange);
        }
        public static Boolean Validate(byte[] clientid)
        {
                return true;                
        }
    }
}
