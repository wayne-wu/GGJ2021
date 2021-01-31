using UnityEngine;

public class Mechanism : MonoBehaviour
{
    public virtual void Click()
    {
        Debug.Log($"{gameObject.name} clicked");
    }

    public virtual void UnClick()
    {
        Debug.Log($"{gameObject.name} unclicked");
    }
}