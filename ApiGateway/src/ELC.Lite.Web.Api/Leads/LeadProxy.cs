using ELC.Lite.CoreApp.Api.Leads;
using ELC.Lite.Models.Leads;

namespace ELC.Lite.Web.Api.Leads
{
    public class LeadProxy : ILeadProxy
    {
        private readonly ILeadService _leadService;

        public LeadProxy(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public Task<LeadModel> AddAsync(LeadCreateModel createModel, CancellationToken cancellationToken)
            => _leadService.AddAsync(createModel, cancellationToken);

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
            => _leadService.DeleteAsync(id, cancellationToken);

        public Task<LeadModel> GetByIdAsync(int id, CancellationToken cancellationToken)
            => _leadService.GetByIdAsync(id, cancellationToken);

        public Task<List<LeadModel>> GetListAsync(CancellationToken cancellationToken)
            => _leadService.GetListAsync(cancellationToken);

        public Task<LeadModel> UpdateAsync(LeadUpdateModel updateModel, CancellationToken cancellationToken)
            => _leadService.UpdateAsync(updateModel, cancellationToken);
    }
}
