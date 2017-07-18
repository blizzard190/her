using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    private PlayerShoot _playerShoot;
    private PlayerMovement _playerMovement;

    public float speed;

    private Rigidbody _rigidbody;
    private Vector3 _inputDirection;

    public float fireRate = 0.5F;
    public float nextFire = 0.0F;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }



    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

         _inputDirection = new Vector3(x, 0f, z);
       //_inputDirection = transform.forward;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction*100);

        if(Physics.Raycast(ray, out hit))
        {
            _playerMovement.LookAt(hit.point);
        }

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            _playerShoot.Shoot();
        }
    }

    void FixedUpdate()
    {
        //_rigidbody.AddForce(_inputDirection * speed);
        var velocity = _inputDirection * speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + velocity);
    }
}

