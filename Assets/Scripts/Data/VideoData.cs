using System;

/*
 * Class for saving video settings
 */
[Serializable]
public class VideoData
{
    private int resolutionIndex;
    private int qualityIndex;
    private bool fullScreen;

    #region Constructors
    // Default settings
    public VideoData()
    {
        resolutionIndex = 0;
        qualityIndex = 0;
        fullScreen = false;
    }

    // Manually initialize the settings
    public VideoData(int resolutionIndex, int qualityIndex, bool fullScreen)
    {
        this.resolutionIndex = resolutionIndex;
        this.qualityIndex = qualityIndex;
        this.fullScreen = fullScreen;
    }
    #endregion

    #region C# Properties
    public int ResolutionIndex
    {
        get { return resolutionIndex; }
        set { resolutionIndex = value; }
    }
    public int QualityIndex
    {
        get { return qualityIndex; }
        set { qualityIndex = value; }
    }
    public bool Fullscreen
    {
        get { return fullScreen; }
        set { fullScreen = value; }
    }
    #endregion
}
