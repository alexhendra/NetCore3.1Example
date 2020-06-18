using NetCoreExample.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreExample.Interfaces.Repository
{
    public interface IMenuRepository
    {
        Task<ICollection<MenuVM>> GetAllData();
    }
}
