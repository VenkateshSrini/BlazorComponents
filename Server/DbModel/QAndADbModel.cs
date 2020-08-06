using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using BlazorComponent.Shared;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;


namespace BlazorComponent.Server.DbModel
{

    public class QAndADbModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string QuestionID { get; set; }
        [BsonElement("QuestionText")]
        public string QuestionText { get; set; }
        [BsonElement("AnswerKeys")]
        public StringCollection AnswerKeys { get; set; }
        [BsonElement("Answers")]
        public List<AnswerDbModel> Answers { get; set; }
        [BsonElement("AnswerType")]
        public ResponseType AnswerType { get; set; }
    }
}
