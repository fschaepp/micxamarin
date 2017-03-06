using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaLib.App.View;
using MediaLib.App.ViewModel;
using Ninject;
using Xamarin.Forms;

namespace MediaLib.App.Navigation
{
    internal class NavigationService : INavigationService
    {
        private readonly Page _navigationPage;
        private readonly IKernel _container;
        private Dictionary<Type, Type> pageResolver = new Dictionary<Type, Type>();

        public NavigationService(Page navigationPage, IKernel container)
        {
            _container = container;
            _navigationPage = navigationPage;
            _navigationPage.ChildRemoved += (o, e) =>
            {
                var vm = e.Element.BindingContext as IPageViewModel;
                vm?.OnNavigatedFrom();
                var activePage = _navigationPage.Navigation.NavigationStack.Last();
                vm = activePage.BindingContext as IPageViewModel;
                vm?.OnNavigatedTo(PageNavigationDirection.Back);
            };
            pageResolver.Add(typeof(AllMediaViewModel), typeof(AllMediaPage));
            pageResolver.Add(typeof(EditMediaViewModel), typeof(EditMediaPage));
        }
        
        public void Navigate<T>(params object[] parameters) where T : IPageViewModel
        {
            var pageType = pageResolver[typeof(T)];
            var page = Activator.CreateInstance(pageType) as Page;
            var pageViewModel = _container.Get<T>();
            _navigationPage.Navigation.PushAsync(page);
            pageViewModel.OnNavigatedTo(PageNavigationDirection.Forward, parameters);
            page.BindingContext = pageViewModel;
        }

        public void Back()
        {
            _navigationPage.Navigation.PopAsync();
        }
    }

    internal enum PageNavigationDirection { Forward, Back }
}