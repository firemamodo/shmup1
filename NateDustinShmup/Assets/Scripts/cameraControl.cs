using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class cameraControl : MonoBehaviour {


    public float vertSpeed;
    public float horzSpeed;
    float speedMultiplier = 25;
    float keyboardSpeed;
    float maxSpeed=25;

    // public Vector3 moveV3 = new Vector3(0, 0, 0);

    bool gamePad;
    bool keys;

    GameObject UImenu;


    public GameObject projectile;

    public Toggle kboardToggle;
    public Toggle controllerToggle;

    private bool isShowing = false;



    public float camDist;
    public float adjust1;
    public float adjust2;
    public float adjust3;
    bool resetCam=false;

    private GameObject playerCam;
    private GameObject camTarget;
    GameObject player;
    // Use this for initialization
    void Start () {

        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        camTarget = GameObject.FindGameObjectWithTag("CamTarget");
        player = GameObject.FindGameObjectWithTag("Player");


        UImenu = GameObject.FindGameObjectWithTag("MainCanvas");
        UImenu.SetActive(isShowing);

    }

    float distanceTwoPoints(Vector3 V1, Vector3 V2)
    {
        return (Vector3.Distance(V1, V2));
    }
	// Update is called once per frame
	void FixedUpdate () {

        //playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, camTarget.transform.position, 0.1f);



        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            UImenu.SetActive(isShowing);
        }

        if (kboardToggle.isOn == true)
        {



            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-maxSpeed, 0, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, 270);
                Debug.Log("A was pushed");
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(maxSpeed, 0, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, -270);
                Debug.Log("D was pushed");
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, maxSpeed, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, -180);
                Debug.Log("W was pushed");
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -maxSpeed, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, -0);
                Debug.Log("S was pushed");
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {

                Debug.Log("Space!");
                Instantiate(projectile, player.transform.position, player.transform.localRotation);
            }

        }

        else if (controllerToggle.isOn == true)
        {

            vertSpeed = Input.GetAxis("vertical_LS");
            horzSpeed = Input.GetAxis("horizontal_LS");

            Debug.Log("Vert speed is " + vertSpeed + " Horz speed is " + horzSpeed);

            transform.Translate(new Vector3(-horzSpeed, 0, vertSpeed) * speedMultiplier * Time.deltaTime);
        }

    }
}
