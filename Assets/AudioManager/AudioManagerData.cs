
using UnityEngine;

namespace MarwanZaky {
    namespace Audio {
        [CreateAssetMenu(fileName = "New Audio Manager Data", menuName = "Scriptable Objects/Audio Manager Data", order = 20)]
        public class AudioManagerData : ScriptableObject {
            [SerializeField] AudioData[] audioDatas;

            public AudioData[] AudioDatas => audioDatas;
        }
    }
}