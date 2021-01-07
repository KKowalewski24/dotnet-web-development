using System.Threading.Tasks;
using AutoMapper;
using CuboCore.Domain;
using CuboCore.DTO;
using CuboCore.Mappers;
using CuboCore.Repositories.Buckets;
using CuboCore.Services.Buckets;
using Moq;
using Xunit;

namespace CuboCoreTests.Services {

    public class BucketServiceTest {

        /*------------------------ FIELDS REGION ------------------------*/
        private const string BucketName = "First";

        /*------------------------ METHODS REGION ------------------------*/
        [Fact]
        public async Task AddAsync_CreateNewBucket() {
            IBucketService bucketService = new BucketService(
                new InMemoryBucketRepository(), AutoMapperConfig.InitializeMapper()
            );

            await bucketService.AddAsync(BucketName);
            BucketDTO bucketDto = await bucketService.GetAsync(BucketName);

            Assert.Equal(BucketName, bucketDto.Name);
        }

        [Fact]
        public async Task AddAsync_InvokeRepositoryMethod() {
            Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            IBucketService bucketService = new BucketService(
                bucketRepository.Object, mapper.Object
            );

            await bucketService.AddAsync(BucketName);

            bucketRepository.Verify(
                (repo) => repo.AddAsync(It.IsAny<Bucket>()),
                Times.Once
            );
        }

        [Fact]
        public async Task GetAsync_ReturnBucket() {
            Bucket bucket = new Bucket(BucketName);
            BucketDTO bucketDto = new BucketDTO();
            Mock<IBucketRepository> bucketRepository = new Mock<IBucketRepository>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            bucketRepository
                .Setup((it) => it.GetAsync(BucketName))
                .ReturnsAsync(bucket);

            mapper
                .Setup((it) => it.Map<BucketDTO>(bucket))
                .Returns(bucketDto);

            IBucketService bucketService = new BucketService(
                bucketRepository.Object, mapper.Object
            );

            await bucketService.GetAsync(BucketName);

            bucketRepository.Verify(
                (it) => it.GetAsync(BucketName),
                Times.Once
            );
            mapper.Verify(
                (it) => it.Map<BucketDTO>(bucket),
                Times.Once
            );
        }

    }

}
