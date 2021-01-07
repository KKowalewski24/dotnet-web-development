using System.Linq;
using AutoMapper;
using CuboCore.Domain;
using CuboCore.DTO;

namespace CuboCore.Mappers {

    public static class AutoMapperConfig {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static IMapper InitializeMapper() {
            MapperConfiguration configuration = new MapperConfiguration((config) => {
                config.CreateMap<Bucket, BucketDTO>().ForMember(
                    (member) => member.Items,
                    (member) => {
                        member.MapFrom((bucket) => bucket.Items.Select((item) => item.Key)
                                           .OrderBy((key) => key));
                    });

                config.CreateMap<Item, ItemDTO>();
            });

            return configuration.CreateMapper();
        }

    }

}
