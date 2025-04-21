using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    abstract class Figuries
    {
        public string Name { get; set; }
        public abstract float GetArea();
        public abstract float GetPerimeter();
        public virtual string GetName() { return "Фигура"; }
    }

    class Circle : Figuries
    {
        float pi = 3.14f;
        public float Radius { get; set; }
        public override float GetArea() { return pi * Radius * Radius; }
        public override float GetPerimeter() { return 2 * pi * Radius; }
        public override string GetName() { return "Круг"; }
    }

    class Rectangle : Figuries
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public override float GetArea() { return Width * Height; }
        public override float GetPerimeter() { return 2 * (Width + Height); }
        public override string GetName()
        {
            if (Width == Height) return "Квадрат";
            else return "Прямоугольник";
        }
    }

    class Triangle : Figuries
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public override float GetPerimeter() { return A + B + C; }
        public override float GetArea()
        {
            float p = GetPerimeter() / 2;
            return (float)Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public override string GetName()
        {
            if (A == B && B == C)
                return "Равносторонний треугольник";
            if (A == B || A == C || B == C)
                return "Равнобедренный треугольник";
            else return "Треугольник";
        }
    }
}
