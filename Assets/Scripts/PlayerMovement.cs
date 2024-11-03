using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    public Camera cam;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
        cc.Move(((transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"))) * Time.fixedDeltaTime * speed);
        cc.Move(new Vector3(0, -2, 0) * Time.fixedDeltaTime);

        cam.transform.eulerAngles += new Vector3(Input.GetAxisRaw("Mouse Y") * -1, Input.GetAxisRaw("Mouse X"), 0);
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        if(cam.transform.eulerAngles.x > 80f && cam.transform.eulerAngles.x < 260)
        {
            cam.transform.eulerAngles = new Vector3(80, cam.transform.eulerAngles.y, 0);
        }
        else if(cam.transform.eulerAngles.x < -80f)
        {
            cam.transform.eulerAngles = new Vector3(-80, cam.transform.eulerAngles.y, 0);
        }
    }
}
