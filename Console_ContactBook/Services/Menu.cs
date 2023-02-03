using Console_ContactBook.Models;
using Newtonsoft.Json;

namespace Console_ContactBook.Services
{
    public class Menu
    {
        public List<Contact> contacts = new List<Contact>();
        private FileService file = new FileService();

        public string FilePath { get; set; } = null!;

        public void StartMenu ()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath))!;
            }
            catch { }

            Console.WriteLine("CONTACT BOOK");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1. Add contact.");
            Console.WriteLine("2. View all contacts.");
            Console.WriteLine("3. Search contact by name.");
            Console.WriteLine("4. Delete contact by name.");
            Console.WriteLine("Press x to exit");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Choose one alternative from the menu: ");

            var option = Console.ReadLine();

            while (true)
            {
                if (option == "1" || option == "2" || option == "3" || option == "4" || option == "x")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Press any key to return to menu.");
                    Console.ReadKey();
                    break;
                }
            }

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

                case "x":
                    Environment.Exit(0);
                    break;
            }
        }

        private void OptionOne()
        {
            Console.Clear();
            Console.WriteLine("Add a new contact");
            Console.WriteLine("---------------------------------------------");

            Contact contact = new Contact();
            
            Console.Write("Enter Firstname: ");
            contact.FirstName = Console.ReadLine() ?? "";

            Console.Write("Enter Lastname: ");
            contact.LastName = Console.ReadLine() ?? "";

            Console.Write("Enter Home Address: ");
            contact.Address = Console.ReadLine() ?? "";

            Console.Write("Enter Phone Number: ");
            contact.Phone = Console.ReadLine() ?? "";

            Console.Write("Enter e-mail Address:");
            contact.Email = Console.ReadLine() ?? "";

            contacts.Add(contact);
            file.Save(FilePath, JsonConvert.SerializeObject( contacts ));
        }

        private void OptionTwo()
        {
            Console.Clear();
            Console.WriteLine("All contacts");
            Console.WriteLine("---------------------------------------------");

            if (contacts == null || !contacts.Any())
            {
                Console.WriteLine(" ");
                Console.WriteLine("There are no contacts to display.");
                OptionReturn();
                return;
            }

            contacts.ForEach(contact =>
            {
                Console.WriteLine("Name: " + contact.FirstName + " " + contact.LastName);
                Console.WriteLine("Home Address: " + contact.Address);
                Console.WriteLine("Phone Number: " + contact.Phone);
                Console.WriteLine("E-mail Address: " + contact.Email);
                Console.WriteLine("---------------------------------------------");
            });
            OptionReturn();
        }


        private void OptionThree()
        {
            Console.Clear();
            Console.WriteLine("Search for a contact by name");
             Console.WriteLine("---------------------------------------------");
            Console.Write("Enter a name: ");
            var searchName = Console.ReadLine();

            var contact = contacts.Where(c => c.FirstName.Contains(searchName, StringComparison.OrdinalIgnoreCase) || c.LastName.Contains(searchName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (contact != null)
            {
               DisplayContactDetails(contact);
               OptionReturn();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Contact not found.");
                OptionReturn();
            }
        }

        private void OptionFour()
        {
            Console.Clear();
            Console.WriteLine("Enter name of the contact you want to delete: ");
            Console.WriteLine("---------------------------------------------");
            var searchName = Console.ReadLine();

            var contact = contacts.Where(c => c.FirstName.Contains(searchName, StringComparison.OrdinalIgnoreCase) || c.LastName.Contains(searchName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (contact != null)
            {
                DisplayContactDetails(contact);
                contacts.Remove(contact);
                file.Save(FilePath, JsonConvert.SerializeObject(contacts));
                Console.WriteLine(" ");
                Console.WriteLine("Contact deleted.");
                OptionReturn();
            }
            else
            {
                Console.WriteLine("Contact not found.");
                OptionReturn();
            }
        }

        private void DisplayContactDetails(Contact contact)
        {
            Console.Clear();
            Console.WriteLine("Contact information: ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Name: " + contact.FirstName + " " + contact.LastName);
            Console.WriteLine("Address: " + contact.Address);
            Console.WriteLine("Phone: " + contact.Phone);
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("---------------------------------------------");
         
        }

        private void OptionReturn()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
