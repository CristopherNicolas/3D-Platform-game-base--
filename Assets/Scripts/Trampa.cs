using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 targetEndPos;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("flag");
            target.transform.DOLocalMove(targetEndPos, 3.58f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("flag");
            target.transform.DOLocalMove(targetEndPos, 3.58f);
            Destroy(gameObject);
        }
    }
}
