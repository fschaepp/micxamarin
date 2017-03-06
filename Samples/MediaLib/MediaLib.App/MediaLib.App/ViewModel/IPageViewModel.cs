using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLib.App.Navigation;

namespace MediaLib.App.ViewModel
{
    internal interface IPageViewModel
    {
        void OnNavigatedTo(PageNavigationDirection direction, params object[] parameters);
        void OnNavigatedFrom();
    }
}
