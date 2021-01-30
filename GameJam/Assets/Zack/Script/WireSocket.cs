using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WireSocket : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private GameObject m_targetWire;
    [SerializeField] private FuseBox m_fuseBox;
    
    [FormerlySerializedAs("m_onWireConnected")]
    public UnityEvent OnWireConnected = new UnityEvent();

    #endregion

    #region Unity Event Functions

    private void OnTriggerEnter(Collider other)
    {
        if (m_targetWire == other.gameObject)
        {
            Debug.Log($"{m_targetWire} Success!");
            OnWireConnected.Invoke();
            m_fuseBox.IncrementCorrectCount();
            other.enabled = false;
        }
    }

    #endregion
}