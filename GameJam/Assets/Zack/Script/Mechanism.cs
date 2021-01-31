using UnityEngine;

public class Mechanism : MonoBehaviour
{
    protected bool m_isClicked;
    protected MechanismInput m_mechanismInput;

    protected virtual void Awake()
    {
        m_mechanismInput = FindObjectOfType<MechanismInput>();
    }

    public virtual void Click()
    {
        m_isClicked = true;
        Debug.Log($"{gameObject.name} clicked");
    }

    public virtual void UnClick()
    {
        m_isClicked = false;
        Debug.Log($"{gameObject.name} unclicked");
    }
}