using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string fileName;
        int N;

        // Запрос имени файла
        Console.WriteLine("Введите имя файла:");
        fileName = Console.ReadLine();

        // Запрос целого числа N
        Console.WriteLine("Введите целое число N (0 < N < 27):");
        while (!int.TryParse(Console.ReadLine(), out N) || N <= 0 || N >= 27)
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число N (0 < N < 27):");
        }

        // Создание и запись в файл
        try
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 1; i <= N; i++)
                {
                    string line = "";
                    for (char c = 'a'; c < 'a' + i; c++)
                    {
                        line += c;
                    }
                    sw.WriteLine(line);
                }
            }

            Console.WriteLine("Файл успешно создан и заполнен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
