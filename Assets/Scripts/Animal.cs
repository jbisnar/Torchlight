using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public int health = 1;
    public int animType = 0;
    public float damage = 4;
    public float hitTime = 0;
    float invTime = .2f;
    Vector3 prevPos;
    public ParticleSystem footprints;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var main = footprints.main;
        main.startRotation = Vector3.Angle(Vector3.down, transform.position-prevPos);
        prevPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touching player");
            collision.GetComponent<PlayerCombat>().Attack(damage);
            /*
            Debug.Log("Ow I got hit by fire");
            health -= 1;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                //Destroy(gameObject);
            }
            */
        }
        if (collision.gameObject.CompareTag("Projectile") && Time.time > hitTime + invTime)
        {
            hitTime = Time.time;
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                switch (animType)
                {
                    case 0:
                        GameState.mothkills++;
                        break;
                    case 1:
                        GameState.ratkills++;
                        break;
                    case 2:
                        GameState.batkills++;
                        break;
                    case 3:
                        GameState.owlkills++;
                        break;
                    case 4:
                        GameState.deerkills++;
                        break;
                    case 5:
                        GameState.wolfkills++;
                        break;
                    case 6:
                        GameState.bearkills++;
                        break;
                    default:
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
