using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public float vertSpeed;
    public float horzSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        vertSpeed=  Input.GetAxis("verticalLS");
        horzSpeed = Input.GetAxis("horizontalLS");

    }
}
