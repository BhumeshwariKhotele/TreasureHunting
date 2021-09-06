using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    private CharacterController character;
    [SerializeField]
    private float playerspeed = 5;
    private float gravity = 9.8f;
 
    public static PlayerMovement instance;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    { 
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Movement();

        //raycast from the centre of main camera


    }

 

    private void Movement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * playerspeed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        character.Move(velocity * Time.deltaTime);
    }
  
}
