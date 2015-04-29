using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{

    public Canvas canvas;
    public AudioSource audio;

    public Resolution[] resolutions;
    public int currentRes,currenQual;
    public Slider resolutionSlider, graphicSlider, soundSlider;
    public Toggle wind;
    public Text resolutionText, currentResolution, quality, currentQuality;
    public int qualitySize, resolutionSize;
    public Text[] setting;
    public bool windowed;

    public KeyCode pressed, lastPressedKey;
    public bool keyPressed, endTurnChange;
    

    public CanvasGroup menuCG, settingsCG;

    void Awake()
    {

        canvas = GetComponent<Canvas>();

        windowed = !Screen.fullScreen;
        wind.isOn = windowed;

        resolutions = Screen.resolutions;

        foreach (Resolution res in resolutions)
        {
            resolutionSize++;
            if (res.height == Screen.currentResolution.height && res.width == Screen.currentResolution.width && res.refreshRate == Screen.currentResolution.refreshRate)
                currentRes = resolutionSize - 1;
        }

        resolutionSlider.maxValue = resolutionSize - 1;
        resolutionSlider.value = currentRes;
        graphicSlider.maxValue = QualitySettings.names.Length - 1;
        

        currentResolution.text = "Current Resolution: \n" + Screen.currentResolution.width.ToString() + " x " + Screen.currentResolution.height.ToString();
        currentQuality.text = "Current Quality: \n" + QualitySettings.names[QualitySettings.GetQualityLevel()];
        graphicSlider.value = QualitySettings.GetQualityLevel();

        soundSlider.value = 1;
        audio.volume = soundSlider.value / 3;
    }

    void Update()
    {
        lastPressedKey = pressed;

        setting[0].text = KeyBindingManager.Instance.endTurn.ToString();
        

        windowed = wind.isOn;
        resolutionText.text = resolutions[(int)resolutionSlider.value].width.ToString() + " x " + resolutions[(int)resolutionSlider.value].height.ToString();
        quality.text = QualitySettings.names[(int)graphicSlider.value];

        if (Input.GetKeyUp(lastPressedKey) && endTurnChange)
        {
            if (KeyBindingManager.Instance.check(lastPressedKey))
            {
                KeyBindingManager.Instance.endTurn = lastPressedKey;
                keyPressed = false;
                endTurnChange = false;
            }
        }


    }

    public void UpdateEndTurn()
    {
        endTurnChange = true;
    }

    public void resetToDefaults()
    {
        KeyBindingManager.Instance.reset();
    }

    public void mainMenu()
    {
        Application.LoadLevel("Main Menu");
        
    }

    public void settings()
    {
        menuCG.alpha = 0;
        menuCG.interactable = false;
        menuCG.blocksRaycasts = false;

        settingsCG.alpha = 1;
        settingsCG.interactable = true;
        settingsCG.blocksRaycasts = true;
    }

    public void backToMenu()
    {
        menuCG.alpha = 1;
        menuCG.interactable = true;
        menuCG.blocksRaycasts = true;

        settingsCG.alpha = 0;
        settingsCG.interactable = false;
        settingsCG.blocksRaycasts = false;
    
    }

    public void apply()
    {
        QualitySettings.SetQualityLevel((int)graphicSlider.value);

        audio.volume = soundSlider.value / 3;

        Screen.SetResolution(resolutions[(int)resolutionSlider.value].width, resolutions[(int)resolutionSlider.value].height, true);
        resolutionText.text = resolutions[(int)resolutionSlider.value].width + " x " + resolutions[(int)resolutionSlider.value].height;

        currentResolution.text = "Current Resolution: \n" + resolutions[(int)resolutionSlider.value].width.ToString() + " x " + resolutions[(int)resolutionSlider.value].height.ToString();
        currentQuality.text = "Current Quality: \n" + QualitySettings.names[QualitySettings.GetQualityLevel()];

        Screen.fullScreen = !wind.isOn;

        
    }

    public void resume()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
        Camera.main.GetComponent<keyboardInput>().showMenu = false;
    }

    public void showMenu()
    {
        canvas.enabled = true;
        Time.timeScale = 0;
    }

    void OnGUI()
    {
        keyPressed = false;
        Event e = Event.current;

        if (e.isKey)
        {
            pressed = e.keyCode;
            keyPressed = true;
        }


    }



}
