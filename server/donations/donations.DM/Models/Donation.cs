using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace donations.DM.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        public float Amount { get; set; }
        public string EntityName { get; set; }
        public Entity EntityType { get; set; }
        public string Destiny { get; set; }
        public string Conditions { get; set; }
        public Coin Coin { get; set; }
        public float ExchangeRate { get; set; }
    }
}
