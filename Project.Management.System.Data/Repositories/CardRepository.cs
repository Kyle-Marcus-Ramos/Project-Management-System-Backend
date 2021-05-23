using Microsoft.EntityFrameworkCore;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private ProjectManagementDBContext _projectManagementDBContext
        {
            get { return _context as ProjectManagementDBContext; }
        }

        public CardRepository(DbContext context)
            : base(context)
        { }

        public async Task InsertCardAsync(Card card)
        {
            await _projectManagementDBContext.Card.AddAsync(card);
        }

        public async Task UpdateCardAsync(Card card)
        {
             _projectManagementDBContext.Update(card);
            await _context.SaveChangesAsync();
        }
    }
}
