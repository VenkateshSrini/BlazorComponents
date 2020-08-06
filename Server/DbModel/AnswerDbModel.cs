using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
namespace BlazorComponent.Server.DbModel
{
    public class AnswerDbModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string AnswerId { get; set; }
        [BsonElement("AnswerKey")]
        public string AnswerKey { get; set; }
        [BsonElement("AnswerText")]
        public string AnswerText { get; set; }
    }
}
