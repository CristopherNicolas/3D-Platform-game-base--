using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Meta : MonoBehaviour
{
    
    private async void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //desactivar movimiento
            GameObject.FindObjectOfType<Personaje>().moveSpeed = 0;
            // mostrar mensaje ganaste
            var uIPlayer = GameObject.Find("EndGameUI");
            uIPlayer.GetComponent<UIDocument>().enabled = true ;
                        
            await Task.Delay(3000);
            //cerrar juego
            Application.Quit();
        }
    }
    
}
