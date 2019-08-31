 using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidBody;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        _rigidBody.velocity = transform.forward * speed;
    }
}
