namespace MVC_Refresher_2024.Models
{
    public class Teacher
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public int TeacherID { get; set; }
        public string? TeacherName { get; set; }
    }
}
