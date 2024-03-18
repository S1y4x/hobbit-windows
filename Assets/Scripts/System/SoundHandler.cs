using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    private float musicLevel, sfxLevel;
    public Slider musicSlider, sfxSlider;
    public AudioSource[] sfxSounds = new AudioSource[9];
    public AudioSource[] mainTheme = new AudioSource[1];

    private void Start()
    {
        musicLevel = PlayerPrefs.GetFloat("Music", .5f);
        sfxLevel = PlayerPrefs.GetFloat("SFX", .5f);
        musicSlider.value = musicLevel;
        sfxSlider.value = sfxLevel;
    }
    private void Update()
    {
        foreach(AudioSource melody in mainTheme)
            melody.volume = musicLevel;
        
        foreach (AudioSource sfx in sfxSounds)
            sfx.volume = sfxLevel;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void SetMusicVolumeLevel(float musicVolume)
    {
        musicLevel = musicVolume;
        PlayerPrefs.SetFloat("Music", musicLevel);
    }

    public void SetSFXVolumeLevel(float sfxVolume)
    {
        sfxLevel = sfxVolume;
        PlayerPrefs.SetFloat("SFX", sfxLevel);
    }
}
