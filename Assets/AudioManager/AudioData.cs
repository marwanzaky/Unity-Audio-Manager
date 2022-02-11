using UnityEngine;

namespace MarwanZaky {
    namespace Audio {
        [System.Serializable]
        public struct AudioData {
            [SerializeField] string name;
            [SerializeField] AudioClip clip;
            [SerializeField, Range(0f, 1f)] float volume;
            [SerializeField, Range(0f, 1f)] float pitch;
            [SerializeField] bool onStart;
            [SerializeField] bool loop;

            public string Name => name;
            public bool OnStart => onStart;
            public AudioClip Clip => clip;
            public float Volume => volume;
            public float Pitch => pitch;
            public bool Loop => loop;
        }
    }
}