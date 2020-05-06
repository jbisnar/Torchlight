using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    bool hasTorch = true;
    public float maxhealth = 100f;
    public float curHealth = 100f;
    public float healrate = 20f;
    public float torchRange = 3f;
    float sightRange = 1.25f;
    public float velThrow = 8f;
    public GameObject torchObj;
    public Camera cam;
    Vector2 mousePos;
    public GameObject mask;
    float hitTime = 0;
    float invTime = .2f;

    public Sprite noTorch;
    public Sprite Torch;

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTorch)
        {
            mask.transform.localScale = new Vector3(torchRange, torchRange, torchRange);
            GetComponent<SpriteRenderer>().sprite = Torch;
        } else
        {
            mask.transform.localScale = new Vector3(sightRange, sightRange, sightRange);
            GetComponent<SpriteRenderer>().sprite = noTorch;
        }

        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
        var aim = mousePos - new Vector2(transform.position.x, transform.position.y);
        aim = aim.normalized;
        if (Input.GetMouseButtonDown(0) && hasTorch)
        {
            hasTorch = false;
            //Debug.Log(mousePos+" - "+ new Vector2(transform.position.x, transform.position.y));
            GameObject spawnedTorch = GameObject.Instantiate(torchObj, transform.position, transform.rotation);
            spawnedTorch.transform.parent = null;
            spawnedTorch.GetComponent<Rigidbody2D>().velocity = aim * velThrow;
            spawnedTorch.GetComponent<Proj_Torch>().litRadius = torchRange;
        }
    }

    public void Attack(float damage)
    {
        if (Time.time > hitTime + invTime)
        {
            hitTime = Time.time;
            curHealth -= damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonfire") && !hasTorch)
        {
            hasTorch = true;
            //Debug.Log("Torch refill");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BonfireLight") && curHealth < maxhealth)
        {
            curHealth += healrate * Time.deltaTime;
            if (curHealth > maxhealth)
            {
                curHealth = maxhealth;
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (hasTorch)
        {
            Gizmos.DrawWireSphere(transform.position,torchRange);
        } else
        {
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
    
}
