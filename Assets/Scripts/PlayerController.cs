using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float pSpeed = 8f;
    public float pJump = 7f;
    public float pRot = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        WalkHandler();
    }

    void WalkHandler() {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        float pDist = pSpeed * Time.deltaTime;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(hAxis * pDist, 0f, vAxis * pDist);
        movement = transform.rotation * movement;
        Vector3 currPos = transform.position;
        Vector3 newPos = currPos + movement;
        rb.MovePosition(newPos);
    }

    void Rotation() {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * pRot ,0));
    }
}
