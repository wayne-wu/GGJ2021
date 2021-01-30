using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Non-serialized Fields

    private GameObject m_selectedWire;
    private Vector3 m_previousMousePos;
    private Vector3 m_mouseDelta;

    #endregion

    #region Unity Event Functions

    private void Update()
    {
        UpdateMouseDelta();
        SelectWire();
        MoveWire();
    }

    private void UpdateMouseDelta()
    {
        Vector3 mouseCurrentPos = Input.mousePosition;
        m_mouseDelta = (mouseCurrentPos - m_previousMousePos) / 50f;
        m_previousMousePos = mouseCurrentPos;
    }

    private void MoveWire()
    {
        if (m_selectedWire == null || !Input.GetMouseButton(0))
        {
            ToggleCursor(true);
            return;
        }
        
        Vector3 wireWorldDelta = m_selectedWire.transform.TransformPoint(m_mouseDelta);
        m_selectedWire.transform.position = wireWorldDelta;
        ToggleCursor(false);
    }

    private static void ToggleCursor(bool toggle)
    {
        if (Cursor.visible == !toggle)
        {
            Cursor.visible = toggle;
        }
    }

    #endregion

    #region Private Methods

    private void SelectWire()
    {
        if (Input.GetMouseButton(0) == false && m_selectedWire)
        {
            Wire wire = m_selectedWire.GetComponent<Wire>();
            if (wire.IsAttached == false)
            {
                wire.ToggleKinematic(false);    
            }
            m_selectedWire = null;
            return;
        }

        if (m_selectedWire == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.blue);
            if (Physics.Raycast(ray, out RaycastHit hit, 10f, LayerMask.GetMask("Wire")))
            {
                m_selectedWire = hit.collider.gameObject;
                Wire wire = m_selectedWire.GetComponent<Wire>();
                wire.ToggleKinematic(true);
            }
        }
    }

    #endregion
}