using UnityEngine;

public class LampSwitcher : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_renderer;

    public void TurnOnSuccessLamp()
    {
        m_renderer.material.color = Color.green;
    }

    public void TurnOffLamp()
    {
        m_renderer.material.color = Color.grey;
    }

    public void TurnOnPressedLamp()
    {
        m_renderer.material.color = Color.yellow;
    }
    
    public void TurnOnFailLamp()
    {
        m_renderer.material.color = Color.red;
    }
}