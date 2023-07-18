namespace MedbaseHybrid.Models
{
    public class Corrections
    {
        public int Id { get; set; }
            public int QuestionId { get; set; }
        public string QuestionChild { get; set; } 
            public bool SuggestedAnswer { get; set; } 
            public string SuggestedExplanation { get; set; }
    }
}
