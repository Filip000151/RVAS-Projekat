using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource AudioSrc;

    public AudioClip MenuButtonSnd;
    

    public void PlayMenuButtonSound()
    {
        AudioSrc.PlayOneShot(MenuButtonSnd);
    }

    
}
