using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Moth : MonoBehaviour
{
    Vector3 nextpos;
    public float velIdle = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        nextpos = new Vector3(Random.Range(-GameState.ARENA_LENGTH, GameState.ARENA_LENGTH), Random.Range(-GameState.ARENA_LENGTH, GameState.ARENA_LENGTH), 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = Vector3.MoveTowards(transform.position, nextpos, velIdle * Time.deltaTime);
        if (transform.position == nextpos)
        {
            nextpos = new Vector3(Random.Range(-GameState.ARENA_LENGTH, GameState.ARENA_LENGTH), Random.Range(-GameState.ARENA_LENGTH, GameState.ARENA_LENGTH), 0);
        }
    }
}
