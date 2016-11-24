namespace CesarCoder
{
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
            M = 1664525;
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
