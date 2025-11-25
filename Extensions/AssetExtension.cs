using MockAPI.DTOs.Requests;
using MockAPI.DTOs.Response;
using MockAPI.Models.Requests;
using MockAPI.Models.Responses;
using Newtonsoft.Json;

namespace MockAPI.Extensions
{
    public static class AssetExtension
    {
        private static TTarget Map<TSource, TTarget>(TSource source)
        {
            return JsonConvert.DeserializeObject<TTarget>(JsonConvert.SerializeObject(source));
        }

        public static List<AssetDto> ToAssetDto(this List<Asset> assets)
            => Map<List<Asset>, List<AssetDto>>(assets);

        public static ManageAssetDto ToManageAssetDto(this ManageAssetRequest request)
            => Map<ManageAssetRequest, ManageAssetDto>(request);

        public static AddedAssetResponse ToAddedAssetResponse(this AddedAssetDto dto)
            => Map<AddedAssetDto, AddedAssetResponse>(dto);

        public static DeleteAssetResponse ToDeleteAssetResponse(this DeleteAssetDto dto)
            => Map<DeleteAssetDto, DeleteAssetResponse>(dto);
    }
}
