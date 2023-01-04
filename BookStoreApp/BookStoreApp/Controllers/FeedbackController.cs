using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBL feedbackBL;
        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }

        [HttpPost("AddFeedback")]
        public IActionResult AddFeedback(FeedbackModel feedback)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = this.feedbackBL.AddFeedback(feedback, UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Feedback added Successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Feedback not added" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpGet("GetAllFeedback")]
        public IActionResult GetAllFeedback()
        {
            try
            {
                var result = this.feedbackBL.GetAllFeedback();
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Displaying All Feedbacks", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Display failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
