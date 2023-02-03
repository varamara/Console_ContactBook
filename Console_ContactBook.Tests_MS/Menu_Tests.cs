using Console_ContactBook.Services;
using Console_ContactBook.Models;

namespace Console_ContactBook.Tests_MS
{
    [TestClass]
    public class Menu_tests
    {
        [TestMethod]
        public void Should_Add_Contact_To_List()
        {
            Menu menu = new Menu();
            Contact contact = new Contact();

            menu.contacts.Add(contact);

            Assert.AreEqual(1, menu.contacts.Count);
        }

        [TestMethod]
        public void Should_Remove_Contact_From_List()
        {
            Menu menu = new Menu();
            Contact contact = new Contact();

            menu.contacts.Remove(contact);

            Assert.AreEqual(0, menu.contacts.Count);

        }
    }
}