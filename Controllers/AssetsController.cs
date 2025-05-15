using Microsoft.AspNetCore.Mvc;
using MockAPI.CoreServices;
using MockAPI.Models.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace MockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsService _assetsService;

        public AssetsController(IAssetsService assetsService)
        {
            _assetsService = assetsService;
        }

        [SwaggerOperation(Summary = "Retrieves all assets first, followed by pagination and search.")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        [Route(nameof(GetAssets))]
        public async Task<IActionResult> GetAssets(FilterObjectsRequest request)
        {
            //for ASP.NET Core (3.0+), this is automatically handled
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            return Ok(await _assetsService.GetAssets(request));
        }

        [SwaggerOperation(Summary = "Forms the url to get only specific assets based on the pagination details, followed by only search at the API.")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        [Route(nameof(GetSpecificAssets))]
        public async Task<IActionResult> GetSpecificAssets(FilterObjectsRequest request)
        {
            return Ok(await _assetsService.GetSpecificAssets(request));
        }

        [SwaggerOperation(Summary = "Add an asset")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        [Route(nameof(AddAsset))]
        public async Task<IActionResult> AddAsset(ManageAssetRequest request)
        {
            return Ok(await _assetsService.AddAsset(request));
        }

        [SwaggerOperation(Summary = "Delete an asset. Directly deleting an asset from the existing list, throws 405 Method not allowed error.\r\n Rather add a new asset and same can be used to delete.")]
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost]
        [Route(nameof(DeleteAsset))]
        public async Task<IActionResult> DeleteAsset(DeleteAssetRequest request)
        {
            var resposne = await _assetsService.DeleteAsset(request);
            if (resposne == null)
                return NotFound("Asset Not found");

            return Ok(resposne);
        }
    }
}
