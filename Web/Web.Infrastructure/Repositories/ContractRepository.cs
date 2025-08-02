using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;
using Web.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.Infrastructure.Data;

namespace Web.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly BBDDContext _context;

        public ContractRepository(BBDDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContractEntity>> GetAllAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<ContractEntity?> GetByIdAsync(ulong id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<ContractEntity> AddAsync(ContractEntity product)
        {
            product.Id = 0;
            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = null;
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(ContractEntity product)
        {
            product.UpdatedDate = DateTime.Now;
            _context.Contracts.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ulong id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Contracts.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
