using UnityEngine;

public enum Pitch { VeryLow, Low, Medium, High, VeryHigh }

[System.Serializable]
public struct AudioData {
    [SerializeField] string name;
    [SerializeField] bool onStart;
    [SerializeField] AudioClip clip;
    [SerializeField, Range(0f, 1f)] float volume;
    [SerializeField] Pitch pitch;
    [SerializeField] bool loop;

    public string Name {
        get => name;
    }

    public bool OnStart {
        get => onStart;
    }

    public AudioClip Clip {
        get => clip;
    }

    public float Volume {
        get => volume;
    }

    public float Pitch {
        get {
            switch (pitch) {
                case global::Pitch.VeryLow: return .5f;
                case global::Pitch.Low: return .5f;
                case global::Pitch.Medium: return 1f;
                case global::Pitch.High: return 2f;
                case global::Pitch.VeryHigh: return 3f;
                default: return 0f;
            }
        }
    }

    public bool Loop {
        get => loop;
    }
}