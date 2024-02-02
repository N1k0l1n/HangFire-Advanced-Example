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

        // Helper function
        [NonAction]
        public void SendWellcomeEmail(string text)
        {
            Console.WriteLine(text);
            // Add your logic here to send a welcome email
        }
        #endregion


    }
}
