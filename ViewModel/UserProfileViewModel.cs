using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CoffeeShop.ViewModel
{
    public partial class UserProfileViewModel : ObservableObject
    {

        static UserDataService userDataService = new UserDataService();

 
        [ObservableProperty]
        string userAvatar;

        [ObservableProperty]
        string userPhone;

        [ObservableProperty]
        string userName;


        public void Load()
        {
            UserName = userDataService.GetUserName();
            UserPhone = userDataService.GetUserPhone();
            UserAvatar = userDataService.GetUserAvatar();
        }

        public UserProfileViewModel() {
            Load();

        }

        [RelayCommand]
        public void UpdateUserDetailsCommand() {

            Console.WriteLine("Clicked: UpdateUserDetails");

            userDataService.SetUserDataDetails(UserName, UserPhone, "icon_user.png");


        }

    }
}

