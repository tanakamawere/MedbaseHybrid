using Microsoft.EntityFrameworkCore;
using MedbaseComponents.Models;
using System.Diagnostics;

namespace MedbaseHybrid.Services
{
    public class DatabaseRepository : IDatabaseRepository
    {
        readonly DataContext context;
        public DatabaseRepository() => context = new DataContext();

        public async Task DeleteTopicAsync(int topic)
        {
            context.Questions.RemoveRange(context.Questions.Where(x => x.TopicRef == topic).ToList());
            context.Topics.Remove(context.Topics.Where(x => x.TopicRef == topic).First());
            await context.SaveChangesAsync();
        }

        public IQueryable<Course> GetCoursesAsync()
        {
            return context.Courses;
        }

        public IQueryable<Question> GetQuestionsAsync(int topicReference)
        {
            return context.Questions.Where(x => x.TopicRef == topicReference);
        }

        public async Task<QuestionPaged> GetQuestionsPaged(int topic, int page, double numResults)
        {
            var pageResults = numResults;
            var pageCount = Math.Ceiling(context.Questions.Where(x => x.TopicRef == topic).Count() / pageResults);

            var products = await context.Questions
                .Where(x => x.TopicRef == topic)
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new QuestionPaged
            {
                Questions = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }

        public IQueryable<Question> GetQuizQuestionsAsync(int topicReference, int number)
        {
            return context.Questions.Where(d => d.TopicRef == topicReference)
                    .OrderBy(x => EF.Functions.Random())
                    .Take(number);
        }

        public async Task<QuestionPaged> GetSearchQuestionsPaged(int topic, int page, double numResults, string keyword)
        {
            var pageResults = numResults;
            var pageCount = Math.Ceiling(context.Questions.Where(x => x.TopicRef == topic).Count() / pageResults);

            var products = await context.Questions
                .Where(x => x.TopicRef == topic)
                .Where(x => x.QuestionMain.Contains(keyword))
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new QuestionPaged
            {
                Questions = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }

        public IQueryable<Topic> GetTopicsAsync()
        {
            return context.Topics;
        }

        public async Task SaveTopicAndQuestionsAsync(IEnumerable<Question> questions, Topic topic)
        {
            try
            {
                await context.Questions.AddRangeAsync(questions);
                await context.Topics.AddAsync(topic);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
