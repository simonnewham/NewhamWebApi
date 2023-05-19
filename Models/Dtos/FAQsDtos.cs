namespace Models;

public class FAQAddDto
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class FAQDetailsDto : FAQAddDto
{
    public int Id { get; set; }
}
