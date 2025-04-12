using System;
using System.Collections.Generic;

namespace DiscountCalculator
{
    public class Program
    {
        // Функция расчета скидки
        public static decimal CalculateDiscount(int points)
        {
            if (points < 0)
            {
                throw new ArgumentException("Количество баллов не может быть отрицательным.");
            }

            if (points >= 0 && points < 100)
            {
                return 0.01m; // 1%
            }
            else if (points >= 100 && points < 200)
            {
                return 0.03m; // 3%
            }
            else if (points >= 200 && points < 500)
            {
                return 0.05m; // 5%
            }
            else
            {
                return 0.10m; // 10%
            }
        }

        public static void Main(string[] args)
        {
            // Набор тестовых данных
            List<TestCase> testCases = new List<TestCase>()
            {
                new TestCase { Points = 0, ExpectedDiscount = 0.01m },
                new TestCase { Points = 1, ExpectedDiscount = 0.01m },
                new TestCase { Points = 50, ExpectedDiscount = 0.01m },
                new TestCase { Points = 99, ExpectedDiscount = 0.01m },
                new TestCase { Points = 100, ExpectedDiscount = 0.03m },
                new TestCase { Points = 101, ExpectedDiscount = 0.03m },
                new TestCase { Points = 150, ExpectedDiscount = 0.03m },
                new TestCase { Points = 199, ExpectedDiscount = 0.03m },
                new TestCase { Points = 200, ExpectedDiscount = 0.05m },
                new TestCase { Points = 201, ExpectedDiscount = 0.05m },
                new TestCase { Points = 350, ExpectedDiscount = 0.05m },
                new TestCase { Points = 499, ExpectedDiscount = 0.05m },
                new TestCase { Points = 500, ExpectedDiscount = 0.10m },
                new TestCase { Points = 501, ExpectedDiscount = 0.10m },
                new TestCase { Points = 1000, ExpectedDiscount = 0.10m },
            };

            // Запуск тестов
            Console.WriteLine("Запуск тестов...");
            int passed = 0;
            int failed = 0;

            foreach (TestCase testCase in testCases)
            {
                try
                {
                    decimal actualDiscount = CalculateDiscount(testCase.Points);

                    if (actualDiscount == testCase.ExpectedDiscount)
                    {
                        Console.WriteLine($"Тест пройден: Баллы = {testCase.Points}, Ожидаемая скидка = {testCase.ExpectedDiscount}, Фактическая скидка = {actualDiscount}");
                        passed++;
                    }
                    else
                    {
                        Console.WriteLine($"Тест НЕ ПРОЙДЕН: Баллы = {testCase.Points}, Ожидаемая скидка = {testCase.ExpectedDiscount}, Фактическая скидка = {actualDiscount}");
                        failed++;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Тест НЕ ПРОЙДЕН: Баллы = {testCase.Points}, Ошибка = {ex.Message}");
                    failed++;
                }
            }

            Console.WriteLine($"\nВсего тестов: {testCases.Count}");
            Console.WriteLine($"Пройдено: {passed}");
            Console.WriteLine($"Не пройдено: {failed}");

            Console.ReadKey();
        }
    }

    // Класс для представления тестового случая
    public class TestCase
    {
        public int Points { get; set; }
        public decimal ExpectedDiscount { get; set; }
    }
}
