using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Colors : IComparable<Colors>
{
    public string name;
    public Color color;

    public Colors(string newName,Color newColor)
    {
        this.name = newName;
        this.color = newColor;
    }

    public int CompareTo (Colors other)
    {
        if (other.name == this.name)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}