using System.Collections.Generic;
using System.Threading.Tasks;
using CuboCore.DTO;

namespace CuboCore.Services.Buckets {

    public interface IBucketService {

        Task<BucketDTO> GetAsync(string name);

        Task<IEnumerable<string>> GetNamesAsync();

        Task AddAsync(string name);

        Task RemoveAsync(string name);

    }

}
