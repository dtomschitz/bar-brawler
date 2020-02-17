using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    ButtonClick,
    PlayerMove,
    FistAttack,
    FistHit,
    KnifeHit,
    RevolverShoot,
    ReceiveMoney
}

[System.Serializable]
public class SoundClip
{
    public Sound sound;
    public AudioClip clip;
    public float maxTimer;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [Range(0, 1)]
    public float spatialBlend = 1f;
    public float maxDistance = 100f;
}

public class AudioManager : MonoBehaviour
{
    #region Singelton

    public static AudioManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public SoundClip[] soundClips;
    private Dictionary<Sound, float> soundTimer;

    private GameObject oneShotGameObject;
    private AudioSource oneShotAudioSource;

    void Start()
    {
        soundTimer = new Dictionary<Sound, float>();
        soundTimer[Sound.PlayerMove] = 0f;
    }

    public void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlay(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;

            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            SoundClip soundClip = GetSoundClip(sound);

            SetAudioSourceConfig(audioSource, soundClip);
            audioSource.Play();

            Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    public void PlaySound(Sound sound)
    {
        if (CanPlay(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            SoundClip soundClip = GetSoundClip(sound);
            SetAudioSourceConfig(oneShotAudioSource, soundClip);

            oneShotAudioSource.PlayOneShot(oneShotAudioSource.clip);
        }
    }

    private void SetAudioSourceConfig(AudioSource audioSource, SoundClip soundClip)
    {
        audioSource.clip = soundClip.clip;
        audioSource.volume = soundClip.volume;
        audioSource.maxDistance = soundClip.maxDistance;
        audioSource.spatialBlend = soundClip.spatialBlend;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0f;
    }

    private SoundClip GetSoundClip(Sound sound)
    {
        foreach (SoundClip soundClip in soundClips)
        {
            if (soundClip.sound == sound)
            {
                return soundClip;
            }
        }

        return null;
    }

    private bool CanPlay(Sound sound)
    {
        foreach (KeyValuePair<Sound, float> soundTime in soundTimer)
        {
            if (soundTime.Key == sound)
            {
                float lastTimePlayed = soundTimer[sound];
                float maxTimer = GetSoundClip(sound).maxTimer;
                 
                if (lastTimePlayed + maxTimer < Time.time)
                {
                    soundTimer[sound] = Time.time;
                    return true;
                }
                return false;
            }
        }

        return true;
    }
}