using donations.DM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace donations.DAL.Context
{
    public class DonationsContext : IDonationsContext
    {
        public DonationsContext()
        {
            Donations = new List<Donation>();
        }

        public List<Donation> Donations { get; set; }
    }
}
