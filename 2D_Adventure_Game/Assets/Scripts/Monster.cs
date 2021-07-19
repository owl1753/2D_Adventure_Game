using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    SpriteRenderer sp;
    Collider2D[] cds;
    Player player;
    Canvas healthBar;

    public float maxHp;
    public float curHp;
    public float revivingTime;
    public bool isDead;
    public int exp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        cds = GetComponents<Collider2D>();
        player = FindObjectOfType<Player>();
        healthBar = GetComponentInChildren<Canvas>();
        curHp = maxHp;    
    }

    void Update()
    {
        if (curHp <= 0 && !isDead)
        {
            player.exp += exp;
            StartCoroutine(FadeAway());
            isDead = true;
        }
        healthBar.GetComponentsInChildren<Image>()[1].fillAmount = curHp / maxHp;
    }

    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.CompareTag("Fire"))
        {
            curHp -= player.damage;
        }
    }

    IEnumerator FadeAway()
    {
        foreach(Collider2D cd in cds)
        {
            cd.enabled = false;
        }
        healthBar.enabled = false;

        while (sp.color.a > 0)
        {
            var color = sp.color;
            color.a -= (.5f * Time.deltaTime);

            sp.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(revivingTime);
        isDead = false;
        curHp = maxHp;
        foreach (Collider2D cd in cds)
        {
            cd.enabled = true;
        }
        healthBar.enabled = true;
        sp.color = Color.white;
    }
}
