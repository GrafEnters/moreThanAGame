using UnityEngine;

public class SoundManager : MonoBehaviour

{
    AudioSource audiosource;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioClip[] dialog; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //audiosource.Play();
            audiosource.PlayOneShot(clip);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audiosource.Pause();
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audiosource.Stop();
        }
    }
}
