namespace CaesarCoder
{
    /// <summary>
    /// Класс генератора псевдослучайных чисел
    /// </summary>
    class PseudoRandomNumberGenerator
    {
        public int A;
        public int B;
        public int M;

        /// <summary>
        /// Инициализирует объект класса с заданными параметрами
        /// </summary>
        public PseudoRandomNumberGenerator()
        {
            A = 3;
            B = 2;
            M = 40692 - 1;
        }

        /// <summary>
        /// Инициализирует объект класса с определенными параметрами
        /// </summary>
        /// <param name="a">Множитель</param>
        /// <param name="b">Приращение</param>
        /// <param name="m">Модуль</param>
        public PseudoRandomNumberGenerator(int a, int b, int m)
        {
            A = a;
            B = b;
            M = m;
        }

        /// <summary>
        /// Просмотр текущих параметров
        /// </summary>
        /// <returns>Возвращает значения трёх основных параметров объекта класса</returns>
        public string GetParam()
        {
            return "A = " + A + ";   B = " + B + ";   M = " + M + ";";
        }
    }
}
