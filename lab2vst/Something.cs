using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2vst
{
    public static class Something
    {
       public static string BitArrayToHexString(BitArray bitArray)
        {
            byte[] bytes = new byte[(bitArray.Length + 7) / 8];
            bitArray.CopyTo(bytes, 0);

            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}

