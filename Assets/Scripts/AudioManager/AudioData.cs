using UnityEngine;

[System.Serializable]
public struct AudioData {
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;
    [Range(-3f, 3f)] public float pitch;
    public bool loop;
}