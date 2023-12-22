namespace VehicleStore.Server.Services.AuthTokenHandler
{
    public interface IAuthTokenHandler
    {
        public string Generate(Guid id, string role);
    }
}