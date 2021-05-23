using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface ICardRepository
    {
        Task InsertCardAsync(Card card);
        Task UpdateCardAsync(Card card);
    }
}
