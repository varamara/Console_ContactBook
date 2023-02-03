using Console_ContactBook.Models;
using Console_ContactBook.Services;

namespace Console_ContactBook.Tests_x
{
    public class Menu_Tests
    {

        private Menu menu;
        Contact contact;

        public Menu_Tests()
        {
            menu = new Menu();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            menu.contacts.Add(contact); 
            menu.contacts.Add(contact);

            Assert.Equal(2, menu.contacts.Count);

        }

        [Fact]
        public void Should_Remove_Contact_From_List()
        {
            menu.contacts.Add(contact);
            menu.contacts.Add(contact);

            menu.contacts.Remove(contact);

            Assert.Single(menu.contacts);
        }
    }
}