using System.Threading;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using TimeKeeper.Http;
using TimeKeeper.Models;

namespace TimeKeeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserService _userService;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //Commands
        public ICommand ShowHomeViewCommand { get; }

        //Constructor
        public MainViewModel()
        {
            _userService = new UserService();
            CurrentUserAccount = new UserAccountModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

            //LoadCurrentUserData();
        }

        

        //Methods
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home View";
            Icon = IconChar.Home;
        }
        
        private void LoadCurrentUserData()
        {
            var token = Thread.CurrentPrincipal.Identity.Name;
            var user = _userService.DisplayUserInfo(token);

            if (user != null)
            {
                CurrentUserAccount.Username = user.email;
                CurrentUserAccount.DisplayName = user.FullName;
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                Application.Current.Shutdown();
            }
        }
    }
}
