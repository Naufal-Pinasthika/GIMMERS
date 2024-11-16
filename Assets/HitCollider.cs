using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    [SerializeField] private GameObject Lanerends;
    public bool isChase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("candle"))
        {
            if (isChase)
            {
                Lanerends.SetActive(true);
            }
            collision.gameObject.GetComponent<CandleBehaviour>().HealthPoints -= 1;
            Debug.Log("hit" + collision.gameObject.GetComponent<CandleBehaviour>().HealthPoints);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("candle")) if (isChase) Lanerends.SetActive(false);
    }
}
