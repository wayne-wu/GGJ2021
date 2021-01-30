using UnityEngine;

public class Wire : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void ToggleGravity(bool toggle)
    {
        m_rigidbody.useGravity = toggle;
    }
}
