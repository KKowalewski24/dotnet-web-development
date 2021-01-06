using System.Collections.Generic;
using System.Threading.Tasks;
using CuboCore.DTO;

namespace CuboCore.Services.Items {

    public interface IItemService {

        Task<ItemDTO> GetAsync(string bucketName, string key);

        Task<IEnumerable<string>> GetKeysAsync(string bucketName);

        Task AddAsync(string bucketName, string key, object value);

        Task RemoveAsync(string bucketName, string key);

    }

}
