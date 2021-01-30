using System;
using System.Collections.Generic;
using UnityEngine;

public enum VisibaleColorGroup
{ 
    None,
    White,
    Black,
    Red,
    Orange,
    Yellow,
    Green,
    Cyan,
    Blue,
    Purple
}

public interface IColorVisibiityMessageReciever
{
    void OnColorVisibilityChanged(float visibility);
}

public class ColorVisibility
{
    readonly Dictionary<VisibaleColorGroup, float> visibilities;
    readonly Dictionary<VisibaleColorGroup, List<IColorVisibiityMessageReciever>> recievers;
    public static ColorVisibility Instance 
    {
        get
        {
            if (null == instance)
            {
                instance = new ColorVisibility();
            }
            return instance;
        }
    }
    static ColorVisibility instance;

    ColorVisibility()
    {
        visibilities = new Dictionary<VisibaleColorGroup, float>();
        recievers = new Dictionary<VisibaleColorGroup, List<IColorVisibiityMessageReciever>>();
        foreach (var type in Enum.GetValues(typeof(VisibaleColorGroup)) as VisibaleColorGroup[])
        {
            if (type == VisibaleColorGroup.None)
            {
                continue;
            }
            visibilities[type] = 0f;
            recievers[type] = new List<IColorVisibiityMessageReciever>();
        }
    }

    ~ColorVisibility()
    {
        visibilities?.Clear();
        recievers?.Clear();
    }

    public static void AddReciever(VisibaleColorGroup colorGroup, IColorVisibiityMessageReciever reciever)
    {
        if (!Instance.recievers[colorGroup].Contains(reciever))
        {
            Instance.recievers[colorGroup].Add(reciever);
        }
    }
    public static void RemoveReciever(IColorVisibiityMessageReciever reciever)
    {
        if (null == reciever) return;
        foreach (var recieverList in Instance.recievers.Values)
        {
            var removeList = new List<IColorVisibiityMessageReciever>();
            foreach (var r in recieverList)
            {
                if (null == r) continue;
                if (recieverList.Contains(r))
                {
                    removeList.Add(r);
                }    
            }
            foreach (var rm in removeList)
            {
                recieverList.Remove(rm);
            }
        }
    }

    public void SetVisibility(VisibaleColorGroup colorGroup, float visibility)
    {
        if (colorGroup != VisibaleColorGroup.None)
        {
            if (visibilities[colorGroup] != visibility)
            {
                visibilities[colorGroup] = Mathf.Clamp01(visibility);
                foreach (var reciever in recievers[colorGroup])
                {
                    reciever?.OnColorVisibilityChanged(visibility);
                }
            } 
        }
    }

    public float GetVisibility(VisibaleColorGroup colorGroup)
    {
        if (visibilities.TryGetValue(colorGroup, out var visibility))
        {
            return visibility;
        }
        return 0f;
    }
}
