using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneHealth : MonoBehaviour 
{
    private Transform m_transform;
    public float speed = 10f;
    private Light light;
    public float hp = 1000;
    private Animator anim;
    public Text text;
    public GameObject OverText;
    void Awake()
    {
        m_transform = this.transform;
        light=GetComponent<Light>();
        anim=this.GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        if (this.hp <= 0) return;
        this.hp -= damage;
        text.text = hp.ToString();
        if (this.hp <= 0)
        {
            light.enabled = true;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            m_transform.Translate(new Vector3(0, speed * 3 * Time.deltaTime, 0));
            OverText.SetActive(true);
        }
    }
}
