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

		[HttpGet]
		[Route("FAQList")]
		public IEnumerable<FAQDetailsDto> GetFAQList()
		{
			return _faqService.GetFAQList();
		} 
    }
}
