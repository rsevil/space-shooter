using System;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    
    private Rigidbody _rigidbody;
    private float nextFire;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }; 
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rigidbody.velocity = movement * speed;
        
        _rigidbody.position = new Vector3(
            Mathf.Clamp(_rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(_rigidbody.position.z, boundary.zMin, boundary.zMax));

        _rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, _rigidbody.velocity.x * (-tilt));
    }
}

[Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}