using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public class BookModel
    {
        private BookRepository br = new BookRepository { Entities = new FormationEFEntities() };

        public Book Book { get; set; }

        public int Id { get; set; }

        public string Display()
        {            
            Book = br.GetById(Id);
            if (Book == null)
            {
                return "Err : Unknown Id";
            }

            return Book.Title;

        }

        public string Price()
        {
            Book = br.GetById(Id);            

            return Book.Price.ToString();
        }
        
    }
}
