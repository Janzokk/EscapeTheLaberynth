using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {

    new Rigidbody rigidbody;
    new Camera camera;
    public bool wasd;

    int jumps = 1;
    [SerializeField] float speed = 3f, jumpForce = 500;


    public CharacterController controller;
    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update() {

        if(wasd){
            keyMove();
        }else{
            camMove();
        }
        
    }

    public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }
    void keyMove(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        
        controller.Move(move * speed * Time.deltaTime);
    }

    void camMove(){
        Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
        transform.position += velocity * Time.deltaTime;

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }
    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    } 
}
