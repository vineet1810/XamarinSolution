using Academy.ClientDataLayer;
using Academy.UtilityAndModels;
using Academy.UtilityAndModels.Models;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Academy.UtilityAndModels.Enums;

namespace Academy.Client.Pages
{
    public class StudentEditPage : ContentPage
    {
        private readonly Entry _firstNameEntry;
        private readonly Entry _lastNameEntry;
        private readonly Entry _addressEntry;
        private readonly Entry _emailIDEntry;
        private readonly Entry _contactEntry;
        private readonly Entry _classEntry;
        private readonly DatePickerCustom _birthDate;
        private readonly Picker _genderDropDwon;
        private readonly Button _saveButton;
        private readonly Button _backButton;
        private readonly Button _auditButton;
        private readonly StackLayout _mainStack;
        private readonly UserDto _userDto = new UserDto();

        public StudentEditPage(UserModel userModel)
        {
            _userDto.User = userModel;
            _firstNameEntry = new Entry
            {
                Placeholder = nameof(UserModel.FirstName),
            };
            _lastNameEntry = new Entry
            {
                Placeholder = nameof(UserModel.LastName),
            };
            _addressEntry = new Entry
            {
                Placeholder = nameof(UserModel.Address),
            };
            _emailIDEntry = new Entry
            {
                Placeholder = nameof(UserModel.Email),
            };
            _contactEntry = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = nameof(UserModel.ContactNo),
            };
            _classEntry = new Entry
            {
                IsEnabled = false,
                Placeholder = nameof(UserModel.Class),
            };
            _birthDate = new DatePickerCustom
            {
                Placeholder = nameof(UserModel.BirthDate),
            };
            _genderDropDwon = new Picker
            {
                ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList(),
            };
            _saveButton = new Button
            {
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                Text = "Save",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.End,
            };
            _backButton = new Button
            {
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                Text = "Back",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.End,
            };
            _auditButton = new Button
            {
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                Text = "Audit",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.End,
            };
            _mainStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Padding = new Thickness(10, 0, 10, 10),
                Children =
                {
                    _firstNameEntry,
                    _lastNameEntry,
                    _addressEntry,
                    _emailIDEntry,
                    _contactEntry,
                    _classEntry,
                    _birthDate,
                    _genderDropDwon,
                    _saveButton,
                    _backButton
                }
            };
            Content = new ScrollView()
            {
                Content = _mainStack
            };
        }

        protected async override void OnAppearing()
        {
            if (_mainStack.Children.Contains(_auditButton))
            {
                _mainStack.Children.Remove(_auditButton);
            }
            if (_userDto.User.UserId > 0)
            {
                _firstNameEntry.Text = _userDto.User.FirstName;
                _lastNameEntry.Text = _userDto.User.LastName;
                _addressEntry.Text = _userDto.User.Address;
                _emailIDEntry.Text = _userDto.User.Email;
                _contactEntry.Text = Convert.ToString(_userDto.User.ContactNo);
                _classEntry.Text = Convert.ToString(_userDto.User.Class);
                _birthDate.Date = _userDto.User.BirthDate.DateTime;
                _genderDropDwon.SelectedIndex = _genderDropDwon.ItemsSource.IndexOf((Gender)_userDto.User.Gender);

            }
            if (Preferences.Get(Constants.UserRoleIDPreference,0) == 1 && _userDto.User.UserId > 0)
            {
                _mainStack.Children.Add(_auditButton);
            }
            _saveButton.Clicked += SaveButtonClicked;
            _auditButton.Clicked += AuditButtonClicked;
            _backButton.Clicked += BackButtonClicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _saveButton.Clicked -= SaveButtonClicked;
            _auditButton.Clicked -= AuditButtonClicked;
            _backButton.Clicked -= BackButtonClicked;
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            if (IsValid())
            {
                _userDto.User.FirstName = _firstNameEntry.Text;
                _userDto.User.LastName = _lastNameEntry.Text;
                _userDto.User.Address = _addressEntry.Text;
                _userDto.User.Email = _emailIDEntry.Text;
                _userDto.User.ContactNo = Convert.ToInt64(_contactEntry.Text);
                _userDto.User.Class = Convert.ToInt32(_classEntry.Text);
                _userDto.User.BirthDate = _birthDate.Date;
                _userDto.User.Gender = (int)_genderDropDwon.SelectedItem;
                await new AccountDAL().SaveUser(_userDto);
                if (_userDto.ErrCode == Enums.ErrorCode.OK)
                {
                    App.Current.MainPage = new ListPage();
                }
                else
                {
                    await DisplayAlert("Academy", _userDto.ErrorMessage, "Cancel");
                }
            }
        }

        private async void AuditButtonClicked(object sender, EventArgs e)
        {
            await new AccountDAL().AuditStudent(_userDto);
            if (_userDto.ErrCode == Enums.ErrorCode.OK)
            {
                App.Current.MainPage = new ListPage();
            }
            else
            {
                await DisplayAlert("Academy", _userDto.ErrCode.ToString(), "Cancel");
            }
        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ListPage();
        }
        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(_firstNameEntry.Text?.Trim()))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_lastNameEntry.Text?.Trim()))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_addressEntry.Text?.Trim()))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_emailIDEntry.Text?.Trim()))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_contactEntry.Text?.Trim()))
            {
                return false;
            }
            return true;
        }
    }
}