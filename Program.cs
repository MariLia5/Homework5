using System;
using System.Collections.Generic;
using System.IO;

namespace Homework5
{
    internal class Program
    {
        static List<Figuries> figures = new List<Figuries>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Показать все фигуры");
                Console.WriteLine("3. Сохранить фигуры в файл");
                Console.WriteLine("4. Выход");
                Console.Write("Нажмите клавишу -> ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        Show();
                        break;
                    case "3":
                        Save();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Попробуйте снова.\n");
                        break;
                }
            }
        }

        static void Add()
        {
            Console.WriteLine("\nВыберите тип фигуры:");
            Console.WriteLine("1. Круг");
            Console.WriteLine("2. Прямоугольник/Квадрат");
            Console.WriteLine("3. Треугольник");
            Console.Write("Нажмите клавишу -> ");

            string typeChoice = Console.ReadLine();
            Figuries figure = null;

            try
            {
                switch (typeChoice)
                {
                    case "1":
                        figure = CreateCircle();
                        break;
                    case "2":
                        figure = CreateRectangle();
                        break;
                    case "3":
                        figure = CreateTriangle();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.\n");
                        return;
                }

                Console.Write("Введите имя фигуры -> ");
                figure.Name = Console.ReadLine();

                figures.Add(figure);
                Console.WriteLine("Фигура добавлена\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
                return;
            }
        }

        static Circle CreateCircle()
        {
            Console.Write("Введите радиус круга -> ");
            float radius = float.Parse(Console.ReadLine());
            if (radius <= 0) throw new ArgumentException("Радиус должен быть положительным числом\n");

            return new Circle { Radius = radius };
        }

        static Rectangle CreateRectangle()
        {
            Console.Write("Введите ширину -> ");
            float width = float.Parse(Console.ReadLine());
            Console.Write("Введите высоту -> ");
            float height = float.Parse(Console.ReadLine());

            if (width <= 0 || height <= 0)
                throw new ArgumentException("Ширина и высота должны быть положительными числами\n");

            return new Rectangle { Width = width, Height = height };
        }

        static Triangle CreateTriangle()
        {
            Console.Write("Введите сторону A -> ");
            float a = float.Parse(Console.ReadLine());
            if (a <= 0) throw new ArgumentException("Сторона A должна быть положительным числом\n");

            Console.Write("Введите сторону B -> ");
            float b = float.Parse(Console.ReadLine());
            if (b <= 0) throw new ArgumentException("Сторона B должна быть положительным числом\n");

            Console.Write("Введите сторону C -> ");
            float c = float.Parse(Console.ReadLine());
            if (c <= 0) throw new ArgumentException("Сторона C должна быть положительным числом\n");

            // Проверка неравенства треугольника
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Треугольника с такими сторонами не существует\n");

            return new Triangle { A = a, B = b, C = c };
        }

        static void Show()
        {
            if (figures.Count == 0)
            {
                Console.WriteLine("Список фигур пуст.\n");
                return;
            }

            Console.WriteLine("\nСписок всех фигур ->");
            for (int i = 0; i < figures.Count; i++)
            {
                var figure = figures[i];
                Console.WriteLine($"{i + 1}. {figure.Name} ({figure.GetName()})");
                Console.WriteLine($"   Площадь: {figure.GetArea()}");
                Console.WriteLine($"   Периметр: {figure.GetPerimeter()}");
            }
        }

        static void Save()
        {
            if (figures.Count == 0)
            {
                Console.WriteLine("Нет фигур для сохранения.\n");
                return;
            }

            string fileName = "figures.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var figure in figures)
                    {
                        writer.WriteLine($"Тип: {figure.GetName()}");
                        writer.WriteLine($"Имя: {figure.Name}");
                        writer.WriteLine($"Площадь: {figure.GetArea()}");
                        writer.WriteLine($"Периметр: {figure.GetPerimeter()}");
                        writer.WriteLine("-----------------------------------");
                    }
                }
                Console.WriteLine($"Фигуры успешно сохранены в файл {fileName}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в файл: {ex.Message}\n");
            }
        }
    }
}