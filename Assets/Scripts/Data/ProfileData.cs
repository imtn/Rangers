using System;
using UnityEngine;
using Assets.Scripts.Util;

/// <summary>
/// Class for saving player profile data
/// </summary>
[Serializable]
public class ProfileData
{
	private string tag;
	private Color primary, secondary;

    public ProfileData()
    {
        tag = "";
		primary = UnityEngine.Random.ColorHSV();
		secondary = UnityEngine.Random.ColorHSV();
    }
    public ProfileData(string name)
    {
        tag = name;
		primary = UnityEngine.Random.ColorHSV();
		secondary = UnityEngine.Random.ColorHSV();
    }

	public Color PrimaryColor {
		get {
			return primary;
		}
		set {
			primary = value;
		}
	}

	public Color SecondaryColor {
		get {
			return secondary;
		}
		set {
			secondary = value;
		}
	}

    public string Name
    {
        get { return tag; }
        set { tag = value; }
    }


}
