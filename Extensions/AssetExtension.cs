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
            return JsonConvert.DeserializeObject<TTarget>(
                JsonConvert.SerializeObject(source)
            );
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


    //public static class AssetExtension
    //{
    //    public static List<AssetDto> ToAssetDto(this List<Asset> assets)
    //    {
    //        string jsonString = JsonConvert.SerializeObject(assets);
    //        return JsonConvert.DeserializeObject<List<AssetDto>>(jsonString);
    //    }

    //    public static ManageAssetDto ToManageAssetDto(this ManageAssetRequest request)
    //    {
    //        string jsonString = JsonConvert.SerializeObject(request);
    //       return JsonConvert.DeserializeObject<ManageAssetDto>(jsonString);

    //    }
    //    public static AddedAssetResponse ToAddedAssetResponse(this AddedAssetDto dto)
    //    {
    //        string jsonString = JsonConvert.SerializeObject(dto);
    //        return JsonConvert.DeserializeObject<AddedAssetResponse>(jsonString);
    //    }

    //    public static DeleteAssetResponse ToDeleteAssetResponse(this DeleteAssetDto dto)
    //    {
    //        string jsonString = JsonConvert.SerializeObject(dto);
    //        return JsonConvert.DeserializeObject<DeleteAssetResponse>(jsonString);
    //    }
    //}
}
