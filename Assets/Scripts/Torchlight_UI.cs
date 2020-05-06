using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torchlight_UI : MonoBehaviour
{
    public PlayerCombat player;
    public RectTransform healthbar;
    float healthbarWidth;

    public Image mothIcon;
    public Text mothcount;
    public Image ratIcon;
    public Text ratcount;
    public Image batIcon;
    public Text batcount;
    public Image owlIcon;
    public Text owlcount;
    public Image deerIcon;
    public Text deercount;
    public Image wolfIcon;
    public Text wolfcount;
    public Image bearIcon;
    public Text bearcount;

    // Start is called before the first frame update
    void Start()
    {
        healthbarWidth = healthbar.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.sizeDelta = new Vector2((player.curHealth / player.maxhealth) * healthbarWidth,healthbar.sizeDelta.y);

        if (GameState.mothkills > 0 || mothIcon.gameObject.activeInHierarchy)
        {
            mothIcon.gameObject.SetActive(true);
            mothcount.text = GameState.mothkills.ToString();
        }
        if (GameState.ratkills > 0 || ratIcon.gameObject.activeInHierarchy)
        {
            ratIcon.gameObject.SetActive(true);
            ratcount.text = GameState.ratkills.ToString();
        }
        if (GameState.batkills > 0 || batIcon.gameObject.activeInHierarchy)
        {
            batIcon.gameObject.SetActive(true);
            batcount.text = GameState.batkills.ToString();
        }
        if (GameState.owlkills > 0 || owlIcon.gameObject.activeInHierarchy)
        {
            owlIcon.gameObject.SetActive(true);
            owlcount.text = GameState.owlkills.ToString();
        }
        if (GameState.deerkills > 0 || deerIcon.gameObject.activeInHierarchy)
        {
            deerIcon.gameObject.SetActive(true);
            deercount.text = GameState.deerkills.ToString();
        }
        if (GameState.wolfkills > 0 || wolfIcon.gameObject.activeInHierarchy)
        {
            wolfIcon.gameObject.SetActive(true);
            wolfcount.text = GameState.wolfkills.ToString();
        }
        if (GameState.bearkills > 0 || bearIcon.gameObject.activeInHierarchy)
        {
            bearIcon.gameObject.SetActive(true);
            bearcount.text = GameState.bearkills.ToString();
        }
    }
}
