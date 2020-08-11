using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorComponent.Shared
{
    public class CourseQuiz
    {
        [Required]
        public string CourseID { get; set; }
        public List<QAndA> Quiz { get; set; } 
    }
}
