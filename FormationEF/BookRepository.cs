using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public class BookRepository : AbstractRepository<Book>
    {
        //public FormationEFEntities Entities { get; set; }
        //public override List<Book> GetAll()
        //{
        //    return entities.Book.ToList();
        //}

        //public override Book GetById(int id)
        //{
        //    Func<Book, bool> f = book => book.Id.Equals(id);
        //    List<Book> lb = new List<Book>();
        //    lb = entities.Book.Where(f).ToList();
        //    return lb.First();
        //}

        public override IEnumerable<Book> GetByLambda(Func<Book, bool> where)
        {
            return Entities.Book.Where(where);
        }

        public IEnumerable<Book> GetByPrice(decimal price = Decimal.MaxValue)
        {

            return GetByLambda(book => book.Price <= price);
        }

        public IEnumerable<Book> GetByTitle(string word)
        {
            return GetByLambda(book => book.Title.ToLower().Contains(word.ToLower()));
        }

        //public override Book Insert(Book entity)
        //{
        //    Entities.Book.Add(entity);
        //    return entity;
        //}

        public override void Remove(Book entity)
        {
            Entities.Book.Remove(entity);
        }

        //public override void Save(Book entity)
        //{
        //    Entities.SaveChanges();                 // SaveChanges => commit de la transaction
        //}
    }
}
