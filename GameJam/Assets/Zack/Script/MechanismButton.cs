using UnityEngine;

public class MechanismButton : Mechanism
{
    #region Serialized Fields

    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] protected Password m_password;
    [SerializeField] private int m_number;

    #endregion

    #region Override Methods

    public override void Click()
    {
        base.Click();
        m_audioSource.Play();
        m_password.PressNumber(m_number);
    }

    #endregion
}