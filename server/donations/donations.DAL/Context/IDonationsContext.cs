using donations.DM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace donations.DAL.Context
{
    public interface IDonationsContext
    {
       
        public List<Donation> Donations { get; set; }
        
    }
}
