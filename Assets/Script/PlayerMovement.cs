using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    CharacterController characterController;
    Animator anim;
    [SerializeField] private float playerMoveSpeed;
    //ScoreBoard scoreboard;
    [SerializeField] private float turnSpeed;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        //  scoreboard = GameObject.Find("ScoreDisplay").GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var playerMovement = new Vector3(horizontalMovement, 0, verticalMovement);
        anim.SetFloat("Speed", verticalMovement);
        transform.Rotate(Vector3.up, horizontalMovement * Time.deltaTime * turnSpeed);

        if (verticalMovement != 0)
        {
            characterController.SimpleMove(transform.forward * Time.deltaTime * playerMoveSpeed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            Debug.Log(gameObject.name);
            Debug.Log(collision.gameObject.name);

        }
    }
}
