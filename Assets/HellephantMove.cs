using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellephantMove : MonoBehaviour 
{
    private Transform m_transform;
    public float speed = 1f;
    public float rotateSpeed_AxisY = 5f;

	// Use this for initialization
	void Start () 
    {
        m_transform = this.transform;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_transform.Translate(new Vector3(0, 0, speed  * Time.deltaTime));
		
	}
}
