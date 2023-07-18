using MedbaseHybrid.Models;

namespace MedbaseHybrid.Repositories
{
    public interface IApiRepository
    {
        Task<IEnumerable<Article>> GetArticlesNumbered(int num);
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int id);
        Task<IEnumerable<Topic>> GetTopics(string id);
        Task<Topic> GetTopic(int id);
        Task<IEnumerable<Topic>> GetAllTopics();
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task<IEnumerable<Question>> GetQuestionsSimple(long id);
        Task<Question> GetQuestion(int id);
        Task<QuestionPaged> GetPagedQuestions(int topic, int page, double numResults);
        Task<QuestionPaged> GetSearchPagedQuestions(int topic, int page, double numResults, string keyword);
        Task<IEnumerable<Subscription>> GetSubscriptions();
        Task<Subscription> GetSubscription(string email);
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<IEnumerable<Corrections>> GetCorrections();

        void PostArticle(Article article);
        void PostTopic(Topic topic);
        void PostCourse(Course course);
        void PostQuestion(Question question);
        void PostSubscription(Subscription subscription);

        void DeleteCourse(int id);
        void DeleteQuestion(int id);
        void DeleteTopic(int id);
        void DeleteArticle(int id);
        void DeleteSubscription(int id);

        void UpdateQuestion(int id, Question question);
        void UpdateTopic(int id, Topic topic);
        void UpdateCourse(int id, Course course);
        void UpdateArticle(int id, Article article);
        void UpdateSubscription(int id, Subscription subscription);

        Task<bool> PostCorrection(Corrections corrections);
        Task DeleteCorrection(int id);
        Task MergeCorrections();
        Task MergeOneCorrection(int id);
        Task ClearAllCorrection();
    }
}
