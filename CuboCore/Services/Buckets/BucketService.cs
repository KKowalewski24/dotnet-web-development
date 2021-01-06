using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CuboCore.Domain;
using CuboCore.DTO;
using CuboCore.Exceptions.Buckets;
using CuboCore.Repositories;
using CuboCore.Repositories.Buckets;

namespace CuboCore.Services.Buckets {

    public class BucketService : IBucketService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IBucketRepository _bucketRepository;
        private readonly IMapper _mapper;

        /*------------------------ METHODS REGION ------------------------*/
        public BucketService(IBucketRepository bucketRepository, IMapper mapper) {
            _bucketRepository = bucketRepository;
            _mapper = mapper;
        }

        public async Task<BucketDTO> GetAsync(string name) {
            Bucket bucket = await _bucketRepository.GetOrFailAsync(name);
            return _mapper.Map<BucketDTO>(bucket);
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
