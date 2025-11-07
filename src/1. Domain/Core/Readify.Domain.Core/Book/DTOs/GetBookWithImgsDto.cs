using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readify.Domain.Core.Book.DTOs
{
    public class GetBookWithImgsDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public List<BookImgDto> Imgs { get; set; }
    }
}
