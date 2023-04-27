namespace petaverse.frontend.mauiapp;

public class CurrentDeviceStateToLayoutSpanConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var state = values[0].ToString();

        return state == "Phone" ? 2 : 3;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
