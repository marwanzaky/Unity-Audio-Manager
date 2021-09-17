using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    [Header("Base Settings"), SerializeField] Rigidbody _rigidbody;
    [SerializeField] float jumpForce = 250f;

    [Header("Audio Clips"), SerializeField] string jumpClipName = "Jump";
    [SerializeField] string landClipName = "Land";

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Jump() {
        AudioManager.Instance.Play(jumpClipName);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * jumpForce);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground"))
            AudioManager.Instance.Play(landClipName);
    }
}