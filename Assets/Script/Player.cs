using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	private bool isJumpPressed = false;
    public bool isRotatePressed = false;
	public float jumbSpeed = 10.0f;
    bool isgrounded = true;
    AudioSource audioData;
    bool standing = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
        int random = Random.Range(0, 6);
        Debug.Log(random);
        this.gameObject.transform.GetChild(random).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        isJumpPressed = Input.GetKeyDown(KeyCode.Space);
        if(!isRotatePressed) {
            isRotatePressed = Input.GetKeyDown(KeyCode.C);
        }
        else {
            if(Input.GetKeyUp(KeyCode.C)) {
                isRotatePressed = false;
            }
        }
        if (isJumpPressed)
        {
            JumpPressed();
        }
        if (isRotatePressed) {
            Rotate();
        }
        else {
            Stand();
        }
    }
    void FixedUpdate()
    {
        
    }
    public void JumpPressed() {
        if(isgrounded) {
            rb.velocity = new Vector3(0, jumbSpeed, 0);
            audioData.Play(0);
        }
    }

    public void Rotate() {
        if(standing) {
            Debug.Log("rotate");
            isRotatePressed = true;
            transform.rotation = Quaternion.Euler(Vector3.forward * 90);
            transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
            standing = false;
        }
    }
    void Stand() {
        if(!standing) {
            Debug.Log("stand");
            transform.rotation = Quaternion.Euler(Vector3.forward * 0);
            standing = true;
        }
    }
  
     //make sure u replace "floor" with your gameobject name.on which player is standing
     void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Floor")
         {
             isgrounded = true;
         }
     }
     
     //consider when character is jumping .. it will exit collision.
     void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.tag == "Floor")
         {
             isgrounded = false;
         }
     }
}
