namespace MedbaseHybrid.Models
{
    public class QuestionPaged
    {
        public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; } = 1;
    }
}
