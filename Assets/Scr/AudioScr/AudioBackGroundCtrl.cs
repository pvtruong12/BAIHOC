using Assets.Scr;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioBackGroundCtrl : PVTBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    public string parameterName = "MusicVolum"; 
    public float volumeStep = 1f;
    public float minVolume = -80f;
    public float maxVolume = 0f;
    private float currentVolume;
    public AudioMixer audioMixer;
    protected override void loadComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected void Start()
    {
        audioSource.Play();
        audioMixer.GetFloat(parameterName, out currentVolume);
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            currentVolume = Mathf.Clamp(currentVolume + volumeStep, minVolume, maxVolume);
            audioMixer.SetFloat(parameterName, currentVolume);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            currentVolume = Mathf.Clamp(currentVolume - volumeStep, minVolume, maxVolume);
            audioMixer.SetFloat(parameterName, currentVolume);
        }
    }
}
