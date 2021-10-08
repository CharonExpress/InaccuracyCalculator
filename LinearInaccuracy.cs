using System;
using System.Collections.Generic;
using System.Linq;

namespace InaccuracyCalculator
{
    /// <summary>
    /// Список расчитанных погрешностей линейных измерений  (используются Рекомендации по технической инвентаризации и регистрации зданий гражданского назначения" (приняты Росжилкоммунсоюзом 01.01.1991)
    /// </summary>
    public class LinearInaccuracy
    {
        private readonly List<LinearInaccuracyItem> _items;

        /// <summary>
        /// Инициализация списка
        /// </summary>
        public LinearInaccuracy()
        {
            _items = new List<LinearInaccuracyItem>
            {
                new LinearInaccuracyItem(0, 0.99, 0.01),
                new LinearInaccuracyItem(1, 5.99, 0.03),
                new LinearInaccuracyItem(6, 11.99, 0.05),
                new LinearInaccuracyItem(12, 23.99, 0.08),
                new LinearInaccuracyItem(24, 99.99, 0.3)
            };
        }

        /// <summary>
        /// Величиная погрешности линеных измерений в зависимости от максимальной длины фигуры
        /// </summary>
        /// <param name="MaxLinearLenght">Максимальная сторона фигуры</param>
        /// <returns></returns>
        public double GetLinearInaccuracy(double MaxLinearLenght)
        {
            IEnumerable<LinearInaccuracyItem> _properItems = _items.Where((x) => x.Max >= MaxLinearLenght && x.Min <= MaxLinearLenght);
            if (_properItems.Count() < 1)
            {
                throw new Exception($"Для такого расстояная {MaxLinearLenght} нет подходящих погрешностей");
            }
            return _properItems.First().Inaccuracy;
        }

        private class LinearInaccuracyItem
        {
            /// <summary>
            /// Запись из таблицы росчегото-там
            /// </summary>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <param name="inaccuracy"></param>
            public LinearInaccuracyItem(double min, double max, double inaccuracy)
            {
                Min = min;
                Max = max;
                Inaccuracy = inaccuracy;
            }
            public double Min, Max, Inaccuracy;
        }
    }



}
