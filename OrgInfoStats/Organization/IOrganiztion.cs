using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgInfoStats
{
    /// <summary>
    /// Интерфейс организации для дальнейшей работы с ней
    /// </summary>
    public interface IOrganiztion
    {
        // Свойство имени (для валидации установленных значений)
        string Name { get; set; }
        
        // Метод получения статистики 
        Stats GetStats();

        // Метод просмотра услуг
        void ShowActivities();
        
        // Метод добавления услуги
        void AddActivity(Activity activity);

    }
}
