using Domain.Common;

namespace Domain.Entities
{
    public class Customer:AuditableBaseEntity
    {
        public string Name { get; set; }    
        public string Tel { get; set; }   
        public string Email { get; set; }   
        public string Address { get; set; } 
        public string City { get; set; }    

    }
}
