using System.Linq;
using MediaLib.App.Common.Model;

namespace MediaLib.App.ViewModel
{
    internal class EditMediaViewModel : PageViewModel
    {
        public Media Media { get; set; }

        public override void OnNavigatedTo(params object[] parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters?.Any() ?? false)
            {
                Media = parameters.OfType<Media>().FirstOrDefault();
                OnPropertyChanged(nameof(Media));
            }
        }

        public override string Title => Media.Title;
    }
}
