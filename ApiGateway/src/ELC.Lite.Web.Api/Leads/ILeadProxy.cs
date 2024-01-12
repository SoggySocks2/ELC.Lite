using ELC.Lite.Models.Leads;

namespace ELC.Lite.Web.Api.Leads
{
    public interface ILeadProxy
    {
        Task<LeadModel> AddAsync(LeadCreateModel createModel, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<LeadModel> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<LeadModel>> GetListAsync(CancellationToken cancellationToken);
        Task<LeadModel> UpdateAsync(LeadUpdateModel updateModel, CancellationToken cancellationToken);
    }
}