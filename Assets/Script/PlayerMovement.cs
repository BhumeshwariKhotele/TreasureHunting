using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    CharacterController characterController;
    Animator anim;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float turnSpeed;
    public Text checkPointText;
    [SerializeField] Transform cameraPoint;
    int checkPointCount;
    bool fuelCheck = false;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;
    public Image star5;

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
    }


    // Update is called once per frame
    void FixedUpdate()
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
            AudioManager.instance.PlayAudio("Bullet");
            FireGun();
        }
      

    }

    void FireGun()
    {
     

        Debug.DrawRay(cameraPoint.position, cameraPoint.transform.forward * 200f, Color.red, 2f);
        RaycastHit hit;
        if (Physics.Raycast(cameraPoint.position, cameraPoint.transform.forward, out hit))
        {
            HitMarkerManager.hitinstance.instancePoint = hit.point;
            HitMarkerManager.hitinstance.SpawnMarker();

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
        if (other.gameObject.tag == "CheckPoint1")
        {
            checkPointCount++;
            star1.gameObject.SetActive(true);
            checkPointText.text = "Go Straight";
            Destroy(other.gameObject);
           
        }
       else if (other.gameObject.tag == "CheckPoint2")
        {
            checkPointCount++;
            star2.gameObject.SetActive(true);
            checkPointText.text = "Go Straight";
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "CheckPoint3")
        {
            checkPointCount++;
            star4.gameObject.SetActive(true);
            checkPointText.text = "Go Straight";
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "CheckPoint4")
        {
            checkPointCount++;
            star5.gameObject.SetActive(true);
            checkPointText.text = "Go Straight";
            Destroy(other.gameObject);

        }
        else if (other.gameObject.tag == "TurnLeft")
        {
            checkPointCount++;
            star3.gameObject.SetActive(true);
            checkPointText.text = "Take Left";
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag=="TurnRight")
        {
            checkPointCount++;
            star3.gameObject.SetActive(true);
            checkPointText.text = "Take Right";
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Fuel")
        {
            fuelCheck = true;
            checkPointText.text = "Got the fuel\nGo to boat";
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Boat")
        {
            if(checkPointCount==5 && fuelCheck==true)
            {
                checkPointText.text = "Reached Boat";
                SceneManager.LoadScene(3);
            }
        }
        else if(other.gameObject.tag=="Enemy")
        {
            
            PlayerHealth.instance.TakeDamage(1);
        }
    }

    
}
