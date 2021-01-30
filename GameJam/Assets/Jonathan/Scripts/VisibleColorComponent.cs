using UnityEngine;

public class VisibleColorComponent : MonoBehaviour, IColorVisibiityMessageReciever
{
    [SerializeField] VisibaleColorGroup colorGroup;
    [SerializeField] Material colorMaterial;

    Color originColor;

    void Reset()
    {
        if (!colorMaterial)
        {
            var renderer = GetComponentInChildren<Renderer>();
            if (renderer)
            {
                colorMaterial = renderer.sharedMaterial;
            }
        }
    }

    void Awake()
    {
        if (colorMaterial)
        {
            originColor = colorMaterial.color;
        }
    }

    void OnEnable()
    {
        if (colorGroup != VisibaleColorGroup.None)
        {
            ColorVisibility.AddReciever(colorGroup, this);
        }
        ChangeVisibility(ColorVisibility.Instance.GetVisibility(colorGroup));
    }

    void OnDisable()
    {
        if (colorGroup != VisibaleColorGroup.None)
        {
            ColorVisibility.RemoveReciever(this);
        }
        if (colorMaterial)
        {
            colorMaterial.color = originColor;
        }
    }

    public void OnColorVisibilityChanged(float visibility)
    {
        if (!colorMaterial)
            return;

        ChangeVisibility(visibility);
    }

    void ChangeVisibility(float visibility)
    {
        var color = colorMaterial.color;
        color.a = visibility;
        colorMaterial.color = color;
    }
}
