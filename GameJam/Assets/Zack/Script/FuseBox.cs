using UnityEngine;
using UnityEngine.Events;

public class FuseBox : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_onFuseComplete;
    private static int CorrectCount;
    public Door door;
    void Start()
    {
        door = FindObjectOfType<Door>();
    }
    public void IncrementCorrectCount()
    {
        CorrectCount++;

        if (CorrectCount == 4)
        {
            door.isLock = false;
            m_onFuseComplete.Invoke();
        }
    }
}
