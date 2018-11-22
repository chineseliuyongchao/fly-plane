using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellePhantShoot : MonoBehaviour {

	private float attack=1000;
    public float attackTime = 1;
    private float timer;

    void Start()
    {
        timer = attackTime;
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.tag == Tags.airplane)
        {
            timer += Time.deltaTime;
            if (timer >= attackTime)
            {
                timer -= attackTime;
                col.GetComponent<PlaneHealth>().TakeDamage(attack);
            }
        }
	}
}
