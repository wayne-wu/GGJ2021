using UnityEngine;

public class MechanismInput : MonoBehaviour
{
    private Mechanism m_selectedMechanism;
    private Vector3 m_mouseDelta;
    private Vector3 m_previousMousePos;
    public Vector3 MouseDelta => m_mouseDelta;

    private void Update()
    {
        UpdateMouseDelta();
        SelectMechanism();
    }

    private void UpdateMouseDelta()
    {
        Vector3 mouseCurrentPos = Input.mousePosition;
        m_mouseDelta = (mouseCurrentPos - m_previousMousePos) / 50f;
        m_previousMousePos = mouseCurrentPos;
    }
    
    private void SelectMechanism()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit, 10f, LayerMask.GetMask("Mechanism")) &&
            Input.GetMouseButton(0) &&
            m_selectedMechanism == null)
        {
            m_selectedMechanism = hit.collider.GetComponent<Mechanism>();
            m_selectedMechanism.Click();
        }
        else if(Input.GetMouseButton(0) == false)
        {
            if (m_selectedMechanism != null)
            {
                m_selectedMechanism.UnClick();
                m_selectedMechanism = null;
            }
        }
    }
    

}