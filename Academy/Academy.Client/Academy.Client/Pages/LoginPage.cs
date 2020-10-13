using Academy.ClientDataLayer;
using Academy.UtilityAndModels;
using Academy.UtilityAndModels.Models;
using System;
using Xamarin.Forms;

namespace Academy.Client.Pages
{
    public class LoginPage : ContentPage
    {
        private readonly Entry _usernameEntry;
        private readonly Entry _passwordEntry;
        private readonly Button _signinButton;
        private readonly StackLayout _mainStack;

        public LoginPage()
        {
            _usernameEntry = new Entry
            {
                Text="test@test.com",
                Placeholder="Username"
            };
            _passwordEntry = new Entry
            {
                Text="Test@123",
                Placeholder = "Password",
                IsPassword = true,
            };
            _signinButton = new Button
            {
                BackgroundColor=Color.Blue,
                TextColor=Color.White,
                Text = "Sign In",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Start,
            };
            _mainStack = new StackLayout
            {
                HorizontalOptions=LayoutOptions.FillAndExpand,
                VerticalOptions=LayoutOptions.CenterAndExpand,
                Orientation= StackOrientation.Vertical,
                Spacing =10,
                Padding=new Thickness(10,0,10,10),
                Children =
                {
                    _usernameEntry,
                    _passwordEntry,
                    _signinButton,
                }
            };
            Content = new ScrollView()
            {
                Content = _mainStack
            };
        }

        protected async override void OnAppearing()
        {
          
            _signinButton.Clicked += SignInButtonClicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _signinButton.Clicked -= SignInButtonClicked;
        }

        private async void SignInButtonClicked(object sender, EventArgs e)
        {
            if (IsValid())
            {
                UserDto userDto = new UserDto
                {
                    User = new UserModel
                    {
                        Email=_usernameEntry.Text.Trim(),
                        Password= _passwordEntry.Text.Trim()
                    }
                };
                AccountDAL accountDAL = new AccountDAL();
                accountDAL.ValidateUser(userDto);
                if (userDto.ErrCode == Enums.ErrorCode.OK)
                {
                    App.Current.MainPage = new ListPage();
                }
                else
                {
                   await DisplayAlert("Academy", userDto.ErrCode.ToString(), "Cancel");
                }
            }
        }
        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(_usernameEntry.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_passwordEntry.Text.Trim()))
            {
                return false;
            }
            return true;
        }
    }
}