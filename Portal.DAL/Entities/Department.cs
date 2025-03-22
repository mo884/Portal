namespace Portal.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public string? CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public string? ModifiedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTime DeletedOn { get; private set; }
        public virtual List<Employee>? Employees { get; private set; }
    }
}
