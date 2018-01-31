using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour {

	public Dropdown resolutionDropdown;
	public Slider mainVolumeSlider;
	public Button applySettings;

	public AudioSource audioSource;
	public GameSettings gameSettings;
	public Resolution[] resolutions;
	public GameSettings gameSettingsLoaded;

	void OnEnable()
	{
		gameSettings = new GameSettings ();
		gameSettingsLoaded = new GameSettings ();

		resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
		mainVolumeSlider.onValueChanged.AddListener(delegate { OnMainVolumeChange(); });
		applySettings.onClick.AddListener(delegate { OnApplySettingsClick(); });

		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) 
		{
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}
		
		LoadSettings();

	}
	
	public void OnResolutionChange()
	{
		Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionList = resolutionDropdown.value;
	}

	public void OnMainVolumeChange()
	{
		audioSource.volume = gameSettings.mainVolume = mainVolumeSlider.value;
		gameSettings.mainVolume = mainVolumeSlider.value;
	}

	public void OnApplySettingsClick()
	{
		SaveSettings();
	}
	
	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsonData);
	}
	
	public void LoadSettings()
	{
		gameSettingsLoaded = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
		mainVolumeSlider.value = gameSettings.mainVolume;
		resolutionDropdown.value = gameSettings.resolutionList;

		resolutionDropdown.RefreshShownValue ();
	}
}