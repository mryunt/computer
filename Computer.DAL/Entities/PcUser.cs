using AppCore.Entity;

namespace Computer.DAL.Entities
{
    public class PcUser : Audit, IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public int PcId { get; set; }
        public Pc PcFK { get; set; }
        public int UserId { get; set; }
        public User UserFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
