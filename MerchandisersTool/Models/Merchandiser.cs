using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisersTool.Models
{
    public class Merchandiser
    {
        [PrimaryKey]
        public int merchId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string merchPhoneNo { get; set; }

        public override string ToString()
        {
            return firstName + lastName + merchPhoneNo;
        }

    }
}
