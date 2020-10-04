using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clients.Model
{
    public class Document
    {
        public int ClientId { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public string DateBeg { get; set; }
        public string DateEnd { get; set; }
    }
}
