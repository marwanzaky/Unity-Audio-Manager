using UnityEngine;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour {
    #region Singletone

    public static AudioManager Instance { get; private set; }

    void Awake() {
        if (Instance == null) { Instance = this; } else {
            Debug.LogError("Error: multiple Audio Manager instances found");
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField] AudioManagerData data;

    public (GameObject gameObject, AudioClip audioClip) Play(string name) {
        foreach (var el in data.Datas) {
            if (el.name == name) {
                return Play(el);
            }
        }

        return (null, null);
    }

    public (GameObject gameObject, AudioClip audioClip) Play(AudioData data, Action onDestroy = null) {
        var res = (go: null as GameObject, ac: null as AudioClip);

        var coroutine = PlayIE(data, onDestroy, (go, ac) => {
            res.go = go; res.ac = ac;
        });

        StartCoroutine(coroutine);

        return res;
    }

    IEnumerator PlayIE(AudioData data, Action onDestory, Action<GameObject, AudioClip> result) {
        var go = new GameObject(data.clip.name);
        var audioSource = go.AddComponent<AudioSource>();

        audioSource.clip = data.clip;
        audioSource.volume = data.volume;
        audioSource.pitch = data.pitch;
        audioSource.loop = data.loop;
        audioSource.Play();

        if (!data.loop) {
            Destroy(go, data.clip.length);
        }

        result?.Invoke(go, audioSource.clip);

        yield return new WaitForSeconds(data.clip.length);

        onDestory?.Invoke();
    }
}