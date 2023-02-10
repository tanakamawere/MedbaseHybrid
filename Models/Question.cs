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
        public string ExplanationA { get; set; } = "";
        public string ExplanationB { get; set; } = "";
        public string ExplanationC { get; set; } = "";
        public string ExplanationD { get; set; } = "";
        public string ExplanationE { get; set; } = "";
        public int TopicRef { get; set; }
    }
}
