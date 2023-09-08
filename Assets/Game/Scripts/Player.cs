using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _laserPrefab;


    // _fireRate is 0.25f
    // _canFire --has the amount of time between firing passed? 
    // Time.time: how long have the game running 
    [SerializeField]
    private float _fireRate = 0.25f;


    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;
    private void Start()
    {
        //current pos = new position
        // Debug.Log(transform.position);
        transform.position = new Vector3(0, 0, 0);
    }


    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.06f, 0), Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }

        if (transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }

    }
}
