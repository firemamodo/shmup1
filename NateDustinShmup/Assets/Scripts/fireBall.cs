using UnityEngine;
using System.Collections;

public class fireBall : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3);
    }
	
    void FixedUpdate()
    {

        transform.Translate(new Vector3(0,-50,0) * Time.deltaTime);

    }
}
