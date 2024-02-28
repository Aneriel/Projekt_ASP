using Core.Models;

namespace Projekt.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; } = new Book();
        public List<Author> Authors { get; set; } = [];
        //public List<PublishingHouse> PublishingHouses { get; set; }
    }
}
