using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;
    public int lives = 3; 
    public bool shieldsActive = false;
 



    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _ExplosionPrefab;

    [SerializeField]
    private GameObject _shieldGameObject;


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

            if (canTripleShoot)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.06f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0.63f, 0.09f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.63f, 0.09f, 0), Quaternion.identity);


            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.06f, 0), Quaternion.identity);
            }

            _canFire = Time.time + _fireRate;
        }
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive)
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime * 1.5f);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime * 1.5f);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }




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

    public void Damage() 
    {
        // substract 1 life from the player 
        // if lives < 1 (meaning 0)
        // destroy the objects 

        // if player has shields
        // do nothing 


        if (shieldsActive == true) {
            shieldsActive = false;
            _shieldGameObject.SetActive(false); 

            // wanna stop the damage function right now 
            return;
        }

        lives--;
        if (lives < 1) { 
            Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void EnableSheilds() {
        shieldsActive = true;
        _shieldGameObject.SetActive(true); 
    }


    public void TripleShotPowerupOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }



    public bool isSpeedBoostActive = false;

    public void SpeedPowerupOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }
}
