using OrgInfoStats.EventCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Класс организации, с которой мы работаем в оперативной памяти
    /// Родитель: WorkOrganization
    /// </summary>
    class InMemmoryOrganization: WorkOrganization
    {
        // Инициализация класса родителя
        public InMemmoryOrganization(string name) : base(name) 
        {
            // Инициализация списка услуг
            activitiesList = new List<Activity>();
        }

        // Объявление списка услуг
        private List<Activity> activitiesList;

        // Свойство кол-ва страниц (для постраничного просмотра)
        public int Pages
        {
            // Возвращаем кол-во страниц (на каждой странице до 10 активностей)
            get => (int)Math.Ceiling((decimal)activitiesList.Count / 10);
        }

        // Событие добавления услуги
        public override event ActivityAddedDelegate ActivityAdded;

        // Метод добавления услуги
        public override void AddActivity(Activity activity)
        {
            // Добавляем услугу в список услуг
            activitiesList.Add(activity);

            // Вызываем событие, если в делегат занесен медот (который записывает логи)
            if (ActivityAdded != null)
            {
                ActivityAdded($"{this.Name};{activity.Name}", new EventArgs());
            }

        }

        // Метод просмотра услуг
        public override void ShowActivities()
        {
            // Перебираем список активностей и выводим информацию об активности
            foreach (Activity activity in activitiesList)
                activity.Show();
        }

        // Перегрузка метода просмотра активностей (по страницам)
        public void ShowActivities(int page)
        {
            // Получаем координату первого элемента на странице
            int firstAct = (page - 1) * 10;

            // Получаем координату последнего элемента на странице (потенциальную)
            int lastAct = page * 10;

            // Проверяем на соответствие потенциальной координаты последней услуги на странице и реальной
            if ((activitiesList.Count % 10 != 0) && (page == Pages))
            {
                lastAct = firstAct + activitiesList.Count % 10;
            }
            try
            {
                // Если введен допустимый диапазон страниц
                if ((page <= Pages) && (page > 0))
                    Console.WriteLine($"Показано: {firstAct + 1} - {lastAct} активности.");

                // Перебираем соответствующие странице элементы списка
                for (int i = firstAct; i < lastAct; i++)
                {
                    // Показываем информацию об услуге
                    activitiesList[i].Show();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Если введен не допустимый диапазон страниц
                Console.WriteLine("Такой страницы не существует.");
            }
        }
        
        // Метод получения статистики
        public override Stats GetStats()
        {
            // Инициализиурем статистику
            Stats stats = new Stats();

            // Перебираем все услуги в списке
            foreach (Activity act in activitiesList)
            {
                // Добавляем стоимость в статистику
                stats.Add(act.Price);
            }
            // Возвращаем статистику
            return stats;
        }

        

        
    }
}
