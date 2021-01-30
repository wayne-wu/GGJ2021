using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDrug : Drug
{
    public VisibaleColorGroup colorGroup;
    public override void Use()
    {
        base.Use();
        ColorVisibility.Instance.SetVisibility(colorGroup, 1f);
    }
    public override IEnumerator Recovery()
    {
        yield return new WaitForSeconds(10f);
        ColorVisibility.Instance.SetVisibility(colorGroup, 0f);
    }
}
