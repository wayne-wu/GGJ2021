using UnityEngine;

public class Wire : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public bool IsAttached { get; set; }
    
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void ToggleKinematic(bool toggle)
    {
        m_rigidbody.isKinematic = toggle;
    }
}
