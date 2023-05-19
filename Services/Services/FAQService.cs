using Models;
using DataLayer;
using DataLayer.Data;

namespace Services
{
    public class FAQService : IFAQService
    {
        private readonly DataContext _dataContext;

        public FAQService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<FAQDetailsDto> GetFAQList()
        {  
           return _dataContext.FAQs.Select(t => new FAQDetailsDto
            {
                Id = t.Id,
                Question = t.Question,
                Answer = t.Answer
            }).ToList();
        }

        public FAQDetailsDto Add(FAQAddDto requestModel)
        {
            var faq = _dataContext.FAQs.Add(new FAQ
            {
                Question = requestModel.Question,
                Answer = requestModel.Answer
            });

            _dataContext.SaveChanges();

            // TODO: Automapper
            return new FAQDetailsDto
            {
                Id = faq.Entity.Id,
                Question = faq.Entity.Question,
                Answer = faq.Entity.Answer
            };
        }

        //private IEnumerable<FAQ> FAQs
        //{
        //    get => new List<FAQ>()
        //    {         
        //        new FAQ
        //        {
        //            Id = 1,
        //            Question = "What does a Consultation include and what does it cost?",
        //            Answer = "A consultation costs R2000."
        //        },
        //        new FAQ
        //        {
        //            Id = 2,
        //            Question = "What is a follow up visit and what does that cost?",
        //            Answer = "A visit that follows."
        //        }
        //    };
        //}
    }
}
