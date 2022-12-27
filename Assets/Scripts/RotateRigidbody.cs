using UnityEngine;

public class RotateRigidbody : MonoBehaviour
{
    public Rigidbody rb;
    public float strength = 100;
    public float rotX;
    public float rotY;
    bool rotate;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rotate = true;
            rotX = Input.GetAxis("Mouse X") * strength;
            rotY = Input.GetAxis("Mouse Y") * strength;
        }
        else 
        {
            rotate = false;
        }
    }
    void FixedUpdate()
    {
        if (rotate)
        {
            rb.AddTorque(rotY, -rotX, 0);
        }
    }
}