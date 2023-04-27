namespace petaverse.frontend.mauiapp;

internal class CreatePetPopupStringToListStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stringValue = value.ToString() ?? string.Empty;
        return !string.IsNullOrWhiteSpace(stringValue) ? stringValue.Split(',').Select(hexColor => Color.FromHex(hexColor.Trim())).ToList()
                                                       : new List<Color>();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
