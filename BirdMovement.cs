using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    float flapSpeed = 100f; 
    float forwardSpeed = 1f;

    bool didFlap = false;


	// Use this for initialization
	void Start () {
	
	}

    // zmiany graficzne i wyjscowe  
    void Update() {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) {
            didFlap = true;
        }
    }

// zmiany silnika fizyki gry 
    void FixedUpdate () {

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);

        if (didFlap)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            didFlap = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            float angle = Mathf.Lerp(0, -90, GetComponent<Rigidbody2D>().velocity.y / 2f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
