using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move up with 10 _speed 
        transform.Translate(Vector3.up * _speed * Time.deltaTime);


        // if position on the y of my laser is greater than or equal to 5.52
        // destroy the laser

        if (transform.position.y >= 5.52)
        {
            Destroy(this.gameObject);
        }
    }
}
