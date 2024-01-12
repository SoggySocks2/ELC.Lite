using ELC.Lite.Models.Leads;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api.Leads
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadProxy _leadsProxy;

        public LeadsController(ILeadProxy leadsProxy)
        {
            _leadsProxy = leadsProxy;
        }

        [HttpPost]
        public async Task<LeadModel> AddAsync(LeadCreateModel leadCreateModel, CancellationToken cancellationToken)
        {
            return await _leadsProxy.AddAsync(leadCreateModel, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _leadsProxy.DeleteAsync(id, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<LeadModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _leadsProxy.GetByIdAsync(id, cancellationToken);
        }

        [HttpGet]
        public async Task<List<LeadModel>> GetAsync(CancellationToken cancellationToken)
        {
            return await _leadsProxy.GetListAsync(cancellationToken);
        }

        [HttpPut]
        public async Task<LeadModel> UpdateAsync(LeadUpdateModel leadUpdateModel, CancellationToken cancellationToken)
        {
            return await _leadsProxy.UpdateAsync(leadUpdateModel, cancellationToken);
        }
    }
}
