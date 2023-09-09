using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personaje>().ultimoCheckpoint = other.transform.position;
            print(other.transform.position);
            Destroy(gameObject);
        }
    }
}
