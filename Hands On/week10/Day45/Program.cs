namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContactService service = new ContactService();

            service.AddContact(new Contact
            {
                Name = "Jaya",
                Email = "jaya@gmail.com",
                Phone = "9988776655"
            });

            var contacts = service.GetAllContacts();

            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Id} - {c.Name}");
            }
        }
    }
}
