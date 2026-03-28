using System.ComponentModel.DataAnnotations;

namespace BookVaultApi.DTOs;

public class CreateBookDto
{
    [Required] 
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    public string ISBN { get; set; } = string.Empty;
}