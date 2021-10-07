using System;
using System.IO;

namespace OrgInfoStats
{
    /// <summary>
    /// Экспериментальный проект c применением полученных знаний: C# Introduction
    /// OrgInfoStats позволяет:
    /// 1. Создавать организации и добавлять информацию об их услугах
    /// 2. Работать в оперативной памяти и на жестком диске
    /// 3. Получать статистику по услугам организации
    /// 4. Вести журнал псевдо-логов (добавление организации)
    /// 
    /// Приложение: Unit-тестирование некоторых классов с помощью xUnit
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - с оперативной памятью\n2 - с сохранением на SSD/HDD\n--------------------------");
            
            // Создание организации
            WorkOrganization org = NewOrg();
            
            // Вывод списка команд
            Help();

            // Запуск рабочей области
            Start(org);
        }

        // Метод запуска рабочей области
        private static void Start(WorkOrganization org)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write(">> ");
                
                // Команда
                string input = Console.ReadLine();

                switch (input)
                {
                    case "/add":
                        AddActivity(org);
                        break;
                    case "/show":
                        org.ShowActivities();
                        break;
                    case "/help":
                        Help();
                        break;
                    case "/info":
                        org.Info();
                        break;
                    case "/q":
                        exit = true;
                        break;
                    case "/list":
                        RestType.Show();
                        break;
                    case "/stats":
                        try
                        {
                            org.ShowStats();
                        }
                        catch 
                        {
                            Console.WriteLine("Данная организация не содержит никаких услуг.");
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует! Подбробнее: /help.");
                        break;
                }
            }
        }

        // Метод создания организации
        static WorkOrganization NewOrg()
        {
            Console.Write("Выберите тип работы: ");
            string workType = Console.ReadLine();

            try
            {
                if (workType == "1")
                {
                    Console.Write("Название организации: ");
                    WorkOrganization org = new InMemmoryOrganization(Console.ReadLine());
                    org.ActivityAdded += OnActAdded;
                    return org;
                }
                else if (workType == "2")
                {
                    Console.Write("Название организации: ");
                    InDiskOrganization org = new InDiskOrganization(Console.ReadLine());
                    org.ActivityAdded += OnActAdded;
                    return org;
                }
                else
                {
                    Console.WriteLine("К сожалению, такого вида работы мы еще не добавили, попробуйте снова");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tОШИБКА | {ex.Message}\nПопробуйте снова!");
            }

            return NewOrg(); 
        }

        // Метод просмотра доступных команд
        static void Help() => Console.WriteLine("\n==================\nСПИСОК КОМАНД\n==================\n" +
            "\t/show - показать услуги\n" +
            "\t/add - добавить услугу\n" +
            "\t/help - доступные команды\n" +
            "\t/info - информация об организации\n" +
            "\t/stats - статистика\n" +
            "\t/q - выход");

        // Метод создания услуги
        static void AddActivity(WorkOrganization org)
        {
            static RestType AddType() 
            {
                try
                {
                    Console.Write("Тип активности: ");
                    return new RestType(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\tОШИБКА | {ex.Message}");
                }
                return AddType();
            }

            
            Console.Write("Название активности: ");
            string actName = Console.ReadLine();

            Console.Write("Место проведения: ");
            string place = Console.ReadLine();

            try
            {
                Console.Write("Стоимость: ");
                decimal price = Decimal.Parse(Console.ReadLine());
                Activity activity = new Activity(actName, place, price, AddType());
                org.AddActivity(activity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tОШИБКА | {ex.Message}");
            }
        }

        // Метод обработки события добавления услуги
        static void OnActAdded(object sender, EventArgs e)
        {
            // Записи действия в логи
            using (var writer = File.AppendText(@"..\..\..\Files\logs\actLogs.txt"))
            {
                writer.WriteLine($"{DateTime.Now};{sender.ToString()}");
            }
        }

    }
}
