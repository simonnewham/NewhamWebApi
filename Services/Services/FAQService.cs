using Models;
using DataLayer;
using DataLayer.Data;
using AutoMapper;

namespace Services
{
    public class FAQService : IFAQService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public FAQService(DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IEnumerable<FAQDetailsDto> GetFAQList()
        {  
           return _dataContext.FAQs.Select(t => _mapper.Map<FAQDetailsDto>(t))
                .ToList();
        }

        public FAQDetailsDto Add(FAQAddDto requestModel)
        {
            var faq = _dataContext.FAQs.Add(new FAQ
            {
                Question = requestModel.Question,
                Answer = requestModel.Answer
            });

            _dataContext.SaveChanges();

            return _mapper.Map<FAQDetailsDto>(faq.Entity);
        }
    }
}
