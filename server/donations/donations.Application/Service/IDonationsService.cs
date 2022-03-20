using donations.Application.Models;
using donations.DM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace donations.Application.Service
{
    public interface IDonationsService
    {
        Task Create(DonationRequest item);
        Task Update(int id, DonationRequest item);
        Task Delete(int id);
        Task<List<Donation>> Get();
        Task<Donation> GetById(int id);
    }
}
