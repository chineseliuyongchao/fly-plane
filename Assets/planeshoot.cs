using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planeshoot : MonoBehaviour
{
    private Light light;
    public float attack=100;//伤害
    public float shootRate = 5;//每秒射击几次
    private float timer = 0;//计时器
    private LineRenderer lineRenderer;
    public AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            if (timer > 1 / shootRate)//判断是否达到计时周期
            {
                timer -= 1 / shootRate;
                Shoot();//开火
            }
        } 
    }
    void Shoot()
    {
        light.enabled = true;
        this.lineRenderer.enabled = true;//开启弹痕组件
        lineRenderer.SetPosition(0, transform.position);//弹痕组件起点在枪口
        audioSource.Play();
        Ray ray = new Ray(transform.position, transform.forward);//构造射线
        RaycastHit hitInfo;//存储碰撞信息
        if (Physics.Raycast(ray, out hitInfo))//碰撞检测
        {
            lineRenderer.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.tag == Tags.hellephant)//判断当前有没有碰撞到敌人
            {
                hitInfo.collider.GetComponent<HellephantHealth>().TakeDamage(attack);
            }
            if (hitInfo.collider.tag == Tags.solider)//判断当前有没有碰撞到敌人
            {
                hitInfo.collider.GetComponent<SoliderMove>().TakeDamage(attack);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 300);
        }
        Invoke("ClearEffect", 0.02f);//火光闪烁0.02秒
    }
    void ClearEffect()
    {
        light.enabled = false;
        lineRenderer.enabled = false;
    }
}