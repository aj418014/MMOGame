using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
            RightClickMovement();
        else
            NoRightClickMovement();
    }
    void NoRightClickMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate( transform.forward* speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-this.transform.up * rotateSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-this.transform.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(this.transform.up * rotateSpeed * Time.deltaTime, Space.World);
        }

    }
    void RightClickMovement()
    {
        Vector3 previousAngle = Camera.main.transform.localPosition;
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        Camera.main.GetComponent<CameraController>().ResetCamera();
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-this.transform.right * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-this.transform.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(this.transform.right * speed * Time.deltaTime, Space.World);
        }
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }
}
