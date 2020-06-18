using NetCoreExample.Interfaces.Repository;
using NetCoreExample.Interfaces.Service;
using NetCoreExample.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreExample.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository repository;

        public MenuService(IMenuRepository menuRepository)
        {
            repository = menuRepository;
        }

        public async Task<ICollection<MenuVM>> GetAll()
        {
            return await repository.GetAllData();
        }
    }
}
