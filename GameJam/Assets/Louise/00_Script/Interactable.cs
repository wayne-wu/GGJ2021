using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum intercatableType
{
    Drug,
    Switch,
    Openthing,
    CantOpenthing,

    Count
}
public class Interactable : MonoBehaviour
{
    public intercatableType type;
    public virtual void Use()
    {
        Debug.Log("使用: " + gameObject.name);
    }
}
