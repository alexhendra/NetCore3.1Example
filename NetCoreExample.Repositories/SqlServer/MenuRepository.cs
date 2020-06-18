using Dapper;
using NetCoreExample.Interfaces.Contexts;
using NetCoreExample.Interfaces.Repository;
using NetCoreExample.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExample.Repositories.SqlServer
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IDbContext DbContext;
        private string _sql = string.Empty;

        public MenuRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<ICollection<MenuVM>> GetAllData()
        {
            ICollection<MenuVM> result;
            try
            {
                _sql = @";WITH cte_numbers--(n, weekday) 
                          AS (
                              SELECT Id, ParentId, Descriptions, IsActive        
	                          FROM [TestAlex].[dbo].[MMenu] WHERE ParentId is null
                              UNION ALL
                              SELECT a.Id, a.ParentId, a.Descriptions, a.IsActive
	                          FROM [TestAlex].[dbo].[MMenu] a JOIN cte_numbers c ON a.parentId = c.id
                          )

                          SELECT * FROM cte_numbers;";
                result = (ICollection<MenuVM>)await DbContext.DB.QueryAsync<MenuVM>(_sql, commandType: CommandType.Text);
                //result = tempResult.Where(item => item.ParentId == null).ToList();
                //foreach (var itemParent in result)
                //{
                //    itemParent.Childs = tempResult.Where(w => w.ParentId == itemParent.Id).ToList();
                //    itemParent.Childs.ToList().ForEach(tmpItem =>
                //    {
                //        tmpItem.Childs = 
                //    });
                //}                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //private ICollection<MenuVM> GenerateHirarchyMenuItem(ICollection<MenuVM> data)
        //{
        //    ICollection<MenuVM> result = new List<MenuVM>();
        //    foreach (var item in data)
        //    {
        //        if(item.ParentId == null)
        //        {
        //            result.Add(item);
        //        }
        //        else
        //        {

        //        }
        //    }
        //    return result;
        //}
    }
}
