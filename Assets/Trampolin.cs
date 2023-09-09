using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    Coroutine routine;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("flag");
            if (routine == null) routine = StartCoroutine(Efect(collision.gameObject.GetComponent<Personaje>())); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("flag");
            if (routine == null) routine = StartCoroutine(Efect(other.gameObject.GetComponent<Personaje>()));
        }
    }
    IEnumerator Efect(Personaje p)
    {
        p.jumpForce = 15;
        yield return new WaitForSeconds(5);
        p.jumpForce = 7;
        routine = null;
        yield break;
    }
}
