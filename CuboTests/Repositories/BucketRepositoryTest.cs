using System.Threading.Tasks;
using CuboCore.Domain;
using CuboCore.Repositories.Buckets;
using Xunit;

namespace CuboTests.Repositories {

    public class BucketRepositoryTest {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        [Fact]
        public async Task CreateNewBucket() {
            IBucketRepository bucketRepository = new InMemoryBucketRepository();
            const string bucketName = "First";
            Bucket bucket = new Bucket(bucketName);

            await bucketRepository.AddAsync(bucket);
            Bucket fetchedBucket = await bucketRepository.GetAsync(bucketName);

            Assert.Same(bucket, fetchedBucket);
        }

    }

}
