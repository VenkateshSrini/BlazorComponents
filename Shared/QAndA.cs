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
        public StringCollection AnswerKeys { get; set; } = new StringCollection();
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public ResponseType AnswerType { get; set; }
    }
}
