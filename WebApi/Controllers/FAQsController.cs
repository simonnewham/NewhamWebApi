using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebApi.Controllers
{
    [ApiController]
	[Route("FAQs")]
	public class FAQsController
	{
		private readonly IFAQService _faqService;

		public FAQsController(IFAQService faqService)
		{
			_faqService = faqService;
		}

		/// <summary>
		/// Get a list of frequently asked questions
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("FAQList")]
		public IEnumerable<FAQDetailsDto> GetFAQList()
		{
			return _faqService.GetFAQList();
		}

        /// <summary>
        /// Add a new frequently asked question
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
		[Authorize]
        public FAQDetailsDto Add(FAQAddDto requestModel)
		{ 
            return _faqService.Add(requestModel);
        }
    }
}
