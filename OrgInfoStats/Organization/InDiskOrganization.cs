using OrgInfoStats.EventCheckers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Класс организации, с которой мы работаем на жестком диске
    /// Родитель: WorkOrganization
    /// </summary>
    class InDiskOrganization : WorkOrganization
    {
        // Конструктор
        public InDiskOrganization(string name) : base(name) 
        {
            // Если файла для организации нет
            if (!File.Exists(Path))
            {
                // Создаем файл
                using (var writer = File.AppendText(Path))
                {
                    // Добавляем строку с названием столбцов (для CSV)
                    writer.WriteLine("Тип активности;Название;GEO;Цена");
                }
            }
        }

        // Путь к файлу
        private string Path { get => @$"..\..\..\Files\Activities\{Name}.txt"; }

        // Событие добавления услуги
        public override event ActivityAddedDelegate ActivityAdded;

        // Метод добавления услуги
        public override void AddActivity(Activity activity)
        {
            // Открываем файл для записи
            using (var writer = File.AppendText(Path))
            {
                // Записываем информацию об организации
                writer.WriteLine($"{activity.Type};{activity.Name};{activity.Place};{activity.Price}");

                // Вызываем событие, если в делегат занесен метод (который записывает логи)
                if (ActivityAdded != null)
                {
                    ActivityAdded($"{this.Name};{activity.Name}", new EventArgs());
                }

            }

        }

        // Метод просмотра услуг
        public override void ShowActivities()
        {
            // Открываем файл для чтения
            using (var reader = File.OpenText(Path))
            {
                // Устанавливаем курсор на вторую строку (чтобы не прочитать название столбцов)
                reader.ReadLine();
                var line = reader.ReadLine();

                // Проходим строки
                while (line != null)
                {
                    // Разбиваем строку по ";"
                    string[] splitLine = line.Split(';');

                    // Выводим информацию об организации на экран
                    Console.WriteLine($"\n\nКАТЕГОРИЯ: {splitLine[0].ToUpper()}\n" +
                                    $"Название: {splitLine[1]}\n" +
                                    $"Место проведения: {splitLine[2]}\n" +
                                    $"Цена: {splitLine[3]} р.\n\n");

                    // Переносим курсор на следующую строку
                    line = reader.ReadLine();
                }
            }
        }

        // Метод получения статистики
        public override Stats GetStats()
        {
            // Инициализируем статистику
            Stats stats = new Stats();

            // Открываем файл для чтения
            using (var reader = File.OpenText(Path))
            {
                // Устанавливаем курсор (чтобы не считатать название столбцов)
                reader.ReadLine();
                var line = reader.ReadLine();

                // Проходим строки
                while (line != null)
                {
                    // Разбиваем строки по ";"
                    string[] splitLine = line.Split(';');
                    
                    // Добавляем в статистику цену
                    stats.Add(Decimal.Parse(splitLine[3]));
                    
                    // Переносим курсор на новую строку
                    line = reader.ReadLine();
                }
            }
            // Возвращаем статистику
            return stats;
        }

    }
}
