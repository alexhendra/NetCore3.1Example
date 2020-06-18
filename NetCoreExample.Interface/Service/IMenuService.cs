using NetCoreExample.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreExample.Interfaces.Service
{
    public interface IMenuService
    {
        Task<ICollection<MenuVM>> GetAll();
    }
}
