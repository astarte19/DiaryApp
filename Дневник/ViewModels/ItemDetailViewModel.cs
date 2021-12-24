using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Дневник.Models;
using Xamarin.Forms;

namespace Дневник.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
      //  public string date;
        public string Id { get; set; }
        
        public ItemDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
        }
        public Command DeleteCommand { get; }
        private async void OnDelete ()
        {
            //Допилить метод удаления
            await Shell.Current.GoToAsync("..");
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

    /*    public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
    */
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
               // Date = item.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ошибка в подгрузке записи");
            }
        }


        
    }
}
