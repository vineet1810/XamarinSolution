using Academy.UtilityAndModels.Models;
using Xamarin.Forms;

namespace Academy.Client.Pages
{
    public class StudentViewCell : ViewCell
    {
        public StudentViewCell()
        {
            var userFirstName = new Label
            {
                Margin= new Thickness(10,0),
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            userFirstName.SetBinding(Label.TextProperty, nameof(UserModel.FirstName));
            var userLastName = new Label
            {
                Margin = new Thickness(10, 0),
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            userLastName.SetBinding(Label.TextProperty, nameof(UserModel.LastName));
            var @class = new Label
            {
                Margin = new Thickness(10, 0),
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            @class.SetBinding(Label.TextProperty, nameof(UserModel.Class));
            var audited = new Label
            {
                Margin = new Thickness(10, 0),
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            audited.SetBinding(Label.TextProperty, nameof(UserModel.AuditedString));
            audited.SetBinding(Label.TextColorProperty, nameof(UserModel.AuditedColor));
            var mainGrid = new Grid
            {
                RowSpacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    }
            };
            mainGrid.Children.Add(userFirstName, 0, 0);
            mainGrid.Children.Add(userLastName, 0, 1);
            mainGrid.Children.Add(@class, 1, 0);
            mainGrid.Children.Add(audited, 1, 1);
            Frame objFrame_Outer = new Frame
            {
                Padding = new Thickness(0, 0, 0, 10),
                Content = mainGrid,
                CornerRadius=4,
                BorderColor = Color.Accent,
            };
            View = objFrame_Outer;
        }
    }
}