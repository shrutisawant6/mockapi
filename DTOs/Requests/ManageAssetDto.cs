using MockAPI.DTOs.Response;

namespace MockAPI.DTOs.Requests
{
    public class ManageAssetDto
    {
        public string Name { get; set; }

        public AssetDataDto Data { get; set; }
    }
}
