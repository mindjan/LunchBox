namespace LunchBox.BE.Contracts.Restourant
{
    public class WorkingHours
    {
        public Models.Restourant.DayOfWeek DayOfWeek { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}
