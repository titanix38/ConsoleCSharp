using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormationLibrary;
using System.Collections.Generic;

namespace FormationTest
{
    [TestClass]
    public class TestLibrary
    {
        [TestMethod]
        public void TestBook()
        {
            Book b = new Book { Id = 1, Title = "Java pour les noobs", NbPage = 1298, Price = 10.00, Category = Category.Computer };
            Assert.AreEqual(1,b.Id);
            Assert.AreEqual(10.50,b.VATPrice, 0.1);

        }
        [TestMethod]
        public void TestAuthor()
        {
            Author a = new Author { Id = 1, Name = "Vincent", FirstName = "Cyril" };
            Assert.AreEqual( "Cyril",a.FirstName);
        }

        [TestMethod]
        public void TestPublisher()
        {
            Publisher p = new Publisher { Id = 1, Name = "CastorMan" };
            Assert.AreEqual(1,p.Id);
            Assert.AreEqual("CastorMan", p.Name);
        }

        [TestMethod]
        public void TestBook2()
        {
            List<Author> la = new List<Author>();

            Author a1 = new Author { Id = 1,Name="Trueman",FirstName="Armand" };
            Author a2 = new Author { Id = 2, Name = "Trueman", FirstName = "Cyndi" };
            la.Add(a1);
            la.Add(a2);

            Publisher p = new Publisher { Id = 1, Name="CastorMan" };

            Book b = new Book { Id = 1, Title = "C# pour les newbies", Authors = la, Publisher = p,Category = Category.Computer,Price = 10.00 };
            Assert.IsNotNull(b);
            Assert.AreEqual("CastorMan",b.Publisher.Name,  "Verifier le nom ou la casse");
            Assert.AreEqual("Armand",b.Authors[0].FirstName,  "Verifier le nom ou la casse");
            Assert.AreEqual(10.50,b.VATPrice,"Prix TTC non conforme");

        }
    }
}
