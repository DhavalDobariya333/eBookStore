using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class BookModel
    {
        public BookModel() { }
        public BookModel(Book book) 
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.Price = book.Price;
            this.Description = book.Description;
            this.Base64image = book.Base64image;
            this.Categoryid = book.Categoryid;
            this.Publisherid = book.Publisherid;
            this.Quantity = book.Quantity;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Base64image { get; set; }
        public int Categoryid { get; set; }
        public int? Publisherid { get; set; }
        public int? Quantity { get; set; }
    }
}
