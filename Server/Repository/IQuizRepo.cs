using BlazorComponent.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponent.Server.Repository
{
    public interface IQuizRepo
    {
        Task<CourseQuiz> AddQuizAsync(CourseQuiz courseQuiz);
        Task<List<CourseQuiz>> GetQuizAsync(string courseId);
    }
}
