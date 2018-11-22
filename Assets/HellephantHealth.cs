using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantHealth : MonoBehaviour 
{
    private float hp = 5000;
    private Animator anim;
    private HellephantMove move;
    public GameObject WinText;
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        move = this.GetComponent<HellephantMove>();
    }
    public void TakeDamage(float damage)
    {
        if (this.hp <= 0) return;
        this.hp -= damage;
        if (this.hp <= 0)
        {
            Dead();
            WinText.SetActive(true);
        }
    }
    void Dead()//用这个方法处理敌人的后事
    {
        anim.SetBool("Death", true);
        move.enabled = false;
    }
}
