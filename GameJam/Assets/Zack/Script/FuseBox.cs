using UnityEngine;
using UnityEngine.Events;

public class FuseBox : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_onFuseComplete;
    private static int CorrectCount;

    public void IncrementCorrectCount()
    {
        CorrectCount++;

        if (CorrectCount == 4)
        {
            m_onFuseComplete.Invoke();
        }
    }
}
