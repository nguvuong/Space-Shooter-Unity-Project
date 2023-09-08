using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        // access the player 
        // turn the trible shot bool to true
        // destroy our selves 

        // 2 parts for scripting communication 
        // handle to the component
        // access the components 


        if (other.tag == "Player")
        {
            // access the player
            Player player = other.GetComponent<Player>();


            // handle exception 

            if (player != null)
            {
                // enable triple shoot 
                player.TripleShotPowerupOn();
            }



            // destroy ourself 
            Destroy(this.gameObject);


        }

    }


}
