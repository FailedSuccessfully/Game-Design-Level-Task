using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float pSpeed = 8f;
    public float pJump = 7f;
    public float pRot = 4f;
    public float bUp, bDown = 0f;

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
        Debug.Log(string.Format("up: {0} down: {1}", bUp, bDown));
    }

    void WalkHandler() {
        bUp = Input.GetMouseButton(0) ? 1 : 0;
        bDown = Input.GetMouseButton(1) ? 1 : 0;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        float pDist = pSpeed * Time.deltaTime;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hAxis * pDist, (bUp - bDown) / pJump, vAxis * pDist);
        movement = transform.rotation * movement;
        Vector3 currPos = transform.position;
        Vector3 newPos = currPos + movement;
        rb.MovePosition(newPos);
    }

    void Rotation() {
        transform.Rotate(0, Input.GetAxis("Mouse X") * pRot ,0);
    }
}
