using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{

    public Canvas canvas, UI;

    public Resolution[] resolutions;
    public int currentRes,currenQual;
    public Slider resolutionSlider, graphicSlider;
    public Toggle wind;
    public Text resolutionText, currentResolution, quality, currentQuality;
    public int qualitySize, resolutionSize;
    public Text[] setting;
    public bool windowed;

    public KeyCode pressed, lastPressedKey;
    public GameObject obj;
    public bool keyPressed, holyGrenadeChange, BlindChange, FrenzyChange, HolySmiteChange, MPChange, HPChange, InventoryChange;
    

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
    }

    void Update()
    {

        
        lastPressedKey = pressed;

        setting[0].text = KeyBindingManager.instance.HolyGrenade.ToString();
        setting[1].text = KeyBindingManager.instance.BlindingFlashLight.ToString();
        setting[2].text = KeyBindingManager.instance.Frenzy.ToString();
        setting[3].text = KeyBindingManager.instance.HolySmite.ToString();
        setting[4].text = KeyBindingManager.instance.Inventory.ToString();
        setting[5].text = KeyBindingManager.instance.HealthPotion.ToString();
        setting[6].text = KeyBindingManager.instance.ManaPotion.ToString();

        windowed = wind.isOn;
        resolutionText.text = resolutions[(int)resolutionSlider.value].width.ToString() + " x " + resolutions[(int)resolutionSlider.value].height.ToString();
        quality.text = QualitySettings.names[(int)graphicSlider.value];

        if (Input.GetKeyUp(lastPressedKey) && holyGrenadeChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.HolyGrenade = lastPressedKey;
                keyPressed = false;
                holyGrenadeChange = false;
            }
        }

        if (Input.GetKeyUp(lastPressedKey) && BlindChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.BlindingFlashLight = lastPressedKey;
                keyPressed = false;
                BlindChange = false;
            }
        }

        if (Input.GetKeyUp(lastPressedKey) && FrenzyChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.Frenzy = lastPressedKey;
                keyPressed = false;
                FrenzyChange = false;
            }
        }

        if (Input.GetKeyUp(lastPressedKey) && HolySmiteChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.HolySmite = lastPressedKey;
                keyPressed = false;
                HolySmiteChange = false;
            }
        }

        if (Input.GetKeyUp(lastPressedKey) && MPChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.ManaPotion = lastPressedKey;
                keyPressed = false;
                MPChange = false;
            }
        }

        if (Input.GetKeyUp(lastPressedKey) && HPChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.HealthPotion = lastPressedKey;
                keyPressed = false;
                HPChange = false;
            }
        }

        if (Input.GetKeyUp(lastPressedKey) && InventoryChange)
        {
            if (KeyBindingManager.instance.check(lastPressedKey))
            {
                KeyBindingManager.instance.Inventory = lastPressedKey;
                keyPressed = false;
                InventoryChange = false;
            }
        }

    }

    public void UpdateHolyGrenade()
    {
        holyGrenadeChange = true;
    }

    public void UpdateInventory()
    {
        InventoryChange = true;
    }

    public void UpdateBlindingFlashlight()
    {
        BlindChange = true;
    }

    public void UpdateFrenzy()
    {
        FrenzyChange = true;
    }

    public void UpdateHolySmite()
    {
        HolySmiteChange = true;
    }

    public void UpdateHealthPotion()
    {
        HPChange = true;
    }

    public void UpdateManaPotion()
    {
        MPChange = true;
    }

    public void resetToDefaults()
    {
        KeyBindingManager.instance.reset();
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

        Screen.SetResolution(resolutions[(int)resolutionSlider.value].width, resolutions[(int)resolutionSlider.value].height, true);
        resolutionText.text = resolutions[(int)resolutionSlider.value].width + " x " + resolutions[(int)resolutionSlider.value].height;

        currentResolution.text = "Current Resolution: \n" + resolutions[(int)resolutionSlider.value].width.ToString() + " x " + resolutions[(int)resolutionSlider.value].height.ToString();
        currentQuality.text = "Current Quality: \n" + QualitySettings.names[QualitySettings.GetQualityLevel()];

        Screen.fullScreen = !wind.isOn;

        
    }

    public void resume()
    {
        Time.timeScale = 1;
        UI.enabled = true;
        canvas.enabled = false;
        Camera.main.GetComponent<keyboardInput>().showMenu = false;

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
