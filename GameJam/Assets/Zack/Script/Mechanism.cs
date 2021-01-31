using UnityEngine;

public class Mechanism : MonoBehaviour
{
    protected bool m_isClicked;

    public virtual void Click()
    {
        m_isClicked = true;
        Debug.Log($"{gameObject.name} clicked");
    }

    public virtual void UnClick()
    {
        m_isClicked = true;
        Debug.Log($"{gameObject.name} unclicked");
    }
}