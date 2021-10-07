using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Класс Organization - класс представляющией организацию
    /// Включает в себя поля характеризующие организацию и метод вывода информации о ней
    /// P.S. Не над всеми организациями можно осуществлять работу, например, наша компания - есть организация,
    /// она также имеет определенную информацию, но не имеет возможности добавления услуги и т.п.
    /// </summary>
    public class Organization
    {
        // Конструктор организации
        public Organization(string name)
        {
            // Имя организации
            Name = name;
        }

        // Имя организации (поле)
        private string name;
        
        // Свойство имени организации
        public string Name
        {
            // Получение данных
            get => name;

            // Установка значения
            set
            {
                // Если не пустая строка
                if (!String.IsNullOrEmpty(value))
                    // Устанавливаем значение
                    name = value;
                else
                    // Выбрасываем исключение
                    throw new Exception("Название организации не может содержать пустого значения.");
            }
        }

        // Метод вывода информации об организации
        public void Info() => Console.WriteLine($"\n--------------\nОРГАНИЗАЦИЯ: {Name.ToUpper()}\n--------------\n");
    }
}
