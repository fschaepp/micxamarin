using MediaLib.App.Common.Model;

namespace MediaLib.App.Common.Extensions
{
    public static class MediaExtensions
    {
        public static Media Clone(this Media original)
        {
            var clone = new Media
            {
                Id = original.Id,
                Title = original.Title,
            };
            return clone;
        }
    }
}
