namespace VehicleStore.Server.Services.ImageHandler
{
    public class ImageHandler : IImageHandler
    {
        private readonly string[] validImageTypes = new string[] { "image/png", "image/jpg", "image/jpeg" };

        public ImageHandler()
        {
        }

        public bool CheckImageType(string type)
        {
            return validImageTypes.FirstOrDefault(x => x == type) != null ? true : false;
        }

        public byte[] ImageToByteArray(IFormFile image)
        {
            var ms = new MemoryStream();
            image.CopyTo(ms);
            return ms.ToArray();
        }
    }
}