using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuboCore.Domain;
using CuboCore.DTO;
using CuboCore.Exceptions.Buckets;
using CuboCore.Repositories;
using CuboCore.Repositories.Buckets;

namespace CuboCore.Services.Buckets {

    public class BucketService : IBucketService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IBucketRepository _bucketRepository;

        /*------------------------ METHODS REGION ------------------------*/
        public BucketService(IBucketRepository bucketRepository) {
            _bucketRepository = bucketRepository;
        }

        public async Task<BucketDTO> GetAsync(string name) {
            Bucket bucket = await _bucketRepository.GetOrFailAsync(name);
            return new BucketDTO(
                bucket.Name, bucket.CreatedAt,
                bucket.Items.Select((it) => it.Key).ToList()
            );
        }

        public async Task<IEnumerable<string>> GetNamesAsync() {
            return await _bucketRepository.GetNamesAsync();
        }

        public async Task AddAsync(string name) {
            if (await _bucketRepository.GetAsync(name) != null) {
                throw new BucketAlreadyExistsException();
            }

            await _bucketRepository.AddAsync(new Bucket(name));
        }

        public async Task RemoveAsync(string name) {
            await _bucketRepository.RemoveAsync(name);
        }

    }

}
