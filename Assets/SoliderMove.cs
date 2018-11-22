using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMove : MonoBehaviour 
{
    private Transform m_transform;
    public float rotateSpeed_AxisY = 5f;
    public float hp = 200;
    private SoliderMove idle;
    private Animator anim;
    private CapsuleCollider capsuleCollider;
	// Use this for initialization
	void Start () 
    {
        m_transform = this.transform;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_transform.Rotate(new Vector3(0, 10f * 10 * Time.deltaTime, 0));
        if (this.hp <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);//控制下降
            if (transform.position.y <= -20)//判断高度
                Destroy(this.gameObject);//销毁士兵
        }
	}
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        idle = this.GetComponent<SoliderMove>();
        capsuleCollider = this.GetComponent<CapsuleCollider>();
    }
    public void TakeDamage(float damage)
    {
        if (this.hp <= 0) return;
        this.hp -= damage;
        if (this.hp <= 0)
        {
            Dead();
        }
    }
    void Dead()//用这个方法处理敌人的后事
    {
        anim.SetBool("Death", true);
        idle.enabled = false;
        capsuleCollider.enabled = false;
    }
}
