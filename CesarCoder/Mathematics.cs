using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesarCoder
{
    class Mathematics
    {
        /// <summary>
        /// Поиск наименьшего общего делителя для двух чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Возвращает наименьший общий делитель</returns>
        public static long GCD(long a, long b)
        {
            // Понятия не имею, что тут происходит,
            // но так как оно работает, 
            // примем это за магию и будем радоваться жизни

            long nod = 1L;
            long tmp;
            if (a == 0L)
                return b;
            if (b == 0L)
                return a;
            if (a == b)
                return a;
            if (a == 1L || b == 1L)
                return 1L;
            while (a != 0 && b != 0)
            {
                if (a % 2L == 0L && b % 2L == 0L)
                {
                    nod *= 2L;
                    a /= 2L;
                    b /= 2L;
                    continue;
                }
                if (a % 2L == 0L && b % 2L != 0L)
                {
                    a /= 2L;
                    continue;
                }
                if (a % 2L != 0L && b % 2L == 0L)
                {
                    b /= 2L;
                    continue;
                }
                if (a > b)
                {
                    tmp = a;
                    a = b;
                    b = tmp;
                }
                tmp = a;
                a = (b - a) / 2L;
                b = tmp;
            }
            if (a == 0)
                return nod * b;
            else
                return nod * a;
        }
    }
}
