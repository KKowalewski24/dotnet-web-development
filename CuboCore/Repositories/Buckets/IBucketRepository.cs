using System.Collections.Generic;
using System.Threading.Tasks;
using CuboCore.Domain;

namespace CuboCore.Repositories.Buckets {

    public interface IBucketRepository {

        Task<Bucket> GetAsync(string name);

        Task<IEnumerable<string>> GetNamesAsync();

        Task AddAsync(Bucket bucket);

        Task UpdateAsync(Bucket bucket);

        Task RemoveAsync(string name);

    }

}
