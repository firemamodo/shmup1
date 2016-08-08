using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float vertSpeed;
    public float horzSpeed;
    float speedMultiplier=25;
   // public Vector3 moveV3 = new Vector3(0, 0, 0);

    private 
	// Use this for initialization
	void Start () {




    }
	
	// Update is called once per frame
	void FixedUpdate () {

        vertSpeed =  Input.GetAxis("vertical_LS");
        horzSpeed = Input.GetAxis("horizontal_LS");

        Debug.Log("Vert speed is " + vertSpeed + " Horz speed is " + horzSpeed);

        transform.Translate( new Vector3(-horzSpeed, 0, vertSpeed) * speedMultiplier* Time.deltaTime);
    }
}
