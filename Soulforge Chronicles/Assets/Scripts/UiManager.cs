using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private GameObject startpanel;
    [SerializeField] private GameObject PausePanelBtn;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private TMP_Text fireCoinText;
    [SerializeField] private GameObject FirePanel;
    [SerializeField] private AudioSource BackRoundMusic;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Image VolumeImage;
    [SerializeField] private Sprite MuteVolumeSprite;
    [SerializeField] private Sprite UnMuteVolumeSprite;

    private void Awake()
    {
        MusicSlider.value = 1;
        Time.timeScale = 0;
        if (instance == null)
        {
            instance = this;
        }
    }

    public void MusicValue()
    {
        BackRoundMusic.volume = MusicSlider.value;
        if (BackRoundMusic.volume == 0)
        {
            VolumeImage.sprite = MuteVolumeSprite;
        }
        else
        {
            VolumeImage.sprite = UnMuteVolumeSprite;
        }
    }

    public void ChangeCoin(int count)
    {
        fireCoinText.text = count.ToString();
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

    public void OpenPausePanel()
    {
        Time.timeScale = 0;
        PausePanelBtn.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void ExitPausePanel()
    {
        PausePanel.SetActive(false);
        PausePanelBtn.SetActive(true);
        Time.timeScale = 1;
    }

    public void Mute()
    {
        if (BackRoundMusic.volume == 1)
        {
            BackRoundMusic.volume = 0;
            MusicSlider.value = 0;
            VolumeImage.sprite = MuteVolumeSprite;
        }
        else
        {
            BackRoundMusic.volume = 1;
            MusicSlider.value = 1;
            VolumeImage.sprite = UnMuteVolumeSprite;
        }
       
    }
}