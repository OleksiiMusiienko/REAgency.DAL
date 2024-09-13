using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgencyEnum;

namespace REAgency.DAL.Entities
{
    public class Order
    {        
        public int Id { get; set; }
        public OrderName orderClient {  get; set; }
        public List<ObjectsForOrders>? objectsForOrders { get; set; } = new();
        public int ? idClient { get; set; }//если клиент авторизован
        public string? Name { get; set; }//имя с формы
        public string? Phone { get; set; }//телефон с формы
        
    }
    
}
