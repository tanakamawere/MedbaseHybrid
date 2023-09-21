namespace MedbaseHybrid.Services
{
    public class MedbaseApiService : RestServiceBase, IApiRepository 
    {
        public MedbaseApiService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
        {
            SetBaseURL(Constants.apiUrl);
        }

        public Task ClearAllCorrection()
        {
            throw new NotImplementedException();
        }

        public void DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCorrection(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubscription(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTopic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetAllTopics()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetArticles()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetArticlesNumbered(int num)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Corrections>> GetCorrections()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourse(int id)
        {
            return GetAsync<Course>($"/courses/{id}");
        }

        public async Task<CourseArticlesDto> GetCourseArticlesDto()
        {
            return await GetAsync<CourseArticlesDto>("/dashboard/getall");
        }

        public Task<IEnumerable<Course>> GetCourses()
        {
            return GetAsync<IEnumerable<Course>>("/courses");
        }

        public Task<QuestionPaged> GetPagedQuestions(int topic, int page, double numResults)
        {
            return GetAsync<QuestionPaged>($"questions/{topic}/{numResults}/{page}");
        }

        public Task<Question> GetQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetQuestionsSimple(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetQuizQuestions(int topic, int number)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionPaged> GetSearchPagedQuestions(int topic, int page, double numResults, string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> GetSubscription(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetTopics(string id)
        {
            throw new NotImplementedException();
        }

        public Task MergeCorrections()
        {
            throw new NotImplementedException();
        }

        public Task<bool> MergeOneCorrection(int id)
        {
            throw new NotImplementedException();
        }

        public void PostArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostCorrection(Corrections corrections)
        {
            throw new NotImplementedException();
        }

        public void PostCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void PostQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void PostSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public void PostTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(int id, Article article)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestion(int id, Question question)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubscription(int id, Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public void UpdateTopic(int id, Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
