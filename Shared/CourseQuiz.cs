using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorComponent.Shared
{
    public class CourseQuiz
    {
        public string CourseID { get; set; }
        public List<QAndA> Quiz { get; set; }
    }
}
