using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SecuredFilesProject.Infrastructure.Interfaces
{
    public interface IRepository
    {
        Task<bool> ExistsAsync();

        Task<bool> ExistsAsync(int id);

        Task<bool> ExistsAsync(Expression<Func<IModel, bool>> whereClause);
        Task<IModel> GetAsync<T>(int id);
        Task<IModel> GetFirstAsync(Expression<Func<IModel, bool>> whereClause);
        Task<List<IModel>> GetAllAsync();
        Task<List<IModel>> GetAllAsync(Expression<Func<IModel, bool>> whereClause);
        Task<List<IModel>> GetAllSortedAsync(Expression<Func<IModel, int>> orderBy);
        Task<List<IModel>> GetAllSortedAsync(Expression<Func<IModel, bool>> whereClause, Expression<Func<IModel, int>> orderBy);
        Task<bool> Add(IModel obj);
        Task<IModel> CreateUserWithPasswordAsync(IModel obj);
        Task<IModel> AuthorizeAsync(IModel obj);
    }
}
