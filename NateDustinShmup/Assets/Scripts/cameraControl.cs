using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public  class  cameraControl : MonoBehaviour {

    public enum playerOrientation { Front, Back, Left, Right };
    public static playerOrientation playeDirection = playerOrientation.Front;
    public float vertSpeed;
    public float horzSpeed;
    float speedMultiplier = 25;
    float keyboardSpeed;
    float maxSpeed=25;

    bool gamePad;
    bool keys;


    GameObject UImenu;
    private bool optionsShowing = false;

    public Toggle kboardToggle;
    public Toggle controllerToggle;
    public Text ammoText;

    public GameObject projectile;
    int ammoLeft=25;


    bool resetCam = false;
    private GameObject playerCam;
    private GameObject camTarget;
    GameObject player;



    public float camDist;
    public float adjust1;
    public float adjust2;
    public float adjust3;
    

    void Start () {

        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        camTarget = GameObject.FindGameObjectWithTag("CamTarget");
        player = GameObject.FindGameObjectWithTag("Player");


        UImenu = GameObject.FindGameObjectWithTag("MainCanvas");
        UImenu.SetActive(optionsShowing);

        ammoText.text = ammoLeft.ToString();
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
            optionsShowing = !optionsShowing;
            UImenu.SetActive(optionsShowing);
        }

        if (kboardToggle.isOn == true)
        {



            if (Input.GetKey(KeyCode.A))
            {
                playeDirection = playerOrientation.Left;
                transform.Translate(new Vector3(-maxSpeed, 0, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, 270);
                Debug.Log("A was pushed");
            }

            if (Input.GetKey(KeyCode.D))
            {
                playeDirection = playerOrientation.Right;
                transform.Translate(new Vector3(maxSpeed, 0, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, -270);
                Debug.Log("D was pushed");
            }

            if (Input.GetKey(KeyCode.W))
            {
                playeDirection = playerOrientation.Front;
                transform.Translate(new Vector3(0, maxSpeed, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, 360);
                Debug.Log("W was pushed");
            }

            if (Input.GetKey(KeyCode.S))
            {
                playeDirection = playerOrientation.Back;
                transform.Translate(new Vector3(0, -maxSpeed, 0) * Time.deltaTime);
                player.transform.rotation = Quaternion.Euler(0, 0, -180);
                Debug.Log("S was pushed");
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (ammoLeft > 0)
                {
                    ammoLeft--;
                    ammoText.text = ammoLeft.ToString();
                    switch (playeDirection)
                    {
                        case playerOrientation.Front:
                            Instantiate(projectile, player.transform.position, player.transform.localRotation);
                            break;

                        case playerOrientation.Back:
                            Instantiate(projectile, player.transform.position, player.transform.localRotation);
                            break;

                        case playerOrientation.Left:
                            Instantiate(projectile, player.transform.position, player.transform.localRotation);
                            break;

                        case playerOrientation.Right:
                            Instantiate(projectile, player.transform.position, player.transform.localRotation);
                            break;
                    }
                    Debug.Log("Space!");
                }
                
                
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
