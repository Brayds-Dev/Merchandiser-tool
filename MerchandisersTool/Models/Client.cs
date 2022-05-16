using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace MerchandisersTool.Models
{
    public class Client
    {
        [PrimaryKey]
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string location { get; set; }
        public string phoneNo { get; set; }

        public override string ToString()
        {
            return clientName +  location +  phoneNo;
        }


    }
}
