using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class GetCartModel
    {
        public GetCartModel(int Id, int Userid, BookModel Book, int Quantity)
        {
            this.Id = Id;
            this.Userid = Userid;
            this.Book = Book;
            this.Quantity = Quantity;
        }
        public int Id { get; set; }
        public int Userid { get; set; }
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}

