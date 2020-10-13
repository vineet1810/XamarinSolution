using Academy.ClientDataLayer;
using Academy.UtilityAndModels;
using Academy.UtilityAndModels.Models;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Academy.Client.Pages
{
    public class ListPage : ContentPage
    {
        readonly ListView _listView;
        readonly StackLayout _mainLayout;
        readonly Button _switchuser;
        readonly Button _adduser;
        readonly UserDto userDto = new UserDto { Users =new List<UserModel>() };
        public ListPage()
        {
            new AccountDAL().GetUsers(userDto);
            _mainLayout = new StackLayout
            {
                Spacing = 10,
                Padding = new Thickness(10, 10, 10, 10),
                IsVisible = true,
            };
            _listView = new ListView
            {
                ItemsSource = userDto.Users,
                IsVisible=true,
                ItemTemplate = new DataTemplate(typeof(StudentViewCell)),
            };
            _switchuser = new Button
            {
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                Text = "Switch User",
                VerticalOptions = LayoutOptions.End,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            _adduser = new Button
            {
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                Text = "Add User",
                VerticalOptions = LayoutOptions.End,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            _mainLayout.Children.Add(_listView);
            _mainLayout.Children.Add(_switchuser);
            Content = _mainLayout;
        }
        protected override void OnAppearing()
        {
            if (_mainLayout.Children.Contains(_adduser))
            {
                _mainLayout.Children.Remove(_adduser);
            }
            if (Preferences.Get(Constants.UserRoleIDPreference, 0) == 1)
            {
                _mainLayout.Children.Add(_adduser);
            }
            _listView.ItemTapped += OnListItemClickAsync;
            _switchuser.Clicked += OnSwitchUserClickAsync;
            _adduser.Clicked += OnAddUserClickAsync;
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            _listView.ItemTapped -= OnListItemClickAsync;
            _switchuser.Clicked -= OnSwitchUserClickAsync;
            _adduser.Clicked -= OnAddUserClickAsync;
            base.OnDisappearing();
        }

        private void OnListItemClickAsync(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            UserModel listItem = e.Item as UserModel;
            App.Current.MainPage = new StudentEditPage(listItem);
        }

        private void OnAddUserClickAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new StudentEditPage( new UserModel());
        }

        private void OnSwitchUserClickAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

    }
}
