using MedbaseHybrid.Models;

namespace MedbaseHybrid.Services
{
    public interface IDatabaseRepository
    {
        IQueryable<Course> GetCoursesAsync();

        IQueryable<Topic> GetTopicsAsync();
        IQueryable<Question> GetQuestionsAsync(int topicReference);
        IQueryable<Question> GetQuizQuestionsAsync(int topicReference, int number);

        Task SaveTopicAndQuestionsAsync(IEnumerable<Question> questions, Topic topic);

        Task SaveSession(Session session);
        IQueryable<Session> GetSessionsAsync();

        Task DeleteTopicAsync(Topic topic);
    }
}
