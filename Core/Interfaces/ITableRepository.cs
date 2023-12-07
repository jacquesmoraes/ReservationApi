using Core.Entities;

namespace Core.Interfaces
{
    public interface ITableRepository
    {
     
        Task<IEnumerable<Table>> GetTablesAsync();

        Task<Table> GetTableByIdAsync(int id);



       

    }
}
