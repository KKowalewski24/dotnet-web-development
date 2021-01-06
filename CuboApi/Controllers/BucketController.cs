using System.Threading.Tasks;
using CuboCore.Exceptions.Buckets;
using CuboCore.Services.Buckets;
using Microsoft.AspNetCore.Mvc;
using static CuboApi.Constants.Constants;

namespace CuboApi.Controllers {

    [ApiController]
    [Route(BASE_PATH_API_CONTROLLER)]
    public class BucketController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IBucketService _bucketService;

        /*------------------------ METHODS REGION ------------------------*/
        public BucketController(IBucketService bucketService) {
            _bucketService = bucketService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return Json(await _bucketService.GetNamesAsync());
        }

        [HttpGet(PARAM_NAME)]
        public async Task<IActionResult> Get(string name) {
            try {
                return Json(await _bucketService.GetAsync(name));
            } catch (BucketNotFoundException) {
                return NotFound();
            }
        }

        [HttpPost(PARAM_NAME)]
        public async Task<IActionResult> Post(string name) {
            await _bucketService.AddAsync(name);

            return Created($"buckets/{name}", null);
        }

        [HttpDelete(PARAM_NAME)]
        public async Task<IActionResult> Delete(string name) {
            await _bucketService.RemoveAsync(name);

            return NoContent();
        }

    }

}
