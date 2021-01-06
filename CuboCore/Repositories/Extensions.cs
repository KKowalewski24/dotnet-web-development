using System.Threading.Tasks;
using CuboCore.Domain;
using CuboCore.Exceptions.Buckets;
using CuboCore.Repositories.Buckets;

namespace CuboCore.Repositories {

    public static class Extensions {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static async Task<Bucket> GetOrFailAsync(this IBucketRepository repository,
                                                        string name) {
            Bucket bucket = await repository.GetAsync(name);
            if (bucket == null) {
                throw new BucketNotFoundException();
            }

            return bucket;
        }

    }

}
