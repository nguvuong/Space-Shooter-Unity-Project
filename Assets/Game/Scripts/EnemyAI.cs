using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExposionPrefab;

    //variable for your speed
    private float _speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // move down 
        transform.Translate(Vector3.down * Time.deltaTime * _speed);


        if (transform.position.y < -7f)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 7f, 0);
        }
        // when offthe sceen on the bottom
        // respawn back on the top with a new x position between the bounds of the sceen 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            // destroy ourself 
            Destroy(this.gameObject);
            Instantiate(_enemyExposionPrefab, transform.position , Quaternion.identity);
            Destroy(other.gameObject);

        }

        if (other.tag == "Player") { 
            Player player = other.GetComponent<Player>();

            // handle exception 
            if (player != null) {
                player.Damage();
            }
            Instantiate(_enemyExposionPrefab, transform.position , Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
