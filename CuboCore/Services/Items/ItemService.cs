using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuboCore.Domain;
using CuboCore.DTO;
using CuboCore.Repositories;
using CuboCore.Repositories.Buckets;
using Newtonsoft.Json;

namespace CuboCore.Services.Items {

    public class ItemService : IItemService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IBucketRepository _bucketRepository;

        /*------------------------ METHODS REGION ------------------------*/
        public ItemService(IBucketRepository bucketRepository) {
            _bucketRepository = bucketRepository;
        }

        public async Task<ItemDTO> GetAsync(string bucketName, string key) {
            Bucket bucket = await _bucketRepository.GetOrFailAsync(bucketName);
            Item item = bucket.GetItem(key);
            //TODO
            return new ItemDTO();
        }

        public async Task<IEnumerable<string>> GetKeysAsync(string bucketName) {
            Bucket bucket = await _bucketRepository.GetOrFailAsync(bucketName);
            return bucket.Items.Select((it) => it.Key);
        }

        public async Task AddAsync(string bucketName, string key, object value) {
            Bucket bucket = await _bucketRepository.GetOrFailAsync(bucketName);
            bucket.AddItem(key, JsonConvert.SerializeObject(value));
            await _bucketRepository.UpdateAsync(bucket);
        }

        public async Task RemoveAsync(string bucketName, string key) {
            Bucket bucket = await _bucketRepository.GetOrFailAsync(bucketName);
            bucket.RemoveItem(key);
            await _bucketRepository.UpdateAsync(bucket);
        }

    }

}
