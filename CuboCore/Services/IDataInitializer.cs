using System.Threading.Tasks;

namespace CuboCore.Services {

    public interface IDataInitializer {

        Task SeedAsync(int numberOfBuckets);

    }

}
