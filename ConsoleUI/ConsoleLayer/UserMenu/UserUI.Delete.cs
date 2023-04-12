using CountPad.Domain.Models.Users;

namespace ConsoleUI.ConsoleLayer.UserMenu
{
    public partial class UserUI
    {
        private User DeleteUser()
        {
            User user = SelectUser().Result ?? new();

            return user;
        }
    }
}
