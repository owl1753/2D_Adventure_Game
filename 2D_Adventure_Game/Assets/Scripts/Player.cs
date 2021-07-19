using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gm;
    AudioManager ad;
    Rigidbody2D rb;
    Animator anim;
    public float moveSpeed;
    public float jumpSpeed;
    public float drag;
    public float damage;
    public bool isGround;
    public bool isAttack;
    public bool canAttack;
    float moveInput;
    float jumpInput;
    public int level = 1;
    public int exp = 0;
    public int maxExp = 1000;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ad = FindObjectOfType<AudioManager>();
    }

    void FixedUpdate()
    {
        #region Move
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * moveSpeed * moveInput);
        if (moveInput != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, drag), rb.velocity.y);
        }
        #endregion
    }

    void Update()
    {
        #region Jump
        jumpInput = Input.GetAxisRaw("Vertical");
        if (isGround && jumpInput != 0)
        {
            rb.AddForce(Vector2.up * jumpSpeed * jumpInput);
            isGround = false;
            anim.SetBool("isJump", true);
        }
        #endregion

        #region Attack
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            isAttack = true;
            canAttack = false;
            ad.PlayOneShot("AttackSound");
            StartCoroutine(AttackDelay());
            anim.SetBool("isAttack", true);
        }
        else
        {
            isAttack = false;
            anim.SetBool("isAttack", false);
        }
        #endregion

        #region Level
        while (exp >= maxExp)
        {
            level++;
            exp -= maxExp;
            if (1 <= level && level <= 10)
            {
                maxExp += 1000;
            }
            else if (10 <= level && level <= 30)
            {
                maxExp += 10000;
            }
            else
            {
                maxExp += 100000;
            }
            damage += 50;
        }
        #endregion
    }

    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("isJump", false);
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
