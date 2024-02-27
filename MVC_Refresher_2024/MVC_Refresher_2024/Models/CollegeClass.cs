namespace MVC_Refresher_2024.Models
{
    public class CollegeClass
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public int CollegeClassID { get; set; }

        public string? CollegeClassName { get; set; }
        public Teacher? CollegeClassTeacher { get; set; }
    }
}
