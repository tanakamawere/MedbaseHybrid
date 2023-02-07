using Microsoft.EntityFrameworkCore;
using MedbaseHybrid.Models;
using System.Diagnostics;

namespace MedbaseHybrid.Services
{
    public class DatabaseRepository : IDatabaseRepository
    {
        readonly DataContext context;
        public DatabaseRepository() => context = new DataContext();

        public async Task DeleteTopicAsync(Topic topic)
        {
            context.Questions.RemoveRange(context.Questions.Where(x => x.TopicRef == topic.TopicRef).ToList());
            context.Topics.Remove(topic);
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
        public IQueryable<Question> GetQuizQuestionsAsync(int topicReference, int number)
        {
            return context.Questions.Where(d => d.TopicRef == topicReference)
                    .OrderBy(x => EF.Functions.Random())
                    .Take(number);
        }

        public IQueryable<Session> GetSessionsAsync()
        {
            return context.Sessions;
        }

        public IQueryable<Topic> GetTopicsAsync()
        {
            return context.Topics;
        }

        public async Task SaveSession(Session session)
        {
            context.Sessions.Add(session);
            await context.SaveChangesAsync();
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
