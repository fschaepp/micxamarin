using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLib.App.ViewModel;
using Xamarin.Forms;

namespace MediaLib.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new TableViewModel();
        }
    }
}
