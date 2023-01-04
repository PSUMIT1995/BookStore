using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        private IFeedbackRL feedbackRL;

        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }

        public bool AddFeedback(FeedbackModel feedback, int UserId)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedback, UserId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<FeedbackModel> GetAllFeedback()
        {
            try
            {
                return this.feedbackRL.GetAllFeedback();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
