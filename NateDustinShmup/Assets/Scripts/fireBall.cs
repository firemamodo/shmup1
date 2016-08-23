using UnityEngine;
using System.Collections;


public class fireBall : MonoBehaviour {

    int speed = 0;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3);
        switch (cameraControl.playeDirection)
        {
            case cameraControl.playerOrientation.Front:
                speed = 50;
            break;

            case cameraControl.playerOrientation.Back:
                speed = 50;
            break;

            case cameraControl.playerOrientation.Left:
                speed = -50;
                break;

            case cameraControl.playerOrientation.Right:
                speed = -50;
                break;
        }
    
    }

 /*   void OnDestroy()
    {
        print("Script was destroyed");

    }*/
    void FixedUpdate()
    {

        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);

    }
}
