using AppCore.Entity;
using System.Collections.Generic;

namespace Computer.DAL.Entities
{
    public class Pc : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<PcUser> PcUsers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
