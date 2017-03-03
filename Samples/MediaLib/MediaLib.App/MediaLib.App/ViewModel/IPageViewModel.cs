using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib.App.ViewModel
{
    internal interface IPageViewModel
    {
        void OnNavigatedTo(params object[] parameters);
        void OnNavigatedFrom();
    }
}
