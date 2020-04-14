using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<DataCollection<ApplicationUserDto>> GetAll(int page, int take);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<ApplicationUserDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ApplicationUserDto>>(
                await _context.Users.OrderByDescending(x => x.FirstName)
                              .Include(x => x.UserRoles)
                                .ThenInclude(x => x.Role)
                              .AsQueryable()
                              .PagedAsync(page, take)
            );
        }
    }
}
