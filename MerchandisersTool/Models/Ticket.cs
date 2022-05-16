using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisersTool.Models
{
    public class Ticket
    {
        [PrimaryKey]
        public int ticketId { get; set; }
        public string displayName { get; set; }
        public string store { get; set; }
        public string location { get; set; }
        public string duration { get; set; }
        public string note { get; set; }

        public override string ToString()
        {
            return displayName +  store +  location +  duration + note;
        }

    }
}
