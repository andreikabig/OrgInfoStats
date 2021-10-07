using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Класс активности (услуги)
    /// </summary>
    public class Activity
    {
        // Конструктор (с экземпляром типа активности)
        public Activity(string name, string place, decimal price, RestType rType)
        {
            // Название активности
            Name = name;

            // Место проведения активности
            Place = place;

            // Стоимость активности
            Price = price;

            // Тип активности
            restType = rType;
        }

        // Перегрузка конструктора (без задания типа активности)
        public Activity(string name, string place, decimal price)
        {
            Name = name;
            Place = place;
            Price = price;

            // Устанавливается тип по умолчанию
            restType = new RestType();
        }

        // Название активности
        private string name;

        // Место проведения активности
        private string place;

        // Стоимость активности
        private decimal price;

        // Тип активности
        private RestType restType;
        
        // Свойство названия активности
        public string Name
        {
            get => name;
            set 
            {
                // Проверка на пустое значение
                if (!String.IsNullOrEmpty(value))
                    name = value;
                else
                    throw new Exception("Название активности не может содержать пустое значение!");
            }
        }

        // Свойство места проведения
        public string Place
        {
            get => place;
            set
            {
                // Проверка на пустое значение
                if (!String.IsNullOrEmpty(value))
                    place = value;
                else
                    throw new Exception("Место проведения активности не может содержать пустое значение!");
            }
        }

        // Свойство стоимости
        public decimal Price
        {
            get => price;
            set 
            {
                // Проверка на отрицательное значение
                if (value >= 0)
                    price = value;
                else
                    throw new Exception($"Стоимость активности не может быть отрицательной: {value}");
            }
        }

        // Свойство типа активности
        public string Type 
        {
            get => restType.Type;
            set
            {
                restType.Type = value;
            }
        }

        // Метод вывода инфорамации об активности
        public void Show() => Console.WriteLine($"\n\nКАТЕГОРИЯ: {restType.Type.ToUpper()}\n" +
            $"Название: {name}\n" +
            $"Место проведения: {place}\n" +
            $"Цена: {price} р.\n\n");

    }
}
