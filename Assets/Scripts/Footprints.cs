using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public int type = 0;
    public GameObject left;
    public GameObject right;
    float fadetime = 15;
    float spawntime = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawntime = Time.time;
        if (type == 0)
        {
            right.SetActive(false);
        } else
        {
            left.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        left.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, (Time.time - spawntime) / fadetime);
        right.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, (Time.time - spawntime) / fadetime);
        if ((Time.time-spawntime) > fadetime)
        {
            Destroy(gameObject);
        }
    }
}
