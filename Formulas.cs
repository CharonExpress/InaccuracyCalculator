using System;
using System.Collections.Generic;
using System.Linq;

namespace InaccuracyCalculator
{
    /// <summary>
    /// Фигура
    /// </summary>
    public abstract class Formula
    {
        private LinearInaccuracy inaccuracy;

        private LinearInaccuracy LinearInaccuracy
        {
            get
            {
                if (inaccuracy == null)
                    inaccuracy = new LinearInaccuracy();
                return inaccuracy;
            }
        }

        /// <summary>
        /// Погрешность части/фигуры
        /// </summary>
        public abstract double PartInaccuracy { get; }

        /// <summary>
        /// Формула по которой определялась погрешность
        /// </summary>
        public abstract string PreFormula { get; }

        /// <summary>
        /// Формула с подставленными значениями
        /// </summary>
        public abstract string FullFormula { get; }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public abstract ShapesTypes? GetShapesType();

        /// <summary>
        /// Формула с предвычесленными промежуточными значениями. Для простейших - возведённые в квадрат,
        /// для этажОВ с вычисленными корнями
        /// </summary>
        public abstract string MidFormula { get; }
        /// <summary>
        /// mₚ и всё
        /// </summary>
        public virtual string FormulaPrefix
        {
            get
            {
                return "𝑚ₚ";
            }
        }

        /// <summary>
        /// Формула из НПА
        /// </summary>
        public abstract string FormalFormula { get; }

        /// <summary>
        /// Cредняя квадратическая погрешность определения линейных измерений (используются Рекомендации по технической инвентаризации и регистрации зданий гражданского назначения" (приняты Росжилкоммунсоюзом 01.01.1991)
        /// </summary>
        public double Ms(double MaxLenght)
        {
            return LinearInaccuracy.GetLinearInaccuracy(MaxLenght);
        }
    }

    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Formula
    {
        private double _a, _h;

        /// <summary>
        /// Новая простейшая фигура - треугольник
        /// </summary>
        /// <param name="a">Основание прямоугольного треугольника</param>
        /// <param name="h">Высота треугольника либо</param>
        public Triangle(double a, double h)
        {
            _a = a;
            _h = h;
        }

        public override double PartInaccuracy => Ms(_a >= _h ? _a : _h) * Math.Sqrt(Math.Pow(_a, 2) + Math.Pow(_h, 2)) / 2;

        public override string PreFormula => "𝑚ₛ/2*√(𝑎²+𝘩²)";

        public override string FullFormula => PreFormula.Replace("𝑎", _a.ToString()).Replace("𝘩", _h.ToString()).Replace("𝑚ₛ", Ms(_a >= _h ? _a : _h).ToString());

        public override string FormalFormula => PreFormula;

        public override string MidFormula => PreFormula.Replace("𝑎", Math.Pow(_a, 2).ToString()).Replace("𝘩", Math.Pow(_h, 2).ToString()).Replace("𝑚ₛ", (Ms(_a >= _h ? _a : _h) / 2).ToString());

        public override ShapesTypes? GetShapesType()
        {
            return ShapesTypes.Треугольник;
        }
    }

    /// <summary>
    /// Новая простейшая фигура - прямоугольник, квадрат, параллелограмм
    /// </summary>
    public class Rectangle : Formula
    {
        private double _a, _b;
        /// <summary>
        /// Новая простейшая фигура - прямоугольник, квадрат, параллелограмм
        /// </summary>
        /// <param name="a">Одна сторона</param>
        /// <param name="b">Другая сторона</param>
        public Rectangle(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public override double PartInaccuracy => Ms(_a >= _b ? _a : _b) * Math.Sqrt(Math.Pow(_a, 2) + Math.Pow(_b, 2));

        public override string PreFormula => "𝑚ₛ*√(𝑎²+𝑏²)";

        public override string FullFormula => PreFormula.Replace("𝑎", _a.ToString()).Replace("𝑏", _b.ToString()).Replace("𝑚ₛ", Ms(_a >= _b ? _a : _b).ToString());

        public override string FormalFormula => PreFormula;

        public override string MidFormula => PreFormula.Replace("𝑎", Math.Pow(_a, 2).ToString()).Replace("𝑏", Math.Pow(_b, 2).ToString()).Replace("𝑚ₛ", Ms(_a >= _b ? _a : _b).ToString());

        public override ShapesTypes? GetShapesType()
        {
            return ShapesTypes.Прямоугольник;
        }
    }

    public class Floor : Formula
    {
        IEnumerable<Formula> _elements;

        public Guid Id { get; set; }

        public Floor(IEnumerable<Formula> elements)
        {
            _elements = elements;
        }

        public override double PartInaccuracy
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().PartInaccuracy;
                }
                else
                {
                    return Math.Sqrt(_elements.Select((x) => Math.Pow(x.PartInaccuracy, 2)).Sum());
                }
            }
        }

        public override string PreFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().PreFormula;
                }
                else
                {
                    string partsFormula = string.Join(" + ", _elements.Select((x) => "(" + x.PreFormula + ")²").ToArray());
                    return "√(" + partsFormula + ")";
                }
            }
        }

        public override string FullFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().FullFormula;
                }
                else
                {
                    string partsFormula = string.Join(" + ", _elements.Select((x) => "(" + x.FullFormula + ")²").ToArray());
                    return "√(" + partsFormula + ")";
                }
            }
        }

        public override ShapesTypes? GetShapesType() => null;

        /// <summary>
        /// mₚ_эт
        /// </summary>
        public new string FormulaPrefix
        {
        get
            {
                if (_elements.Count() == 1)
                {
                    return _elements.First().FormulaPrefix;
                }
                else
                {
                    return "𝑚ₚ_эт";
                }
            }
        }

        public override string FormalFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().FormalFormula;
                }
                else
                {
                    string sigma = "∑ⁿ(𝑘=1)";
                    return "√(" + sigma + "𝑚f²)";
                }
            }
        }

        public override string MidFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().MidFormula;
                }
                else
                {
                    string partsFormula = string.Join(" + ", _elements.Select((x) => Math.Pow(x.PartInaccuracy,2)).ToArray());
                    return "√(" + partsFormula + ")";
                }
            }
        }
    }

    public class Realty : Formula
    {
        IEnumerable<Floor> _elements;
        public Realty(IEnumerable<Floor> elements)
        {
            _elements = elements;
        }

        public override double PartInaccuracy
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют этажи здания");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().PartInaccuracy;
                }
                else
                {
                    return Math.Sqrt(_elements.Select((x) => Math.Pow(x.PartInaccuracy, 2)).Sum());
                }
            }
        }

        public override string PreFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return FormulaPrefix + " = " + _elements.First().FormalFormula + " = " + _elements.First().PreFormula;
                }
                else
                {
                    string sigma = "∑ᶜ(𝑘=1)";
                    string floorFormula = "√(" + sigma + "𝑚ₚ_эт²)";
                    string floorsFormula = string.Join(" + ", _elements.Select((x) => x.FormalFormula).ToArray());
                    string partsFormula = string.Join(" + ", _elements.Select((x) => x.PreFormula).ToArray());
                    return FormulaPrefix + " = " + FormalFormula + " = " + floorsFormula + " = " + partsFormula;
                }
            }
        }

        public override string FullFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют этажи");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().FullFormula;
                }
                else
                {
                    string partsFormula = string.Join(" + ", _elements.Select((x) => x.FullFormula).ToArray());
                    return partsFormula;
                }
            }
        }

        public override ShapesTypes? GetShapesType() => null;

        /// <summary>
        /// mₚ_эт
        /// </summary>
        public new string FormulaPrefix
        {
            get
            {
                if (_elements.Count() == 1)
                {
                    return _elements.First().FormulaPrefix;
                }
                else
                {
                    return "𝑚ₚ";
                }
            }
        }

        /// <summary>
        /// Финальный подсчёт. Готовая для вставки формула с результатом
        /// </summary>
        public string FinalCalculation
        {
            get
            {
                return PreFormula + " = " + FullFormula + " = " + MidFormula + " = " + PartInaccuracy.ToString();
            }
        }

        public override string FormalFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют этажи здания");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().FormalFormula;
                }
                else
                {
                    string sigma = "∑ᶜ(𝑘=1)";
                    return "√(" + sigma + "𝑚ₚ_эт²)";
                }
            }
        }

        public override string MidFormula
        {
            get
            {
                if (_elements.Count() < 1)
                {
                    throw new Exception("Отсутствуют фигуры/помещения для этажа");
                }

                if (_elements.Count() == 1)
                {
                    return _elements.First().MidFormula;
                }
                else
                {
                    string floorsMidFormulas = string.Join(" + ", _elements.Select((x) => x.MidFormula).ToArray());
                    string floorsPostMidFormula = string.Join(" + ", _elements.Select((x) => Math.Pow(x.PartInaccuracy, 2)).ToArray());
                    return "√(" + floorsMidFormulas + ")" + " = " + "√(" + floorsPostMidFormula + ")";
                }
            }
        }
    }

    public enum ShapesTypes
    {
        /// <summary>
        /// Прямоугольник
        /// </summary>
        [System.ComponentModel.Description("Прямоугольник")]
        Прямоугольник = 0,

        /// <summary>
        /// Треугольник
        /// </summary>
        [System.ComponentModel.Description("Трегольник")]
        Треугольник = 1
    }
}
