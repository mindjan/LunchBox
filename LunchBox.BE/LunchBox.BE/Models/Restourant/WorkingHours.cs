namespace LunchBox.BE.Models.Restourant
{
    public class WorkingHours
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}
