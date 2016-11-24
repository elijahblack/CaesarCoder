using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCoder
{
    class PseudoRandomNumberGenerator
    {
        public int A;
        public int B;
        public int M;

        public PseudoRandomNumberGenerator()
        {
            A = 3;
            B = 2;
            M = 1664525;
        }
    }
}
