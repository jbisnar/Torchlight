using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameObject player;

    public static int mothkills = 0;
    public static int ratkills = 0;
    public static int batkills = 0;
    public static int owlkills = 0;
    public static int deerkills = 0;
    public static int wolfkills = 0;
    public static int bearkills = 0;

    public static int currentRit = 1;
    public static int[] ritual1 = new int[5];
    public static int[] ritual2 = new int[6];
    public static int[] ritual3 = new int[7];
    public static int[] ritual4 = new int[8];
    public static int[] ritual5 = new int[9];
    public static int[] ritual6 = new int[9];
    public static int[][] RitualArray = new int[8][] {ritual1, ritual1, ritual2, ritual3, ritual4, ritual5, ritual6, ritual6};

    public static float ARENA_LENGTH = 20f;
    public static float MIN_SPAWNDIST = 8f;

    public GameObject moth;
    public GameObject rat;
    public GameObject bat;
    public GameObject owl;
    public GameObject deer;
    public GameObject wolf;
    public GameObject bear;
    public static GameObject[] anArray;
    public GameObject ritCircle;

    // Start is called before the first frame update
    void Start()
    {
        anArray = new GameObject[] { moth, rat, bat, owl, deer, wolf, bear};

        for (int i = 0; i < 5; i++)
        {
            ritual1[i] = Random.Range(0, 2);
        }

        ritual2[0] = 2;
        for (int i = 1; i < 6; i++)
        {
            ritual2[i] = Random.Range(0, 3);
        }

        ritual3[0] = 3;
        for (int i = 1; i < 7; i++)
        {
            ritual3[i] = Random.Range(0, 4);
        }

        ritual4[0] = 4;
        for (int i = 1; i < 8; i++)
        {
            ritual4[i] = Random.Range(1, 5);
        }

        ritual5[0] = 5;
        for (int i = 1; i < 9; i++)
        {
            ritual5[i] = Random.Range(2, 6);
        }

        ritual6[0] = 6;
        for (int i = 1; i < 9; i++)
        {
            ritual6[i] = Random.Range(3, 7);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        spawnCircles();
        spawnAnimals();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }

    public static void Upgrade(int upgradetype)
    {
        currentRit++;

        if (upgradetype == 0)
        {
            player.GetComponent<Move_TD>().velWalk += 1;
        } else if (upgradetype == 1)
        {

        }
        else
        {

        }
    }

    public void spawnCircles()
    {
        var spawnx = 0f;
        var spawny = 0f;
        GameObject spawnedRitC;
        for (int i = 0; i < 6; i++)
        {
            while (Vector2.Distance(Vector2.zero, new Vector2(spawnx,spawny)) < MIN_SPAWNDIST)
            {
                spawnx = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
                spawny = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
            }
            spawnedRitC = GameObject.Instantiate(ritCircle, new Vector3(spawnx, spawny, 1), transform.rotation);
            spawnedRitC.transform.parent = null;
            spawnedRitC.GetComponent<RitualCircle>().upgradetype = i/2;
            spawnedRitC.GetComponent<RitualCircle>().GSReference = gameObject;
            spawnx = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
            spawny = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
        }
    }

    public void spawnAnimals()
    {
        if (currentRit > 6)
        {
            return;
        }
        var spawnx = 0f;
        var spawny = 0f;
        GameObject spawnedAnim;
        for (int i = 0; i < RitualArray[currentRit].Length; i++)
        {
            while (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(spawnx, spawny)) < MIN_SPAWNDIST)
            {
                spawnx = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
                spawny = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
            }
            spawnedAnim = GameObject.Instantiate(anArray[RitualArray[currentRit][i]], new Vector3(spawnx, spawny, 0), transform.rotation);
            spawnedAnim.transform.parent = null;
            spawnx = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
            spawny = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
        }
        for (int i = 0; i < currentRit+1; i++)
        {
            while (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(spawnx, spawny)) < MIN_SPAWNDIST)
            {
                spawnx = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
                spawny = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
            }
            spawnedAnim = GameObject.Instantiate(anArray[i], new Vector3(spawnx, spawny, 0), transform.rotation);
            spawnedAnim.transform.parent = null;
            spawnx = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
            spawny = Random.Range(-ARENA_LENGTH, ARENA_LENGTH);
        }
        Debug.Log("From GameState: " + GameState.mothkills + ", " + GameState.ratkills + ", " + GameState.batkills + ", " + GameState.owlkills + ", " + GameState.deerkills + ", " + GameState.wolfkills + ", " + GameState.bearkills);
    }
}
