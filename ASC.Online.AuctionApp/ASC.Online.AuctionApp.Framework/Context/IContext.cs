using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASC.Online.AuctionApp.Framework.Context
{
    /// <summary>
    /// Context related contracts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContext<T> where T:class
    {
        DbSet<T> AuctionSetupDbSet { get; set; }
        Task<IEnumerable<T>> GetAllAsync();
        Task Add(T entity);
        Task<T> GetAsync(long item);
        void PatchUpdate();
        void PutUpdate(T entity);
        void Delete(T entity);
        Task Update(T entity);
    }
}
