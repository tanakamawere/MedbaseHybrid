namespace MedbaseHybrid.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionMain { get; set; }
        public string ChildA { get; set; }
        public string ChildB { get; set; }
        public string ChildC { get; set; }
        public string ChildD { get; set; }
        public string ChildE { get; set; }
        public bool AnswerA { get; set; }
        public bool AnswerB { get; set; }
        public bool AnswerC { get; set; }
        public bool AnswerD { get; set; }
        public bool AnswerE { get; set; }
        public string ExplanationA { get; set; } = string.Empty;
        public string ExplanationB { get; set; } = string.Empty;
        public string ExplanationC { get; set; } = string.Empty;
        public string ExplanationD { get; set; } = string.Empty;
        public string ExplanationE { get; set; } = string.Empty;
        public int TopicRef { get; set; }
    }
}
