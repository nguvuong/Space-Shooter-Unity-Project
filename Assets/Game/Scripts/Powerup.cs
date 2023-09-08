using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    [SerializeField]
    private int powerupId; // 0 = triple shot, 1 = speed boost, 2 = shields


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
                if (powerupId == 0)
                {
                    // enable triple shoot 
                    player.TripleShotPowerupOn();

                }
                else if (powerupId == 1)
                {

                    // enable speed boost here
                    // increase the speed and wait for 5 seconds 
                    player.SpeedPowerupOn();

                }
                else if (powerupId == 2)
                {
                    // enable shields 
                }


            }



            // destroy ourself 
            Destroy(this.gameObject);


        }

    }


}
