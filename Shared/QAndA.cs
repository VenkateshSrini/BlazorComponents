using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace BlazorComponent.Shared
{
   public class QAndA
    {
        public string QuestionID { get; set; }
        public string QuestionText { get; set; }
        public StringCollection AnswerKeys { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
