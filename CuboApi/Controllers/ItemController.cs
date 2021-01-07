using System;
using System.Threading.Tasks;
using CuboCore.DTO;
using CuboCore.Exceptions.Buckets;
using CuboCore.Exceptions.Items;
using CuboCore.Services.Items;
using Microsoft.AspNetCore.Mvc;
using static CuboApi.Constants.Constants;

namespace CuboApi.Controllers {

    [ApiController]
    [Route(BASE_PATH_ITEM_CONTROLLER)]
    public class ItemController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IItemService _itemService;

        /*------------------------ METHODS REGION ------------------------*/
        public ItemController(IItemService itemService) {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string bucketName) {
            return Json(await _itemService.GetKeysAsync(bucketName));
        }

        [HttpGet(PARAM_KEY)]
        public async Task<IActionResult> Get(string bucketName, string key) {
            try {
                return Json(await _itemService.GetAsync(bucketName, key));
            } catch (Exception e)
                when (e is ItemNotFoundException || e is BucketNotFoundException) {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(string bucketName,
                                              [FromBody] ItemDTO itemDto) {
            await _itemService.AddAsync(bucketName, itemDto.Key, itemDto.Value);

            return Created(
                BUCKET + SLASH + PARAM_BUCKET_NAME + SLASH + ITEM + SLASH + itemDto.Key,
                null
            );
        }

        [HttpDelete(PARAM_KEY)]
        public async Task<IActionResult> Delete(string bucketName, string key) {
            await _itemService.RemoveAsync(bucketName, key);
            return NoContent();
        }

    }

}
