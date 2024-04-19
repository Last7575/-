using System;
using System.Collections.Generic;
using System.Globalization; 

class Program
{

    struct Customer
    {
        public int Number; 
        public string FullName; 
        public string Address; 
        public DateTime RegistrationDate; 

        public Customer(int number, string fullName, string address, DateTime registrationDate)
        {
            Number = number;
            FullName = fullName;
            Address = address;
            RegistrationDate = registrationDate;
        }
    }

    static void Main(string[] args)
    {

        List<Customer> customers = new List<Customer>();


        while (true)
        {
            Console.WriteLine("Введите данные о покупателе (или введите 'готово', чтобы закончить ввод):");

            Console.Write("Порядковый номер: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "готово")
                break;

            int number;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Некорректный ввод для порядкового номера.");
                continue;
            }

            Console.Write("Ф.И.О.: ");
            string fullName = Console.ReadLine();

            Console.Write("Домашний адрес: ");
            string address = Console.ReadLine();

            DateTime registrationDate;
            while (true)
            {
                Console.Write("Дата постановки на учет (дд.мм.гггг): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out registrationDate))
                {
                    Console.WriteLine("Некорректный ввод для даты.");
                }
                else
                {
                    break;
                }
            }

            customers.Add(new Customer(number, fullName, address, registrationDate));
        }


        customers.Sort((x, y) => x.RegistrationDate.CompareTo(y.RegistrationDate));

        Console.WriteLine("Список лиц в порядке очереди по датам постановки на учет:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"Покупатель №{customer.Number}: {customer.FullName}, {customer.Address}, Дата постановки на учет: {customer.RegistrationDate.ToString("dd.MM.yyyy")}");
        }
    }
}
