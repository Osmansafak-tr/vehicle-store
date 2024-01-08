namespace VehicleStore.Server.Services.ImageHandler
{
    public interface IImageHandler
    {
        /// <summary>
        /// Resim tipinin doğru olup olmadığını ölçer.
        /// </summary>
        /// <param name="type"></param>
        bool CheckImageType(string type);

        /// <summary>
        /// Resmi byte arraye dönüştürür
        /// </summary>
        /// <param name="image"></param>
        byte[] ImageToByteArray(IFormFile image);
    }
}