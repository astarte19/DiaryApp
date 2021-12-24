using System.ComponentModel;
using Xamarin.Forms;
using Дневник.ViewModels;

namespace Дневник.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
