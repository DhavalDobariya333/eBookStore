using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class PublisherModel
    {
        public PublisherModel() { }
        public PublisherModel(Publisher publisher)
        {
            Id = publisher.Id;
            Name = publisher.Name;
            Address = publisher.Address;
            Contact = publisher.Contact;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
