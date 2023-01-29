using Console_ContactBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ContactBook.Services
{
    internal class Menu
    {
        private List<Contact> contacts = new List<Contact>();
        private FileService file = new FileService();

        public string FilePath { get; set; } = null!;

        public void StartMenu ()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath))!;
            }
            catch { }

            Console.WriteLine("Choose an option.");
            Console.WriteLine("1. Add contact.");
            Console.WriteLine("2. View all contacts.");
            Console.WriteLine("3. Search contact by name.");
            Console.WriteLine("4. Delete contact by name.");
            Console.WriteLine("Press X to exit");


            Console.WriteLine("Choose one alternative from the menu: ");
            var option = Console.ReadLine();

            
           

            switch (option)
            {
                case "1":
                    OptionOne();
                    break;

                case "2":
                    OptionTwo();
                    break;
                case "3":
                    OptionThree();
                    break;

                case "4":
                    OptionFour();
                    break;

                case "X":
                    break;
            }

        }

        private void OptionOne()
        {

            Console.Clear();
            Console.WriteLine("Add a new contact");


            Contact contact = new Contact();
            

            Console.Write("Ange förnamn: ");
            contact.FirstName = Console.ReadLine() ?? "";

            Console.Write("Ange efternamn: ");
            contact.LastName = Console.ReadLine() ?? "";

            Console.Write("Ange adress: ");
            contact.Address = Console.ReadLine() ?? "";

            Console.Write("Ange telefonnummer: ");
            contact.Phone = Console.ReadLine() ?? "";

            Console.Write("Ange E-postadress:");
            contact.Email = Console.ReadLine() ?? "";

            contacts.Add(contact);
            file.Save(FilePath, JsonConvert.SerializeObject( contacts ));
 
        }

        private void OptionTwo()
        {
            Console.Clear();
            Console.WriteLine("View all contacts");
            Console.WriteLine("");

            contacts!.ForEach(contact => Console.WriteLine("Namn: " + contact.FirstName + " " + contact.LastName + "   " + "Email: " + contact.Email));
            Console.WriteLine("");
            Console.WriteLine("Press any key to get to the startpage.");
            Console.ReadKey();
            
        }

        private void OptionThree()
        {
            Console.Clear();
            Console.WriteLine("Search for a contact by name");
            Console.Write("Enter a name: ");
            var searchName = Console.ReadLine();

            var contact = contacts.Where(c => c.FirstName.Contains(searchName, StringComparison.OrdinalIgnoreCase) || c.LastName.Contains(searchName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (contact != null)
            {
                Console.WriteLine("Name: " + contact.FirstName + " " + contact.LastName);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("Phone: " + contact.Phone);
                Console.WriteLine("Email: " + contact.Email);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }




        private void OptionFour()
        {

        }


    }
}

