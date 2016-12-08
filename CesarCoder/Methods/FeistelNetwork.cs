using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCoder.Methods
{
    class FeistelNetwork
    {
        public static UInt32 FeistelNetworkCrypt(UInt32 data, UInt16 key, int rounds)
        {
            UInt16 left, right, swap;
            int i;

            left = (UInt16)(data & UInt16.MaxValue);
            right = (UInt16)((data >> 16) & UInt16.MaxValue);

            for (i = 0; i < rounds; i++)
            {
                swap = (UInt16)(left ^ FGamma(right, key));
                left = right;
                right = swap;
            }

            return (left | ((UInt32)right << 16));
        }

        public static UInt32 FeistelNetworkDecrypt(UInt32 data, UInt16 key, int rounds)
        {
            UInt16 left, right, swap;
            int i;

            left =(UInt16)(data & UInt16.MaxValue);
            right = (UInt16)((data >> 16) & UInt16.MaxValue);

            for (i = rounds - 1; i >= 0; i--)
            {
                swap = (UInt16)(right ^ FGamma(left, key));
                right = left;
                left = swap;
            }

            return (left | ((UInt32)right << 16));
        }



        private static UInt16 FGamma(UInt16 data_half, UInt16 key)
        {
            return (UInt16)(data_half ^ ((UInt16)key * UInt32.Parse("abcd1234", System.Globalization.NumberStyles.HexNumber)));
        }
    }
}
