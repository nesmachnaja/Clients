using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clients.Model
{
    public class ClientProfile
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Doc { get; set; }

        public static explicit operator ClientProfile(string v)
        {
            throw new NotImplementedException();
        }
    }
}
