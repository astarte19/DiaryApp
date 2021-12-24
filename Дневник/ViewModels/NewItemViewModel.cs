using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Дневник.Models;
using Xamarin.Forms;

namespace Дневник.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
     //   private string date;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
                 //  &&!String.IsNullOrWhiteSpace(date);
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
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
           
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
              //  Date = Date
            };

            await DataStore.AddItemAsync(newItem);

            
            await Shell.Current.GoToAsync("..");
        }
    }
}
