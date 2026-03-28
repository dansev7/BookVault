namespace BookVaultApi.Models;

public class Book
{
    public int Id { get; set; } 

    public required string Title { get; set; } 

    public required string Author { get; set; }

    public string ISBN { get; set; } = string.Empty;

    public DateTime PublishedDate { get; set; }

    public bool IsAvailable { get; set; } = true;
}