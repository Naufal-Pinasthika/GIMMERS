using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LaneBehaviour : MonoBehaviour
{ 
    [System.Serializable]
    private class Lanes
    {
        public GameObject LaneRend;
        public GameObject LaneCol;
    }
    [SerializeField]
    private List<Lanes> Lane;
    [SerializeField] int redlaneCount = 0;
    private void Start()
    {
        StartCoroutine(generateLanes());
    }
    IEnumerator generateLanes()
    {
        while (true) {
            redlaneCount = 0;
            foreach (Lanes go in Lane)
            {
                bool val = (Random.Range(0, 2) == 0);            
                if (redlaneCount < 1 && val) {
                    redlaneCount++;
                    go.LaneRend.SetActive(val);                  
                }   
                else go.LaneRend.SetActive(false);
            }
            if (redlaneCount == 1)
            {
                foreach (Lanes col in Lane)
                {
                    col.LaneRend.SetActive(false);
                    col.LaneCol.SetActive(true);
                    col.LaneCol.GetComponent<HitCollider>().isChase = true;
                }
                yield return new WaitForSeconds(6);
                foreach (Lanes col in Lane)
                {
                    col.LaneCol.GetComponent<HitCollider>().isChase = false;
                    col.LaneCol.SetActive(false);              
                }
                yield return new WaitForSeconds(2);
                foreach (Lanes col in Lane) col.LaneRend.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(3);
                foreach (Lanes col in Lane)
                {
                    if (col.LaneRend.gameObject.activeSelf) col.LaneRend.GetComponent<RawImage>().enabled = false;
                }
                yield return new WaitForSeconds(1.2f);
                foreach (Lanes col in Lane)
                {
                    if (col.LaneRend.gameObject.activeSelf)
                        col.LaneCol.SetActive(true);
                    col.LaneRend.GetComponent<RawImage>().enabled = true;
                    col.LaneRend.SetActive(false);
                }
                yield return new WaitForSeconds(0.01f);
                foreach (Lanes col in Lane) col.LaneCol.SetActive(false);
            }
        }
    }
 }
