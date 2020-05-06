using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCircle : MonoBehaviour
{
    GameObject player;
    public int upgradetype = 0;
    bool activating = false;
    int sacrifices = 5;
    int activated = 0;
    float activationTime;
    float progressTime = .4f;
    int[] tempAnims = new int[7];
    public GameObject bonfire;
    public GameObject GSReference;

    /*
    public Sprite mothsym;
    public Sprite ratsym;
    public Sprite batsym;
    public Sprite owlsym;
    public Sprite deersym;
    public Sprite wolfsym;
    public Sprite bearsym;
    */
    public Sprite[] Sparray;
    public Sprite[] Spupgrade;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = Spupgrade[upgradetype];
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState.currentRit)
        {
            case 1:
                sacrifices = 5;
                break;
            case 2:
                sacrifices = 6;
                break;
            case 3:
                sacrifices = 7;
                break;
            case 4:
                sacrifices = 8;
                break;
            case 5:
                sacrifices = 9;
                break;
            case 6:
                sacrifices = 9;
                break;
            default:
                sacrifices = 5;
                break;
        }

        if (activating)
        {
            for (int i = 0; i < sacrifices; i++)
            {
                var symbolAngle = (90 - (360 / (sacrifices)) * (i));
                transform.GetChild(i).localPosition = new Vector3(Mathf.Cos(symbolAngle*Mathf.Deg2Rad), Mathf.Sin(symbolAngle*Mathf.Deg2Rad), 0);
                var curAnim = GameState.RitualArray[GameState.currentRit][i];
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = Sparray[curAnim];
            }
            if (Time.time > activationTime + (activated+1)*progressTime)
            {
                transform.GetChild(activated).gameObject.SetActive(true);
                if (activated < sacrifices-1)
                {
                    activated++;
                }
            }
            if (tempAnims[0] >= 0 && tempAnims[1] >= 0 && tempAnims[2] >= 0 && tempAnims[3] >= 0 && tempAnims[4] >= 0 && tempAnims[5] >= 0 && tempAnims[6] >= 0)
            {
                if (Time.time > activationTime + (sacrifices + 1) * progressTime)
                {
                    GetComponent<SpriteRenderer>().color = new Color(125f / 255f, 0, 0);
                }
                if (Time.time > activationTime + (sacrifices + 2) * progressTime)
                {
                    transform.GetChild(9).gameObject.GetComponent<SpriteRenderer>().color = new Color(125f / 255f, 0, 0);
                }
                if (Time.time > activationTime + (sacrifices + 3) * progressTime)
                {
                    GameObject newBonfire = GameObject.Instantiate(bonfire, transform.position, transform.rotation);
                    newBonfire.transform.parent = null;
                    GameState.currentRit++;
                    if (upgradetype == 0)
                    {
                        player.GetComponent<Move_TD>().velWalk += 1f;
                    }
                    else if (upgradetype == 1)
                    {
                        player.GetComponent<PlayerCombat>().torchRange += 1f;
                    }
                    else
                    {
                        player.GetComponent<PlayerCombat>().velThrow += 4f;
                    }
                    GameState.mothkills = tempAnims[0];
                    GameState.ratkills = tempAnims[1];
                    GameState.batkills = tempAnims[2];
                    GameState.owlkills = tempAnims[3];
                    GameState.deerkills = tempAnims[4];
                    GameState.wolfkills = tempAnims[5];
                    GameState.bearkills = tempAnims[6];
                    Debug.Log("From RitualCircle: "+ GameState.mothkills+", "+ GameState.ratkills + ", " + GameState.batkills + ", " + GameState.owlkills + ", " + GameState.deerkills + ", " + GameState.wolfkills + ", " + GameState.bearkills);
                    GSReference.GetComponent<GameState>().spawnAnimals();
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activating = true;
            activationTime = Time.time;
            tempAnims[0] = GameState.mothkills;
            tempAnims[1] = GameState.ratkills;
            tempAnims[2] = GameState.batkills;
            tempAnims[3] = GameState.owlkills;
            tempAnims[4] = GameState.deerkills;
            tempAnims[5] = GameState.wolfkills;
            tempAnims[6] = GameState.bearkills;
            for (int i = 0; i < GameState.RitualArray[GameState.currentRit].Length; i++)
            {
                var curAnim = GameState.RitualArray[GameState.currentRit][i];
                tempAnims[curAnim]--;
                if (tempAnims[curAnim] >= 0)
                {
                    transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = new Color(125f/255f, 0, 0);
                } else
                {
                    transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activating = false;
            for (int i = 0; i < 9; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            activated = 0;
        }
    }
}
