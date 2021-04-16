using UnityEngine;

public class Sounds : Object
{
    public static AudioSource AddAudio(GameObject gameObject, AudioClip clip, float volume = 1)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.volume = volume;
        audio.playOnAwake = false;
        return audio;
    }

    public static AudioSource PlayAudio(AudioClip clip, float volume = 1)
    {
        GameObject temp = new GameObject("Temp Audio");
        DontDestroyOnLoad(temp);
        AudioSource audio = temp.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.volume = volume;
        audio.Play();
        Destroy(temp, clip.length);
        return audio;
    }
}