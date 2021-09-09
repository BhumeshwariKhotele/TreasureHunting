using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    CharacterController characterController;
    Animator anim;
    [SerializeField] private float playerMoveSpeed;
    //ScoreBoard scoreboard;
    [SerializeField] private float turnSpeed;
    public Text checkPointText;
    [SerializeField] Transform cameraPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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
        playerMovement += Physics.gravity;
        anim.SetFloat("Speed", verticalMovement);
        transform.Rotate(Vector3.up, horizontalMovement * Time.deltaTime * turnSpeed);
        if (verticalMovement != 0)
        {
            characterController.SimpleMove(transform.forward * Time.deltaTime * playerMoveSpeed);
        }

        if (Input.GetMouseButtonDown(0))
        {
             FireGun();
        }
    }

    void FireGun()
    {
        Debug.DrawRay(cameraPoint.position, cameraPoint.transform.forward * 200f, Color.red, 2f);
        RaycastHit hit;
        if (Physics.Raycast(cameraPoint.position, cameraPoint.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {

                var enemyHealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.EnemyDamage(1);
                }
               
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            checkPointText.text = "Go Straight";
            Destroy(other.gameObject);

        }

         if(other.gameObject.tag=="Fuel")
        {
            Debug.Log(other.gameObject.name);
            checkPointText.text = "Got the fuel";
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Boat")
        {
            Debug.Log(other.gameObject.name);
            checkPointText.text = "Reached Boat";
           
        }
    }
}
