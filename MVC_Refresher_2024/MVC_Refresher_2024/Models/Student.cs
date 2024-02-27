namespace MVC_Refresher_2024.Models
{
    public class Student
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public int StudentID { get; set; }
        public string? StudentFName { get; set; }
        public string? StudentLName { get; set; }
        public CollegeClass[]? collegeClasses { get; set; }
    }
}
