using Models;

namespace Services
{
    public interface IFAQService
	{
        IEnumerable<FAQDetailsDto> GetFAQList();
    }
}
