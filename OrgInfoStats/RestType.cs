using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Класс типа активности 
    /// </summary>
    public class RestType
    {
        // Конструктор
        public RestType()
        {
            // Значение по умолчанию
            Type = "другое";
        }

        // Перегрузка конструктора (задано название)
        public RestType(string type)
        {
            // Устанавливаем тип
            Type = type;
        }

        // Перегрузка конструктора (задан порядковый номер)
        public RestType(int serialNumber)
        {
            try
            {
                // Попытка установить тип по порядковому номеру
                Type = ListOfRestTypes[serialNumber - 1];
            }
            catch
            {
                // Выбрасываем исключение
                throw new Exception($"Порядковый номер типа активности задан неверно: {serialNumber}");
            }
        }
        
        // Список доступных типов активностей
        public static List<string> ListOfRestTypes 
        {
            get => new List<string> {"lite", "активный", "extreme", "relax",
            "events", "chill out", "surpise",
            "< 500 ₽", "семейный", "детский",
            "творческий", "интеллектуальный", "cybersport", "другое"};
        }

        // Просмотр списка доступных типов активностей
        public static void Show()
        {
            // Инициализация порядкового номера
            int i = 0;
            
            // Проход списка типов активностей
            foreach (string type_ in ListOfRestTypes)
                Console.WriteLine($"{++i}. {type_.ToUpper()}");
        }

        // Тип активности
        private string restType;

        // Свойство типа активности
        public string Type
        {
            get => restType;
            set
            {
                // Устанавливаем значение, если такой тип есть в списке
                if (ListOfRestTypes.Exists(x => x == value.ToLower()))
                    restType = value;
                else
                    throw new Exception($"Не существующий тип организаци: '{value}'.");
            }
        }
    }
}
