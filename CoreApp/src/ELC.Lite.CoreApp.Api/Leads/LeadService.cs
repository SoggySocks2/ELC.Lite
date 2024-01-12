using AutoMapper;
using ELC.Lite.Domain.Leads;
using ELC.Lite.Domain.Leads.Contracts;
using ELC.Lite.Models.Leads;
using ELC.Lite.SharedKernel.Exceptions.Helpers;

namespace ELC.Lite.CoreApp.Api.Leads
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public LeadService(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<LeadModel> AddAsync(LeadCreateModel createModel, CancellationToken cancellationToken)
        {
            Check.For.Null(createModel);
            var newLead = _mapper.Map<Lead>(createModel);

            await _leadRepository.AddAsync(newLead, cancellationToken);

            return _mapper.Map<LeadModel>(newLead);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(id, cancellationToken);
            if (lead is null)
                throw new ArgumentException($"Lead with id {id} not found");

            await _leadRepository.DeleteAsync(lead, cancellationToken);
        }

        public async Task<LeadModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(id, cancellationToken);
            if (lead is null)
                throw new ArgumentException($"Lead with id {id} not found");

            var leadModel = _mapper.Map<LeadModel>(lead);
            return leadModel;
        }

        public async Task<List<LeadModel>> GetListAsync(CancellationToken cancellationToken)
        {
            var leads = await _leadRepository.GetListAsync(cancellationToken);
            var leadModels = _mapper.Map<List<LeadModel>>(leads);

            return leadModels;
        }

        public async Task<LeadModel> UpdateAsync(LeadUpdateModel updateModel, CancellationToken cancellationToken)
        {
            Check.For.Null(updateModel);

            var existingLead = await _leadRepository.GetByIdAsync(updateModel.Id, cancellationToken);
            if (existingLead is null)
                throw new ArgumentException($"Lead with id {updateModel.Id} not found");

            var updatedLead = _mapper.Map(updateModel, existingLead);

            await _leadRepository.UpdateAsync(updatedLead, cancellationToken);

            return _mapper.Map<LeadModel>(updatedLead);
        }
    }
}
