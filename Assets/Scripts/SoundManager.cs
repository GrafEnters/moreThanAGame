using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource _audiosource;

    [SerializeField]
    private AudioClip _buyClip, _sellClip;

    void Start() {
        _audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundTypes type) {
        if (type == SoundTypes.Buy) {
            _audiosource.PlayOneShot(_buyClip);
        } else if (type == SoundTypes.Sell) {
            _audiosource.PlayOneShot(_sellClip);
        }
    }
}