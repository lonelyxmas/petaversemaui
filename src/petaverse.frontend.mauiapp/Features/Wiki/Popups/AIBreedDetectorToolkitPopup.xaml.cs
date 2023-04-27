using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace petaverse.frontend.mauiapp;

public partial class AIBreedDetectorToolkitPopup : Popup, INotifyPropertyChanged
{
    #region [ Properties ]

    private ImageSource capturedBreed;
    public ImageSource CapturedBreed
    {
        get { return this.capturedBreed; }
        set { this.SetPropertyValue(ref this.capturedBreed, value); }
    }

    private BreedCardModel predictedBreed;
    public BreedCardModel PredictedBreed
    {
        get { return this.predictedBreed; }
        set { this.SetPropertyValue(ref this.predictedBreed, value); }
    }

    #endregion

    #region [ CTor ]
    public AIBreedDetectorToolkitPopup(ImageSource capturedBreed, BreedCardModel predictedBreed)
    {
        InitializeComponent();
        CapturedBreed = capturedBreed;
        PredictedBreed = predictedBreed;
    }
    #endregion

    private void Right_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private void Wrong_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (value == null ? field != null : !value.Equals(field))
        {
            field = value;

            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            return true;
        }
        return false;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}