using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgentXp : MonoBehaviour
{
    public int xp = 0;
    public int xpToLevelUp = 10;
    public int level = 1;
    public Image xpBarFill;
    public TextMeshProUGUI levelText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            xp += collision.gameObject.GetComponent<Orb>().xpValue;
            xpBarFill.fillAmount = (float)xp / xpToLevelUp;

            if (xp >= xpToLevelUp)
            {
                level++;
                xp = 0;
                xpToLevelUp += 5; // Increase the XP threshold for each level
            }

            Destroy(collision.gameObject);
            //Debug.Log(xp);
        }
    }

    private void Update()
    {
        levelText.text = "Level:" + level.ToString();
    }
}
