using MockAPI.DTOs.Response;
using MockAPI.Extensions;
using MockAPI.Models.Requests;
using MockAPI.Models.Responses;
using MockAPI.SharedServices;
using MockAPI.SharedServices.ExceptionHandling;
using Newtonsoft.Json;
using Serilog;

namespace MockAPI.CoreServices
{
    public interface IAssetsService
    {
        Task<AssetsDto> GetAssets(FilterObjectsRequest request);

        Task<AssetsDto> GetSpecificAssets(FilterObjectsRequest request);

        Task<AddedAssetResponse> AddAsset(ManageAssetRequest request);

        Task<DeleteAssetResponse> DeleteAsset(DeleteAssetRequest request);
    }

    public class AssetsService : IAssetsService
    {
        private readonly IHttpService _httpService;

        private readonly IConfiguration _configuration;

        private static string? RestfulAPIUrl;

        public AssetsService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;

            RestfulAPIUrl = _configuration["RestfulAPI:Url"];
        }

        #region GET

        public async Task<AssetsDto> GetAssets(FilterObjectsRequest request)
        {
            try
            {
                //retrieve data from restful api
                var result = await _httpService.GetDataAsync(RestfulAPIUrl);
                var assetData = JsonConvert.DeserializeObject<List<Asset>>(result);

                //first serach based on name
                if (!string.IsNullOrEmpty(request.Search))
                    assetData = assetData
                                        .Where(a => a.Name.Contains(request.Search, StringComparison.OrdinalIgnoreCase))
                                        .ToList();


                //followed by pagination, for accurate results
                var pagedAssets = assetData
                                            .Skip((request.PageNumber - 1) * request.PageSize)
                                            .Take(request.PageSize)
                                            .ToList();

                //convert to dto
                var assetDto = pagedAssets.ToAssetDto();

                return new AssetsDto
                {
                    Items = assetDto
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{nameof(GetAssets)} has failed.");
                throw;
            }
        }

        public async Task<AssetsDto> GetSpecificAssets(FilterObjectsRequest request)
        {
            try
            {
                var fullUrl = $"{RestfulAPIUrl}?" +
                                  string.Join("&", Enumerable.Range(request.PageNumber, request.PageSize)
                                                             .Select(id => $"id={id}"));

                var result = await _httpService.GetDataAsync(fullUrl);
                List<Asset> assetData = JsonConvert.DeserializeObject<List<Asset>>(result);

                //first serach based on name
                if (!string.IsNullOrEmpty(request.Search))
                    assetData = assetData
                                        .Where(a => a.Name.Contains(request.Search, StringComparison.OrdinalIgnoreCase))
                                        .ToList();

                //convert to dto
                var assetDto = assetData.ToAssetDto();

                return new AssetsDto
                {
                    Items = assetDto
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{nameof(GetSpecificAssets)} has failed.");
                throw;
            }
        }

        #endregion

        #region ADD

        public async Task<AddedAssetResponse> AddAsset(ManageAssetRequest request)
        {
            try
            {
                var result = await _httpService.PostDataAsync(RestfulAPIUrl, request.ToManageAssetDto());
                var response = JsonConvert.DeserializeObject<AddedAssetDto>(result);
                return response.ToAddedAssetResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{nameof(AddAsset)} has failed.");
                throw;
            }
        }

        #endregion

        #region DELETE

        public async Task<DeleteAssetResponse?> DeleteAsset(DeleteAssetRequest request)
        {
            try
            {
                var result = await _httpService.DeleteDataAsync(RestfulAPIUrl, request.Id);
                var response = JsonConvert.DeserializeObject<DeleteAssetDto>(result);
                return response.ToDeleteAssetResponse();
            }
            catch (CustomHttpResponseException custEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{nameof(DeleteAsset)} has failed.");
                throw;
            }
        }
        #endregion
    }
}
