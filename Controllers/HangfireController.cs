using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangFireDeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        #region Fire & Forget
        [HttpPost]
        [Route("[action]")]
        public IActionResult Wellcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWellcomeEmail("Welcome to our App"));

            return Ok($"JobId: {jobId}. Welcome email sent to user");
        }


        #endregion

        #region Delayed Jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            var jobId = BackgroundJob.Schedule(() => SendWellcomeEmail("Welcome to our App"), TimeSpan.FromSeconds(30));

            return Ok($"JobId: {jobId}. Discount email sent to user in 30s");
        }
        #endregion

        #region Recurring Job
        [HttpPost]
        [Route("[action]")]
        public IActionResult DatabaseUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("DatabaseUpdated"), Cron.Minutely);

            return Ok("Database Job initiated!");
        }
        #endregion

        // Helper function
        [NonAction]
        public void SendWellcomeEmail(string text)
        {
            Console.WriteLine(text);
            // Add your logic here to send a welcome email
        }
    }
}
