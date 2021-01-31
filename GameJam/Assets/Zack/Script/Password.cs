using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Password : MonoBehaviour
{
    [SerializeField] private int[] m_password;
    [SerializeField] private UnityEvent OnFail;
    [SerializeField] private UnityEvent OnSuccess;
    [SerializeField] private LampSwitcher[] m_lampSwitchers;
    [SerializeField] private Broadcast m_broadcast;
    public Louise_Test louise;
    
    private List<int> m_currentPressSequence;

    private void Awake()
    {
        m_currentPressSequence = new List<int>();
        louise = FindObjectOfType<Louise_Test>();
    }

    public void PressNumber(int number)
    {
        m_currentPressSequence.Add(number);
        int index = m_currentPressSequence.Count - 1;

        TurnOnLampPress(index);
        
        if (m_currentPressSequence.Count == 4)
        {
            ValidPassword();
        }
    }

    public void ClearPressed()
    {
        m_currentPressSequence.Clear();
        TurnAllLampsOff();
    }

    public bool ValidPassword()
    {
        for (int i = 0; i < m_password.Length; i++)
        {
            if (m_password[i] != m_currentPressSequence[i])
            {
                OnFail.Invoke();
                m_currentPressSequence.Clear();
                StartCoroutine(ValidFailDelay(1f));
                Debug.Log("Password fail!");
                return false;
            }
        }

        TurnAllLampsSuccess();
        OnSuccess.Invoke();
        m_broadcast.KeepBroadcast = false;
        Debug.Log("Password success!");
        louise.isSuccess = true;
        return true;
    }

    private IEnumerator ValidFailDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        TurnAllLampsFail();
        yield return new WaitForSeconds(seconds);
        TurnAllLampsOff();
    }
    
    private void TurnAllLampsFail()
    {
        foreach (LampSwitcher lampSwitcher in m_lampSwitchers)
        {
            lampSwitcher.TurnOnFailLamp();
            Debug.Log("Turned all lamps fail in Password");
        }
    }
    
    private void TurnAllLampsOff()
    {
        foreach (LampSwitcher lampSwitcher in m_lampSwitchers)
        {
            lampSwitcher.TurnOffLamp();
            Debug.Log("Turned all lamps off in Password");
        }
    }

    private void TurnOnLampPress(int index)
    {
        m_lampSwitchers[index].TurnOnPressedLamp();
        Debug.Log($"Turned {index} lamp on in Password");
    }
    
    private void TurnAllLampsSuccess()
    {
        foreach (LampSwitcher lampSwitcher in m_lampSwitchers)
        {
            lampSwitcher.TurnOnSuccessLamp();
            Debug.Log("Turned all lamps sucess in Password");
        }
    }
}