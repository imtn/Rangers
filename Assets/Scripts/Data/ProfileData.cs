using System;
using UnityEngine;
using Assets.Scripts.Util;

/// <summary>
/// Class for saving player profile data
/// </summary>
[Serializable]
public class ProfileData
{
    private string name;
    private Color primary, secondary;

    public ProfileData()
    {
        name = "";
        primary = CustomColor.Black;
        secondary = CustomColor.White;
    }
    public ProfileData(string name)
    {
        this.name = name;
        primary = CustomColor.Black;
        secondary = CustomColor.White;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
