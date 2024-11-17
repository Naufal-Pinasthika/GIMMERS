using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioClip sfxClip; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sfxClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("candle"))
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("candle"))
        {

            audioSource.Stop();
        }
    }
}
