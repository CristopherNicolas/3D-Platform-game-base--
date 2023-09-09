using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIPlayer : MonoBehaviour
{
    Transform playerTransform;
    public UIDocument document;
    ProgressBar progressBar,coolDownHabilidad;
    Personaje personaje;
    public float starPos = 4.45f, endPos = -116;
    private void Awake()
    {
        document = GetComponent<UIDocument>();
            progressBar = document.rootVisualElement.Q<ProgressBar>("progresoMapa");
        coolDownHabilidad = document.rootVisualElement.Q<ProgressBar>("cd");
    }
    public bool canUpdatePos;

    public void Setup()
    {
            progressBar.highValue = Mathf.Abs(endPos);
            progressBar.lowValue = Mathf.Abs(starPos);
            playerTransform = GameObject.FindObjectOfType<Personaje>().transform;
            personaje = playerTransform.GetComponent<Personaje>();  
        canUpdatePos = true;
    }
    private void Update()
    {
        if (canUpdatePos)
        {
            progressBar.value =  Mathf.Abs(playerTransform.position.x);
            coolDownHabilidad.value = personaje.cooldown;
        }
    }
}
