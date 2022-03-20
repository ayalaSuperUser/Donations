using donations.DAL.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using donations.Application.Models;
using AutoMapper;
using donations.DM.Models;
using System;
using SMTP.Services;

namespace donations.Application.Service
{
    public class DonationsService : IDonationsService
    {
        IDonationsContext _context;
        int currentId = 0;
        IMapper _mapper;
        IMailService _mailService;
        public DonationsService(IDonationsContext context, IMailService mailService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _mailService = mailService;
        }

        public Task<List<Donation>> Get()
        {
            return Task.Run(() => _context.Donations);
        }

        public Task<Donation> GetById(int id)
        {
            return Task.Run(() => getDonation(id));
        }

        public Task Create(DonationRequest request)
        {
            var item = _mapper.Map<Donation>(request);
            item.Id = currentId++;
            return Task.Run(() =>
            {
                _context.Donations.Add(item);
                CheckSendMail(item);
            });
         
        }

        private void CheckSendMail(Donation item)
        {
            if (item.Amount > 10000)
            {
                _mailService.SendEmail(new SMTP.Models.MailRequest()
                {
                    MailReciepient = "ayalakrauss@gmail.com",
                    Subject = "Thank you mail",
                    Body = "Thank for your donation, We really appreciate it"
                });
            }
        }

        private Donation getDonation(int id)
        {
            var donation = _context.Donations.Find(d => d.Id == id);
            if (donation == null) throw new KeyNotFoundException("donation not found");
            return donation;
        }
        public Task Update(int id, DonationRequest request)
        {
            return Task.Run(() =>
            {
                var d = getDonation(id);
                if (d != null)
                {
                    _context.Donations.Remove(d);
                    var item = _mapper.Map<Donation>(request);
                    item.Id = id;
                    _context.Donations.Add(item);
                    CheckSendMail(item);
                }
            });
        }
        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                var d = getDonation(id);
                if (d != null)
                {
                    _context.Donations.Remove(d);
                }
            });
        }
    }
}
