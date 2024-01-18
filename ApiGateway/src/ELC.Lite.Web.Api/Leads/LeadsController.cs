using ELC.Lite.Models.Leads;
using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api.Leads
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : BaseController
    {
        private readonly ILeadProxy _leadsProxy;

        public LeadsController(ILeadProxy leadsProxy)
        {
            _leadsProxy = leadsProxy;
        }


        [HttpPost]
        public async Task<ActionResult<LeadModel>> AddAsync(LeadCreateModel leadCreateModel, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var leadModel = await _leadsProxy.AddAsync(leadCreateModel, cancellationToken);
            return Ok(leadModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            await _leadsProxy.DeleteAsync(id, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeadModel>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var leadModel = await _leadsProxy.GetByIdAsync(id, cancellationToken);
            return Ok(leadModel);
        }

        [HttpGet]
        public async Task<ActionResult<List<LeadModel>>> GetAsync(CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var leadModel = await _leadsProxy.GetListAsync(cancellationToken);
            return Ok(leadModel);
        }

        [HttpPut]
        public async Task<ActionResult<LeadModel>> UpdateAsync(LeadUpdateModel leadUpdateModel, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var leadModel = await _leadsProxy.UpdateAsync(leadUpdateModel, cancellationToken);
            return Ok(leadModel);
        }
    }
}
