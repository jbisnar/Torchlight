using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_TD : MonoBehaviour
{
    Rigidbody2D rb;
    public float velWalk = 2f;
    int curFoot = 0;
    float stepRate = .4f;
    float timeTillStep = 0f;
    public GameObject footprints;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var temp = rb.velocity;
        temp = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        temp = temp.normalized;
        temp = temp * velWalk;
        rb.velocity = temp;

        if (temp.magnitude > 0)
        {
            timeTillStep += Time.deltaTime;
        }
        if (timeTillStep > stepRate)
        {
            GameObject myPrints = GameObject.Instantiate(footprints, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg-90));
            myPrints.transform.parent = null;
            myPrints.GetComponent<Footprints>().type = curFoot;
            curFoot = 1 - curFoot;
            timeTillStep = 0;
        }
    }
}
