using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormationEF;
using System.Collections.Generic;
using System.Linq;

namespace EFUnitTestProject
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void TestListBook()
        {
            FormationEFEntities entities = new FormationEFEntities();
            List<Book> lb = entities.Book.ToList();
            Assert.IsNotNull(lb);
            Assert.AreEqual(2, lb[0].Id);
        }
        [TestMethod]
        public void TestInsertBook()
        {
            //Get All
            FormationEFEntities entities = new FormationEFEntities();
            List<Book> lb = entities.Book.ToList();
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Insert
            Book b = new Book { Title = "Entity, une révolution", Price = 9.99m };
            entities.Book.Add(b);
            entities.SaveChanges();                         // Transaction implicite

            //  Update
            b = entities.Book.First();
            b.Price += 1;
            entities.SaveChanges();                         // Transaction implicite

            // Get By Id
            b = entities.Book.Find(2);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            // LinQ = Language INtegrated Query (Limité)
            //  Intellisense (avantage par rapport à JPQL)
            IEnumerable<Book> ie = from book in entities.Book
                                   where book.Price < 10
                                   orderby book.Id
                                   select book;
            IEnumerable<Book> ie2 = from book in entities.Book
                                    where book.Title.ToUpper().Contains("NEWBIES")
                                    orderby book.Id
                                    select book;
            IEnumerable<Book> ie3 = ie2.Intersect(ie);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //  Lambda Expression (Orienté objet)
            // Plus puissants que LinQ
            ie = entities.Book.Where(book => book.Price < 10).OrderBy(book => book.Id);
            ie2 = entities.Book.Where(book => book.Title.ToUpper().Contains("NEWBIES")).OrderBy(book => book.Id);

            Func<Book, bool> f = book => book.Title.ToUpper().Contains("NEWBIES");
            ie2 = entities.Book.Where(f);

            // => donne (f(x) = x+1 : x => x+1
            //entities.Set<Book>() <=> entities.Book;

            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };
            br.GetByPrice(price: 10.00m);

            string s = "toto";
            s.ToUpperFirstLetter();            

        }
        [TestMethod]
        public void GetAll()
        {            
            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };
            IEnumerable<Book> lb = br.GetAll();
            Assert.IsNotNull(lb);
        }
        [TestMethod]
        public void GetById()
        {           
            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };
            Book b = new Book();
            b = br.GetById(2);
            Assert.AreEqual(2, b.Id);
        }
        [TestMethod]
        public void GetByPrice()
        {
            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };
            IEnumerable<Book> lb = br.GetByPrice(15.00m);
            Assert.IsNotNull(lb);
        }
        [TestMethod]
        public void GetByTitle()
        {            
            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };
            IEnumerable<Book> lb = br.GetByTitle("java");
            Assert.IsNotNull(lb);
        }
        [TestMethod]
        public void InsertTest()
        {

            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };
            
            Book b = new Book();

            b.Title = "C++ Le dinosaure";
            b.Price = 11;
            Assert.IsNotNull(b);

            br.Insert(b);
            br.Save();
            Assert.AreEqual("C++ Le dinosaure", b.Title);
            Assert.IsNotNull(b);
        }
        [TestMethod]
        public void RemoveTest()
        {

            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };

            Book b = new Book();
            
            b= br.GetById(7);
            br.Remove(b);
            br.Save();
            b = br.GetById(7);
            Assert.IsNull(b);
        }
        [TestMethod]
        public void RemoveTest()
        {

        }
}
