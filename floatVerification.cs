using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verification
{
    internal class floatVerification
    {
        public static bool verification(float num)
        {
            string temp = Convert.ToString(num);
            string[] parts = temp.Split('.');

            return parts.Length == 2 && parts[1].Length > 2;
        }
    }
}
