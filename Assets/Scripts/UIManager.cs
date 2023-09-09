using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDocument document;
    Button seleccionarIzquierda,seleccionarDerecha;
    [SerializeField] GameObject personaje1, personaje2;
    private void Awake()
    {
        seleccionarIzquierda = document.rootVisualElement.Q<Button>("personaje1");
        seleccionarDerecha = document.rootVisualElement.Q<Button>("personaje2");
        seleccionarIzquierda.clicked += () => SeleccionarPersonaje(true);
        seleccionarDerecha.clicked += () => SeleccionarPersonaje(false);
        
    }
    async void SeleccionarPersonaje(bool izquierda)
    {
        // instanciar personaje
        var p = Instantiate(izquierda? personaje1: personaje2);
        // Destruir ui
        document.rootVisualElement.Clear();

        document.rootVisualElement.Add(new Label() { name = "timer" });
        var timer = document.rootVisualElement.Q<Label>("timer");
        timer.style.fontSize = new StyleLength(80);
        //timer.style.alignSelf = Align.Center;
        timer.style.unityTextAlign = new StyleEnum<TextAnchor>() { value = TextAnchor.MiddleCenter};
        var cam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        cam.Follow = p.transform;
        cam.LookAt = p.transform;
        GameObject.FindObjectOfType<UIPlayer>().Setup();

        int t = 3;
        while (t>0)
        {
            timer.text = t.ToString();
             await Task.Delay(1000);
                t--;
        }
        document.rootVisualElement.Remove(timer);
        p.GetComponent<Personaje>().moveSpeed = 5;
        Destroy(gameObject);
    }
}
