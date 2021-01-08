using System.Threading.Tasks;
using CuboCore.Domain;
using CuboCore.Repositories.Buckets;
using Xunit;

namespace CuboCoreTests.Repositories {

    public class BucketRepositoryTest {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        [Fact]
        public async Task AddAsync_CreateNewBucket() {
            const string bucketName = "First";
            IBucketRepository bucketRepository = new InMemoryBucketRepository();
            Bucket bucket = new Bucket(bucketName);

            await bucketRepository.AddAsync(bucket);
            Bucket fetchedBucket = await bucketRepository.GetAsync(bucketName);

            Assert.Same(bucket, fetchedBucket);
        }

    }

}
