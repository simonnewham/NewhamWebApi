using AutoMapper;
using DataLayer.Data;

namespace UnitTests;

[TestClass]
public class FAQServiceTests
{
    private readonly FAQService _sut;

    private readonly DataContext _dataContext = new DataContext(); // in memory
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

    public FAQServiceTests()
    {
        _sut = new FAQService(_dataContext, _mapperMock.Object);
    }

    [TestMethod]
    public void FAQAddTest()
    {
        // Arrange
        _dataContext.FAQs.Add(new FAQ
        {
            Id = 1,
            Question = "Test Question",
            Answer = "Test Answer"
        });
        _dataContext.SaveChanges();

        // Act
        var faqList = _sut.GetFAQList();

        // Assert
        Assert.AreEqual(1, faqList.Count());
        Assert.AreEqual("Test Question", faqList.Single().Question);

    }
}
