using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Contact
    {
        // Unique Id for each contact
        public int Id {  get; set; }
        // Contact name
        public string Name { get; set; } = string.Empty;
        //Email
        public string Email { get; set; }=string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
