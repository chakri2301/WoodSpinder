using UnityEngine;
using UnityEngine.UI;

//Audio from https://musiclab.chromeexperiments.com/Song-Maker/song/4631320575213568
//https://musiclab.chromeexperiments.com/Song-Maker/song/5226400390447104
//https://musiclab.chromeexperiments.com/Song-Maker/song/5733867268472832
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    int currAudio = 0;
    public Image audioImage;
    bool muted = true;
    public Sprite mutedSprite;
    public Sprite unMutedSprite;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        InvokeRepeating(nameof(ChangeAudio), clips[0].length, clips[0].length);
    }
    void ChangeAudio()
    {
        currAudio++;
        if(currAudio >= clips.Length)
        {
            currAudio = 0;
        }
        audioSource.clip = clips[currAudio];
        audioSource.Play();
    }
    public void ChangeVolume()
    {
        if (muted)
        {
            audioImage.sprite = unMutedSprite;
            audioSource.volume = 1;
            muted = false;
        }
        else
        {
            muted = true;
            audioImage.sprite = mutedSprite;
            audioSource.volume = 0;
        }
    }
}
