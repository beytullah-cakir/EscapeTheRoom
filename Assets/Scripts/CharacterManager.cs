using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;



public class CharacterManager : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool openDoor;

    public static CharacterManager Instance;

    private Animator anm;

    private bool facingRight = true;

    private Vector2 movement;

    



    private void Awake()=> Instance = this;




    private void Start()
    {
        anm = GetComponent<Animator>();
    }


    void Update()
    {
        Movement();

        
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }

    void Movement()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (movement.x > 0 && !facingRight)
            Flip();
        
        else if (movement.x < 0 && facingRight)
            Flip();
        

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        anm.SetBool("walk", movement.magnitude > 0);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            ExitRoom();
        }
    }


    private void ExitRoom()
    {
        if (openDoor)
        {
            LevelManager.Instance.NextLevel();
        }
    }


}
