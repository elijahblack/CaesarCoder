using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCoder.Methods
{
    class FeistelNetwork
    {
        UInt64 FeistelNetworkCrypt(UInt64 data, UInt16 key, int rounds)
        {
            UInt32 left, right, swap;
            int i;

            left = (UInt32)(data & 0xffff);
            right = (UInt32)((data >> 16) & 0xffff);

            for (i = 0; i < rounds; i++)
            {
                swap = left ^ FGamma(right, key);
                left = right;
                right = swap;
            }

            return (left | ((UInt64)right << 16));
        }

        UInt64 FeistelNetworkDecrypt(UInt64 data, UInt16 key, int rounds)
        {
            UInt32 left, right, swap;
            int i;

            left = (UInt32)(data & 0xffff);
            right = (UInt32)((data >> 16) & 0xffff);

            for (i = rounds - 1; i >= 0; i--)
            {
                swap = right ^ FGamma(left, key);
                right = left;
                left = swap;
            }

            return (left | ((UInt64)right << 16));
        }



        UInt32 FGamma(UInt32 data_half, UInt16 key)
        {
            return (data_half ^ ((UInt32)key * 0xabcd1234));
        }
    }
}
