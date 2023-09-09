using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Personaje : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = 9.81f;

    private CharacterController characterController;
    public Vector3 moveDirection, ultimoCheckpoint;
    public Animator animator;
    [SerializeField] GameObject prefabHabilidad;
    public float cooldown;
    [SerializeField] AudioSource playerSource;

    public virtual async void  Habilidad()
    {
        if (cooldown > 0) return;
        float initialSpeed = moveSpeed;
        cooldown = 7;
        moveSpeed = initialSpeed / 3;
        await Task.Delay(600    );
        moveSpeed = initialSpeed ;
        animator.SetTrigger("Habilidad");
         Instantiate(prefabHabilidad,transform.position,Quaternion.identity);
    }

    private IEnumerator Start()
    {
        moveSpeed = 0;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (cooldown == 0) continue; 
            cooldown--;
            // asignar texto
        }
    }

    private void Update()
    {
        if (transform.position.y < -10) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.E)) Habilidad();
        // Obtener la entrada de movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput >= 0) transform.localScale = Vector3.one;
        else transform.localScale = new Vector3(1, 1, -1);


        // Calcular la dirección de movimiento en función de la entrada del jugador
        Vector3 move = transform.TransformDirection(new Vector3(0,0, horizontalInput));
        moveDirection.x = move.x * moveSpeed;
        moveDirection.z = move.z * moveSpeed;

        // Aplicar la gravedad
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Mover al personaje
        characterController.Move(moveDirection * Time.deltaTime);

        // Saltar
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
            animator.SetTrigger("jump");
        }
        if (horizontalInput != 0) { animator.SetBool("isRuning", true); 
            if(!playerSource.isPlaying && characterController.isGrounded)playerSource.Play(); }
             else { animator.SetBool("isRuning", false); playerSource.Stop(); }
        if (characterController.isGrounded == false) playerSource.Stop();
            
    }
}
