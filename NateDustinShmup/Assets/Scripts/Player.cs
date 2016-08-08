using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float vertSpeed;
    public float horzSpeed;
    float speedMultiplier=25;
    // public Vector3 moveV3 = new Vector3(0, 0, 0);

    bool gamePad;
    bool keys;
    
    GameObject UImenu;

    public Toggle kboardToggle;
    public Toggle controlllerToggle;

    private bool isShowing=false;


    private 
	// Use this for initialization
	void Start () {

        UImenu= GameObject.FindGameObjectWithTag("MainCanvas");
        UImenu.SetActive(isShowing);


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            UImenu.SetActive(isShowing);
        }

        if (kboardToggle.isOn == true)
        {
    


            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(1, 0, 0) * speedMultiplier * Time.deltaTime);
                Debug.Log("A was pushed");
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(-1, 0, 0) * speedMultiplier * Time.deltaTime);
                Debug.Log("A was pushed");
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, -1) * speedMultiplier * Time.deltaTime);
                Debug.Log("A was pushed");
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, 1) * speedMultiplier * Time.deltaTime);
                Debug.Log("A was pushed");
            }
        }

        else if (controlllerToggle.isOn==true)
        {

            vertSpeed = Input.GetAxis("vertical_LS");
            horzSpeed = Input.GetAxis("horizontal_LS");

            Debug.Log("Vert speed is " + vertSpeed + " Horz speed is " + horzSpeed);

            transform.Translate(new Vector3(-horzSpeed, 0, vertSpeed) * speedMultiplier * Time.deltaTime);
        }




    }
}
