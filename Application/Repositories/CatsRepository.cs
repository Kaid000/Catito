using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Application.Repositories
{
    public class CatsRepository : BaseRepository<Cat>, ICatsRepository
    {
        public CatsRepository(ApplicationDBContext context)
            : base(context)
        {
        }
    }
}
