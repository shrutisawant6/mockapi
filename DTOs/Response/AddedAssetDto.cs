namespace MockAPI.DTOs.Response
{
    public class AddedAssetDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public AssetDataDto Data { get; set; }

        public string CreatedAt { get; set; }
    }
}
