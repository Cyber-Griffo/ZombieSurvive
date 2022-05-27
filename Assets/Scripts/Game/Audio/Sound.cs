using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    public AudioMixerGroup outputMixerGroup;
    [Range(0f, 1f)]
    public float spatialBlend;
    public float minDist;
    public float maxDist;

    [System.NonSerialized]
    public AudioSource source;

}
