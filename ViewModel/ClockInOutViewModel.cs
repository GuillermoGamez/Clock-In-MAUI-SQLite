using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Clock_In_System_with_MAUI_and_SQLite.View;
using Clock_In_System_with_MAUI_and_SQLite.Model;
using Clock_In_System_with_MAUI_and_SQLite.Service;

namespace Clock_In_System_with_MAUI_and_SQLite.ViewModel
{
    public partial class ClockInOutViewModel : BaseViewModel
    {
        readonly UserService userService;
        readonly ClockEntryService clockEntryService;

        public ClockInOutViewModel(UserService userService, ClockEntryService clockEntryService)
        {
            GoToAddUserCommand = new RelayCommand(async () => await GoToAddUser());
            ClockInOutCommand = new RelayCommand(async () => await ClockInOut());

            this.userService = userService;
            this.clockEntryService = clockEntryService;
        }

        [ObservableProperty]
        string userName;

        public RelayCommand GoToAddUserCommand { get; private set; }
        public RelayCommand ClockInOutCommand { get; private set; }

        public async Task GoToAddUser()
        {
            await Shell.Current.GoToAsync(nameof(AddUserView), true);
        }

        public async Task ClockInOut()
        {
            if (IsBusy)
                return;

            User user = await userService.GetUser(UserName);

            if (user == null)
            {
                await Shell.Current.DisplayAlert("Invalid", "User Name Invalid", "Confirm");
                return;
            }

            ClockEntry clockEntry = await clockEntryService.GetLastEntry(user);

            int clockType = 0;
            if (clockEntry == null)
            {
                clockType = (int)ClockEntryTypes.ClockIn;
            }
            else
            {
                if (clockEntry.ClockEntryType == (int)ClockEntryTypes.ClockIn)
                    clockType = (int)ClockEntryTypes.ClockOut;
                else
                    clockType = (int)ClockEntryTypes.ClockIn;
            }

            ClockEntry newEntry = new ClockEntry()
            {
                UserId = user.UserId,
                DateTime = DateTime.Now,
                ClockEntryType = clockType,
            };

            await clockEntryService.AddClockEntry(newEntry);

            if (newEntry.ClockEntryType == (int)ClockEntryTypes.ClockIn)
                await Shell.Current.DisplayAlert("Sucess", "You have clocked in!", "Confirm");
            else
                await Shell.Current.DisplayAlert("Sucess", "You have clocked out!", "Confirm");
        }
    }
}