using UnityEngine.Audio;
using System;
using UnityEngine;

public class WaterBombAudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.outputMixerGroup;
            s.source.spatialBlend = s.spatialBlend;
            s.source.minDistance = s.minDist;
            s.source.maxDistance = s.maxDist;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            s.source.Play();
    }

    public float Length(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            return s.source.clip.length;
        return 0f;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            s.source.Stop();
    }
}