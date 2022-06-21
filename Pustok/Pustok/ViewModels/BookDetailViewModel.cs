using Pustok.Models;
using System.Collections.Generic;

namespace Pustok.ViewModels
{
    public class BookDetailViewModel
    {
        public Book Book { get; set; }
        public List<Book> RelatedBooks { get; set; }
        public BookCommentPostViewModel BookComment { get; set; }
    }
}
