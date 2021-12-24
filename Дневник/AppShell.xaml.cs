using System;
using System.Collections.Generic;
using Дневник.ViewModels;
using Дневник.Views;
using Xamarin.Forms;


namespace Дневник
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Header_image.Source = ImageSource.FromResource("Дневник.images.diary_header.png");

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
