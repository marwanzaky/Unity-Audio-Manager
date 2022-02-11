using UnityEngine;
using System.Collections;
using System;
using MarwanZaky.Audio;

public class AudioManager : MonoBehaviour {
    #region Singletone

    public static AudioManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Debug.Log($"Multiple AudioManager instances found (Deleted)");
            Destroy(gameObject);
        }
    }

    #endregion

    (GameObject gameObject, AudioClip audioClip) defaultVal = (null, null);

    [SerializeField] AudioManagerData data;

    private void Start() {
        foreach (var el in data.AudioDatas)
            if (el.OnStart)
                Play(el.Name);
    }

    public (GameObject gameObject, AudioClip audioClip) Play(string name) {
        foreach (var audioData in data.AudioDatas)
            if (audioData.Name == name)
                return Play(audioData);

        Debug.LogError($"Error: the audioClip name of {name} is not found");
        return defaultVal;
    }

    public (GameObject gameObject, AudioClip audioClip) Play(AudioData audioData, Action onDestroy = null) {
        var newAudioGo = new GameObject(audioData.Clip.name);
        var audioSource = newAudioGo.AddComponent<AudioSource>();

        audioSource.clip = audioData.Clip;
        audioSource.volume = audioData.Volume;
        audioSource.pitch = audioData.Pitch;
        audioSource.loop = audioData.Loop;

        audioSource.Play();

        if (!audioData.Loop)
            DestroyGameObject(newAudioGo, onDestroy, lifetime: audioData.Clip.length);

        return (newAudioGo, audioData.Clip);
    }

    private IEnumerator DestroyGameObject(GameObject gameObject, Action onDestroy, float lifetime) {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
        onDestroy?.Invoke();
    }
}