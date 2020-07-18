using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public float radius;
    int scroll = 5;
    public float b;
    public float a;
    public float c;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.LookAt(focus);
        if (Input.GetMouseButton(0))
        {
            this.transform.RotateAround(focus.position, new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")), 2f);
        }
        if(Input.GetMouseButton(1))
        {
        }
        Scroll();
    }
    void Scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(transform.forward, Space.World);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(-transform.forward, Space.World);
    }
    public void ResetCamera()
    {
        this.transform.localPosition = new Vector3(origin.x, transform.localPosition.y, origin.z);
    }
}
