using BlazorComponent.Server.AppConfig;
using BlazorComponent.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponent.Server.Repository
{
    public class QuizRepo: IQuizRepo
    {
        private readonly IMongoCollection<CourseQuiz> courseQuizCollection;
        private readonly ILogger<QuizRepo> logger;
        public QuizRepo(IOptions<MongoDBSettings> conectionOptions,
            ILogger<QuizRepo> logger)
        {
            var client = new MongoClient(conectionOptions.Value?.ConnectionString);
            var db = client.GetDatabase(conectionOptions.Value?.DatabaseName);

            var collectionName = "coursequiz";
            var filter = new BsonDocument("name", collectionName);
            var isCollectionExist = db.ListCollections(new ListCollectionsOptions { Filter = filter })
                                      .Any();
            if (!isCollectionExist)
                db.CreateCollection(collectionName);

            courseQuizCollection = db.GetCollection<CourseQuiz>(collectionName);
            this.logger = logger;
        }

        public async Task<CourseQuiz> AddQuizAsync(CourseQuiz courseQuiz)
        {
            await courseQuizCollection.InsertOneAsync(courseQuiz);
            return courseQuiz;
        }

        public async Task<List<CourseQuiz>> GetQuizAsync(string courseId)
        {
            return (await courseQuizCollection.FindAsync(
                courseQuiz => courseQuiz.CourseID == courseId))
                .ToList();
        }
    }
}
