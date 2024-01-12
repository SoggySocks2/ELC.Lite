using ELC.Lite.Domain.Leads;
using ELC.Lite.Domain.Leads.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.CoreApp.Infrastucture.Leads
{
    public class LeadRepository : ILeadRepository
    {
        private readonly CoreDbContext _dbContext;

        public LeadRepository(CoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Lead> AddAsync(Lead lead, CancellationToken cancellationToken)
        {
            _dbContext.Leads.Add(lead);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return lead;
        }

        public async Task DeleteAsync(Lead lead, CancellationToken cancellationToken)
        {
            _dbContext.Leads.Remove(lead);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Lead?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Leads
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Lead>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Leads
                .ToListAsync(cancellationToken);
        }

        public async Task<Lead> UpdateAsync(Lead lead, CancellationToken cancellationToken)
        {
            _dbContext.Leads.Update(lead);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return lead;
        }
    }
}
