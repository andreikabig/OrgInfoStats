using OrgInfoStats.EventCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Абстрактный класс организации, с которой мы хотим работать
    /// Родитель: организация (т.к. она является по своей сущности организацией)
    /// Интерфейс: IOrganization (она должна реализовывать интерфейс организации (для работы над ней))
    /// </summary>
    abstract class WorkOrganization : Organization, IOrganiztion
    {
        // Инициализация родителя
        public WorkOrganization(string name) : base(name) { }

        // Метод добавления услуг
        public abstract void AddActivity(Activity activity);

        // Метод просмотра услуг
        public abstract void ShowActivities();

        // Событие добавления активности (для логов)
        public abstract event ActivityAddedDelegate ActivityAdded;
        
        // Метод получения статистики
        public abstract Stats GetStats();

        // Метод просмотра статистики (заранее определен)
        public virtual void ShowStats()
        {
            Stats stats = GetStats();
            Console.WriteLine($"\nКол-во активностей: {stats.CountActivities}\n" +
                $"Средняя стоимость: {stats.Average:N2} р\n" +
                $"Максимальная стоимость: {stats.High} р\n" +
                $"Минимальная стоимость: {stats.Low} р\n");
        }

    }
}
