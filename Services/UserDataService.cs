using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public class UserDataService
    {

        private UserData userDataDetails;

        public UserDataService()
        {
            userDataDetails = new()
            {
                Name = Preferences.Get("userName", ""),
                Telephone = Preferences.Get("userPhone", ""),
                Avatar = Preferences.Get("userAvatar", "")
            };
        }


        public string GetUserName() { return userDataDetails.Name; }
        public string GetUserPhone() { return userDataDetails.Telephone; }
        public string GetUserAvatar() { return "icon_user.png"; }

        public bool SetUserDataDetails(string userName, string userPhone, string userAvatar)
        {

            try
            {
                Preferences.Default.Set("userName", userName);
                Preferences.Default.Set("userPhone", userPhone);
                Preferences.Default.Set("userAvatar", userAvatar);
                return true;
            }
            catch { return false; }


        }
    }
}