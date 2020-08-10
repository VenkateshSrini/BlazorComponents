using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent.Server.Repository;
using BlazorComponent.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorComponent.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QAndAController : ControllerBase
    {
        readonly IQuizRepo quizRepo;
        readonly ILogger<QAndAController> logger;
        public QAndAController(IQuizRepo quizRepo, ILogger<QAndAController> logger)
        {
            this.quizRepo = quizRepo;
            this.logger = logger;
        }
        public async Task<ActionResult<CourseQuiz>> Add(CourseQuiz courseQuiz)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return  Ok(await quizRepo.AddQuizAsync(courseQuiz));
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Unable to add course object failed with exception {ex.Message} and " +
                    $"stack trace {ex.StackTrace}");
                return StatusCode(500, new
                {
                    ErroMsg = "Failed to add CourseQuiz",
                    Status = 500
                });
            }
        }
        public async Task<ActionResult<CourseQuiz>> GetQuiz(string courseId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(courseId))
                    return Ok(await quizRepo.GetQuizAsync(courseId));
                else
                    return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                logger.LogInformation($"Unable to Get course object failed with exception {ex.Message} and " +
                    $"stack trace {ex.StackTrace}");
                return StatusCode(500, new
                {
                    ErroMsg = "Failed to Get CourseQuiz",
                    Status = 500
                });
            }
        }
    }
}
