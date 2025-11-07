

using Readify.Domain.Core._common.Entities;

namespace Readify.Domain.Core.Book.Entities;

public class BookImg : BaseEntity
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }  
    public bool IsMainImg { get; set; }      

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}