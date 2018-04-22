using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private float rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotation = 0;
    }

    private void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float spin = Input.GetAxis("Turn");
        
        //might not be possible to do them together
        //look at the values of the move variables and use an if else

        //Vector3 movement = new Vector3(
        //    Mathf.Sin(rotation) * moveVertical + Mathf.Cos(180 - rotation) * moveHorizontal,
        //    0.0f, 
        //    Mathf.Cos(rotation) * moveVertical + Mathf.Sin(180 - rotation) * moveHorizontal
        //);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.velocity = movement * speed;

        rb.AddRelativeForce(movement * speed);

        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );
        rotation += spin;
        rb.rotation = Quaternion.Euler(0.0f, rotation, 0.0f/*rb.velocity.x * -tilt*/);
    }
}
