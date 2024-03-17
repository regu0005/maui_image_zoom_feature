namespace image_popup_and_zoom;

public partial class MainPage : ContentPage
{
    double currentScale = 1;
    const double ZoomFactor = 1.2;

    public MainPage()
	{
		InitializeComponent();
	}

    void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (e.Status == GestureStatus.Running)
        {
            // Calculate the scale factor to be applied
            currentScale += (e.Scale - 1) * currentScale;
            // Prevent scaling to less than the original size
            currentScale = Math.Max(1, currentScale); 

            // Apply the scale factor to the image.
            ((Image)sender).Scale = currentScale;
        }
    }

    private void OnZoomInClicked(object sender, EventArgs e)
    {
        // Increase the scale factor
        zoomableImage.Scale *= ZoomFactor;
    }

    private void OnZoomOutClicked(object sender, EventArgs e)
    {
        // Decrease the scale factor, but prevent it from becoming too small
        double newScale = zoomableImage.Scale / ZoomFactor;
        zoomableImage.Scale = Math.Max(1, newScale);
    }
}