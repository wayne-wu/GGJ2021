using UnityEngine;

public class WireSocket : MonoBehaviour
{
    [SerializeField]
    private GameObject m_targetWire;
    
    private void OnTriggerEnter(Collider other)
    {
        if (m_targetWire == other.gameObject)
        {
            Debug.Log($"{m_targetWire} Success!");
        }
    }
}
