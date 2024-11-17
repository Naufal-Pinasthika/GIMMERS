using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    [SerializeField] private GameObject Lanerends;
    [SerializeField] private AudioSource audioSource;
    public bool isChase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("candle"))
        {
            if (isChase)
            {
                Lanerends.SetActive(true);
            }

            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            collision.gameObject.GetComponent<CandleBehaviour>().HealthPoints -= 1;
            Debug.Log("hit " + collision.gameObject.GetComponent<CandleBehaviour>().HealthPoints);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("candle"))
        {
            if (isChase) Lanerends.SetActive(false);

            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
