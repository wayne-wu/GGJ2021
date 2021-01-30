using UnityEngine;

public class ColorVisibilitySample : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] float black;
    [Range(0, 1)] [SerializeField] float white;
    [Range(0, 1)] [SerializeField] float red;
    [Range(0, 1)] [SerializeField] float orange;
    [Range(0, 1)] [SerializeField] float yellow;
    [Range(0, 1)] [SerializeField] float green;
    [Range(0, 1)] [SerializeField] float cyan;
    [Range(0, 1)] [SerializeField] float blue;
    [Range(0, 1)] [SerializeField] float purple;

    // Update is called once per frame
    void Update()
    {
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Black, black);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.White, white);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Red, red);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Orange, orange);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Yellow, yellow);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Green, green);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Cyan, cyan);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Blue, blue);
        ColorVisibility.Instance.SetVisibility(VisibaleColorGroup.Purple, purple);
    }
}
