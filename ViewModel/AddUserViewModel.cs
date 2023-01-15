using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Clock_In_System_with_MAUI_and_SQLite.Model;
using Clock_In_System_with_MAUI_and_SQLite.Service;

namespace Clock_In_System_with_MAUI_and_SQLite.ViewModel
{
    public partial class AddUserViewModel : BaseViewModel
    {
        readonly UserService userService;

        public AddUserViewModel(UserService userService)
        {
            AddUserCommand = new RelayCommand(async () => await AddUser());

            this.userService = userService;
            NewUser = new User();
        }

        [ObservableProperty]
        User newUser;

        public RelayCommand AddUserCommand { get; private set; }

        public async Task AddUser()
        {
            if (IsBusy)
                return;

            int result = 0;

            try
            {
                IsBusy = true;

                if (NewUser.FirstName == null || NewUser.FirstName == "")
                {
                    await Shell.Current.DisplayAlert("Unable to Add", "Missing First Name", "Confirm");
                    return;
                }

                if (NewUser.LastName == null || NewUser.LastName == "")
                {
                    await Shell.Current.DisplayAlert("Unable to Add", "Missing Last Name", "Confirm");
                    return;
                }

                if (NewUser.UserName == null || NewUser.UserName == "")
                {
                    await Shell.Current.DisplayAlert("Unable to Add", "Missing User Name", "Confirm");
                    return;
                }

                if (await userService.DoesUserExist(NewUser.UserName))
                {
                    await Shell.Current.DisplayAlert("Unable to Add", "User Name Already Exist", "Confirm");
                    return;
                }

                result = await userService.AddUser(NewUser);
                await Shell.Current.DisplayAlert("Success", $"Added user: {NewUser.FirstName}", "Confirm");
                await Shell.Current.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "Confirm");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

