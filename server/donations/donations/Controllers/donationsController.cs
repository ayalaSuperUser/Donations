using donations.Application.Models;
using donations.Application.Service;
using donations.DM.Models;
using Microsoft.AspNetCore.Mvc;
using SMTP.Services;
using System.Threading.Tasks;

namespace donations
{
    [ApiController]
    [Route("[controller]")]
    public class donationsController : ControllerBase
    {
        private IDonationsService _donationsService;

        public donationsController(IDonationsService donationsService)
        {
            _donationsService = donationsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _donationsService.Get();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _donationsService.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DonationRequest request)
        {
            if (ModelState.IsValid)
            {
                await _donationsService.Create(request);

                return Ok(new { Message = "Add new donation successfully" });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DonationRequest item)
        {
            if (ModelState.IsValid)
            {
                await _donationsService.Update(id, item);
                return Ok(new { Message = $"Updated id={id} donation successfully" });
            }
            else
            {
                return BadRequest(ModelState);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _donationsService.Delete(id);
                return Ok(new { Message = $"Delete id={id} donation successfully" });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
