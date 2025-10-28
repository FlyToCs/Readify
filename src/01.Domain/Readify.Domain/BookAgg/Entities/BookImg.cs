using Readify.Domain._common.Entities;

namespace Readify.Domain.BookAgg.Entities;

public class BookImg : BaseEntity
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }  
    public bool IsMainImg { get; set; }      

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}