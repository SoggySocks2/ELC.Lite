namespace ELC.Lite.Domain.Leads.Contracts
{
    public interface ILeadRepository
    {
        Task<Lead> AddAsync(Lead lead, CancellationToken cancellationToken);
        Task DeleteAsync(Lead lead, CancellationToken cancellationToken);
        Task<Lead?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Lead>> GetListAsync(CancellationToken cancellationToken);
        Task<Lead> UpdateAsync(Lead lead, CancellationToken cancellationToken);
    }
}
