using Xamarin.Forms;

namespace Academy.UtilityAndModels
{
    public class DatePickerCustom : DatePicker
    {
        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(DatePickerCustom), defaultValue: default(string));
        public string Placeholder { get; set; }
    }
}
