namespace CesarCoder
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
        /// Просмотр текущих параметров
        /// </summary>
        /// <returns>Возвращает значения трёх основных параметров объекта класса</returns>
        public string GetParam()
        {
            return "A = " + A + ";   B = " + B + ";   M = " + M + ";";
        }
    }
}
