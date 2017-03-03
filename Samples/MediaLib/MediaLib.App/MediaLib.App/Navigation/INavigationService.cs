using System;
using System.Collections.Generic;
using MediaLib.App.View;
using MediaLib.App.ViewModel;
using Xamarin.Forms;

namespace MediaLib.App.Navigation
{
    internal interface INavigationService
    {
        void Navigate<T>(params object[] parameters) where T : IPageViewModel;

        void Back();
    }

    internal class NavigationService : INavigationService
    {
        private readonly Page _navigationPage;
        private Dictionary<Type, Type> pageResolver = new Dictionary<Type, Type>();

        public NavigationService(Page navigationPage)
        {
            _navigationPage = navigationPage;
            pageResolver.Add(typeof(EditMediaViewModel), typeof(EditMediaPage));
        }

        public void Navigate<T>(params object[] parameters) where T : IPageViewModel
        {
            var pageType = pageResolver[typeof(T)];
            var page = Activator.CreateInstance(pageType) as Page;
            var pageViewModel = Activator.CreateInstance<T>();
            _navigationPage.Navigation.PushAsync(page);
            pageViewModel.OnNavigatedTo(parameters);
            page.BindingContext = pageViewModel;
        }

        public void Back()
        {
            var page = _navigationPage.Navigation.PopAsync().Result;
            var pageViewModel = page?.BindingContext as IPageViewModel;
            pageViewModel?.OnNavigatedFrom();
        }
    }
}
