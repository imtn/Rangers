using System;

/*
 * Class for saving audio settings
 */
[Serializable]
public class AudioData
{
    private float sfxVol;
    private float musicVol;
    private float voiceVol;

    #region Constructors
    // Default settings
    public AudioData()
    {
        sfxVol = 1f;
        musicVol = 1f;
        voiceVol = 1f;
    }

    // Manually initialize the settings
    public AudioData(float sfxVol, float musicVol, float voiceVol)
    {
        this.sfxVol = sfxVol;
        this.musicVol = musicVol;
        this.voiceVol = voiceVol;
    }
    #endregion

    #region C# Properties
    public float SFXVol
    {
        get { return sfxVol; }
        set { sfxVol = value; }
    }
    public float MusicVol
    {
        get { return musicVol; }
        set { musicVol = value; }
    }
    public float VoiceVol
    {
        get { return voiceVol; }
        set { voiceVol = value; }
    }
    #endregion
}
