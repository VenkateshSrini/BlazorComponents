using BlazorComponent.Server.AppConfig;
using BlazorComponent.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
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
            if (!BsonClassMap.IsClassMapRegistered(typeof(CourseQuiz)))
                BsonClassMap.RegisterClassMap<CourseQuiz>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(c => c.id)
                        .SetIdGenerator(StringObjectIdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.ObjectId));
                });
        }

        public async Task<CourseQuiz> AddQuizAsync(CourseQuiz courseQuiz)
        {
            courseQuiz.id = ObjectId.GenerateNewId().ToString();
            await courseQuizCollection.InsertOneAsync(courseQuiz);
            return courseQuiz;
        }

        public async Task<CourseQuiz> GetQuizAsync(string courseId)
        {
            return (await courseQuizCollection.FindAsync(
                courseQuiz => courseQuiz.CourseID == courseId))
                .FirstOrDefault();
        }
    }
}
