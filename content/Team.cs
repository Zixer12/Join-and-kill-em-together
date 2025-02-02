namespace Jaket.Content;

using System;
using UnityEngine;

/// <summary> All teams. Teams needed for PvP mechanics. </summary>
public enum Team
{
    [TeamData(0, 1f, .8f, .3f)]
    Yellow,

    [TeamData(2, 1f, .2f, .1f)]
    Red,

    [TeamData(3, 0f, .9f, .4f)]
    Green,

    [TeamData(1, 0f, .5f, 1f)]
    Blue,

    [TeamData(1, 1f, .3f, .7f, true)]
    Pink
}

/// <summary> Attribute containing team data. </summary>
[AttributeUsage(AttributeTargets.Field)]
public class TeamData : Attribute
{
    /// <summary> Id of the wings texture. </summary>
    public int TextureId;
    /// <summary> Team color. Only used in interface. </summary>
    private float r, g, b;
    /// <summary> Whether the wings should be pink. </summary>
    private bool pink;

    public TeamData(int textureId, float r, float g, float b, bool pink = false)
    {
        this.TextureId = textureId;
        this.r = r;
        this.b = b;
        this.g = g;
        this.pink = pink;
    }

    /// <summary> Returns the team color. </summary>
    public Color Color() => new Color(r, g, b);

    /// <summary> Returns the color of the wings. </summary>
    public Color WingColor() => pink ? new Color(2f, 1f, 12f) : UnityEngine.Color.white;
}

/// <summary> Extension class that allows you to get team data. </summary>
public static class Extension
{
    public static TeamData Data(this Team team)
    {
        string name = Enum.GetName(typeof(Team), team);
        return Attribute.GetCustomAttribute(typeof(Team).GetField(name), typeof(TeamData)) as TeamData;
    }
}
