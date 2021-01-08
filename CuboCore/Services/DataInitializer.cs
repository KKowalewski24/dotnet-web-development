using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuboCore.Domain;
using CuboCore.Repositories.Buckets;

namespace CuboCore.Services {

    public class DataInitializer : IDataInitializer {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IBucketRepository _bucketRepository;

        /*------------------------ METHODS REGION ------------------------*/
        public DataInitializer(IBucketRepository bucketRepository) {
            _bucketRepository = bucketRepository;
        }

        public async Task SeedAsync(int numberOfBuckets) {
            IEnumerable<string> names = await _bucketRepository.GetNamesAsync();
            if (names.Any()) {
                return;
            }

            for (int i = 0; i < numberOfBuckets; i++) {
                await _bucketRepository.AddAsync(CreateBucket(i));
            }
        }

        private Bucket CreateBucket(int numberOfItems) {
            Bucket bucket = new Bucket($"Bucket-{numberOfItems}");
            for (int i = 0; i < numberOfItems; i++) {
                bucket.AddItem($"Item-{Guid.NewGuid()}", $"Value {Guid.NewGuid()}");
            }

            return bucket;
        }

    }

}
