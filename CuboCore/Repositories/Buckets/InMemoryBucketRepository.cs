using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuboCore.Domain;

namespace CuboCore.Repositories.Buckets {

    public class InMemoryBucketRepository : IBucketRepository {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly ISet<Bucket> _buckets = new HashSet<Bucket>();

        /*------------------------ METHODS REGION ------------------------*/
        public async Task<Bucket> GetAsync(string name) {
            return await Task.FromResult(
                _buckets.SingleOrDefault((it) => it.Name == name)
            );
        }

        public async Task<IEnumerable<string>> GetNamesAsync() {
            return await Task.FromResult(_buckets.Select((it) => it.Name));
        }

        public async Task AddAsync(Bucket bucket) {
            _buckets.Add(bucket);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Bucket bucket) {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(string name) {
            _buckets.Remove(await GetAsync(name));
        }

    }

}
