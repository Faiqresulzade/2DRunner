using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private GameObject startpanel;
    [SerializeField] private TMP_Text fireCoinText;
    [SerializeField] private GameObject FirePanel;

    private void Awake()
    {
        Time.timeScale = 0;
        if(instance == null)
        {
            instance = this;
        }

    }

    public void ChangeCoin(int count)
    {
        fireCoinText.text=count.ToString();
    }
    public void MyStart()
    {
        Time.timeScale = 1f;
        FirePanel.SetActive(true);
    }

    public void StartClose()
    {
        startpanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
