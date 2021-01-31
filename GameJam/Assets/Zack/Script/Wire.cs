using UnityEngine;

public class Wire : Mechanism
{
    #region Non-serialized Fields

    private Rigidbody m_rigidbody;
    private bool m_isClicked;
    private MechanismInput m_mechanismInput;

    #endregion

    #region Properties, Indexers

    public bool IsAttached { get; set; }

    #endregion

    #region Unity Event Functions

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_mechanismInput = FindObjectOfType<MechanismInput>();
    }

    private void Update()
    {
        if (m_isClicked)
        {
            MoveWire();       
        }
    }

    #endregion

    #region Public Methods

    public void ToggleKinematic(bool toggle)
    {
        m_rigidbody.isKinematic = toggle;
    }

    #endregion

    #region Private Methods

    private void MoveWire()
    {
        if (!Input.GetMouseButton(0))
        {
            ToggleCursor(true);
            return;
        }

        Vector3 wireWorldDelta = transform.TransformPoint(m_mechanismInput.MouseDelta);
        transform.position = wireWorldDelta;
        ToggleCursor(false);
    }

    public override void Click()
    {
        base.Click();
        ToggleKinematic(true);
        m_isClicked = true;
    }

    public override void UnClick()
    {
        base.UnClick();
        if (IsAttached == false)
        {
            ToggleKinematic(false);    
        }
        m_isClicked = false;
        
    }

    private static void ToggleCursor(bool toggle)
    {
        if (Cursor.visible == !toggle)
        {
            Cursor.visible = toggle;
        }
    }

    #endregion
}