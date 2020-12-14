using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirector : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    public float turnSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 4f);
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Rotation();
        transform.position = player.transform.position + offset;
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        transform.LookAt(player.transform.position);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

    void Rotation() {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*turnSpeed, Vector3.up) * offset;
    }
}
