namespace Portal.DAL.Entities
{
    public class Employee
    {
        public Employee(string fName, string lName, int age, double salary)
        {
            FName=fName;
            LName=lName;
            Age=age;
            Salary=salary;
        }

        public int Id { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public int Age { get; private set; }
        public double Salary { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public string? CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public string? ModifiedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTime DeletedOn { get; private set; }


        public bool Edit( string ? User,string fname , string lname , int age , double salary )
        {
            bool result = false;
            if(User !=null)
            {
                FName = fname;
                LName = lname;
                Age = age;
                Salary = salary;
                ModifiedOn = DateTime.Now;
                ModifiedBy = User;
                result = true;
            }
           return result;
        }
        public bool Deleted ( string? User )
        {
            bool result = false;
            if( User !=null )
            {
                IsDeleted = !IsDeleted;
                DeletedBy = User;
                DeletedOn = DateTime.Now;
                result = true;
            }
            return result;
        }
    
    }
}
