using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace BlazorComponent.Shared
{
   public class QAndA
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public List<string> AnswerKeys { get; set; } = new List<string>();
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public ResponseType AnswerType { get; set; }
    }
}
