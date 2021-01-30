using UnityEngine;


public class VisibleColorComponent : MonoBehaviour, IColorVisibiityMessageReciever
{
    [SerializeField] VisibaleColorGroup colorGroup;
    [SerializeField] Material colorMaterial;

    SpriteRenderer spriteRenderer;
    bool isSpriteRenderer { get => spriteRenderer; }
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
        var renderer = GetComponentInChildren<Renderer>();
        if (renderer)
        {
            if (renderer is SpriteRenderer)
            {
                spriteRenderer = (SpriteRenderer)renderer;
            }
        }
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
        ResetColor();

    }

    void ResetColor()
    {
        if (isSpriteRenderer)
        {
            spriteRenderer.color = originColor;
        }
        else
        {
            if (colorMaterial)
            {
                colorMaterial.color = originColor;
            }
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
        if (isSpriteRenderer)
        {
            spriteRenderer.color = color;
        }
        else
        {
            colorMaterial.color = color;
        }
    }
}
