namespace MedbaseHybrid.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public long TimeTaken { get; set; }
        public int NumberOfQuestions { get; set; }
        public int NumberCorrect { get; set; }
        public int NumberWrong { get; set; }
    }
}
