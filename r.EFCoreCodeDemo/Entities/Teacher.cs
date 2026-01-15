namespace r.EFCoreCodeDemo.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public Address Address { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}