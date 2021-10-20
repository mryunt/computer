using AppCore.Entity;
using System.Collections.Generic;

namespace Computer.DAL.Entities
{
    public class User : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<PcUser> PcUsers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
