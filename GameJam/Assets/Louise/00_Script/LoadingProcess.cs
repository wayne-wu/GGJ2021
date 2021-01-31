using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProcess : MonoBehaviour
{
    public int loadScene;
    public Image fill;
    public GameObject loadingScreen;
    public GameObject[] closeObjects;
    public Button button;
    public AsyncOperation async;
    public float currentProcess;
    public float asyncProcess;

    void Start()
    {
        //button = GetComponent<Button>();

        ////button.onClick.AddListener(() => ChooseLoadScene());

        ////fill.type = Image.Type.Filled;
        //fill.fillMethod = Image.FillMethod.Horizontal;
        //fill.fillAmount = 0;
    }

    void Update()
    {
        if (async != null)
        {
            LoadScene();
        }
    }
    public void ChooseLoadScene()
    {
        //loadingScreen.SetActive(true);
        //if (closeObjects != null)
        //{
        //    for (int i = 0; i < closeObjects.Length; i++)
        //    {
        //        closeObjects[i].SetActive(false);
        //    }
        //}
        async = SceneManager.LoadSceneAsync(loadScene);
        //async.allowSceneActivation = false;
    }
    public void LoadScene()
    { 
        //因為設定讀取完後不能自動跳場景 所以最大值是0.9
        if (async.progress < 0.9f)
        {
            asyncProcess = async.progress * 100;
        }
        else
        {
            asyncProcess = 100;
        }

        if (currentProcess < asyncProcess)
        {
            currentProcess++;
        }
        fill.fillAmount = (float)(currentProcess / 100);
        if (currentProcess == 100)
        {
            async.allowSceneActivation = true;
        }
    }
}
