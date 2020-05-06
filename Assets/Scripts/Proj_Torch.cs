using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Torch : MonoBehaviour
{
    public float litRadius = 2.5f;
    float decayRate = 3f;
    public SpriteMask mask;
    public CircleCollider2D lightCol;

    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponentInChildren<SpriteMask>();
        lightCol = GetComponentInChildren<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mask.transform.localScale = new Vector3(litRadius, litRadius, litRadius);
        litRadius -= decayRate * Time.deltaTime;
        if (litRadius < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("Torch hit");
            //collision.gameObject.GetComponent<Animal>().health -= 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, litRadius);
    }
}
