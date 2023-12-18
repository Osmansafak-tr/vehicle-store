namespace VehicleStore.Server.Common
{
    public class ObjectMerger
    {
        public static void Merge<T>(T source, T destination)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(source);

                if (value != null)
                {
                    property.SetValue(destination, value);
                }
            }
        }
    }
}