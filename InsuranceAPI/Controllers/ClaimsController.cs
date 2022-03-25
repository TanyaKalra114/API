using Microsoft.AspNetCore.Mvc;
using InsuranceAPI.Data;
using InsuranceAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : Controller
    {

        private readonly CustomerDbContext claimDbContext;
        public ClaimsController(CustomerDbContext claimDbContext)
        {
            this.claimDbContext = claimDbContext;
        }



        //get all claims
        [HttpGet]
        public async Task<IActionResult> GetAllClaims()
        {
            var claims = await claimDbContext.Claims.ToListAsync();
            return Ok(claims);
        }

        //get a single claim
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetClaims")]
        public async Task<IActionResult> GetClaims([FromRoute] Guid id)
        {
            var claims = await claimDbContext.Claims.FirstOrDefaultAsync(x => x.claim_id == id);
            if (claims != null)
            {
                return Ok(claims);
            }
            return NotFound("Claim not found");
        }


        //get a single car
        [HttpPost]

        public async Task<IActionResult> AddClaim([FromBody] Claim claim)
        {
            claim.claim_id = Guid.NewGuid();
            await claimDbContext.Claims.AddAsync(claim);
            await claimDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClaims), new { id = claim.claim_id }, claim);
        }


        //Updating a car

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateClaim([FromRoute] Guid id, [FromBody] Claim claim)
        {
            var existingClaim = await claimDbContext.Claims.FirstOrDefaultAsync(x => x.claim_id == id);
            if (existingClaim != null)
            {
                existingClaim.policy_no = claim.policy_no;
                existingClaim.policy_type = claim.policy_type;
                
                await claimDbContext.SaveChangesAsync();
                return Ok(existingClaim);
            }
            return NotFound("Claim not found");
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteClaim([FromRoute] Guid id)
        {
            var existingClaim = await claimDbContext.Claims.FirstOrDefaultAsync(x => x.claim_id == id);
            if (existingClaim != null)
            {
                claimDbContext.Remove(existingClaim);                
                

                await claimDbContext.SaveChangesAsync();
                return Ok(existingClaim);
            }
            return NotFound("Claim not found");
        }


    }
}
