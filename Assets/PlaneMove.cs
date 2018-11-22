using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class PlaneMove : MonoBehaviour
{
    private Transform m_transform;                      //保存Transform实例
    public float speed = 10f;                           //飞机的飞行速度
    private float rotationx = 0.0f;                     //绕x轴的旋转量
    public float rotateSpeed_AxisX = 5f;                //绕x轴的旋转速度
    private float rotationz = 0.0f;                     //绕z轴的旋转量
    public float rotateSpeed_AxisZ = 45f;               //绕z轴的旋转速度
    private float rotationy = 0.0f;                     //绕y轴的旋转量
    public float rotateSpeed_AxisY = 20f;               //绕y轴的旋转速度

    // Use this for initialization
    void Start()
    {
        m_transform = this.transform;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;                              //关闭重力效果
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");            //通过AD键控制左右移动
        float v = Input.GetAxis("Vertical");              //通过WS键控制上下移动
        m_transform.Translate(new Vector3(h / 4, v / 3, speed * 3 * Time.deltaTime));                          //移动
        GameObject.Find("propeller").transform.Rotate(new Vector3(0, 1000f * 10 * Time.deltaTime, 0));       //寻找到名称为“propellor”的对象使其绕Y轴旋转
        GameObject.Find("propeller").transform.Rotate(new Vector3(0, 100f, 0));                              // 获取飞机对象绕X轴的旋转量
        rotationz = this.transform.eulerAngles.z;
        if (h < 0)           //如果按下A键
        {
            if ((rotationz <= 45 || rotationz >= 315))
            {
                m_transform.Rotate(new Vector3(0, 0, (Time.deltaTime * rotateSpeed_AxisZ) / 2), Space.Self);     //飞机向左倾斜
            }
            m_transform.Rotate(new Vector3(0, -Time.deltaTime * 20, 0), Space.World);         //飞机左转
        }
        else if (h > 0)           //如果按下D键
        {
            if ((rotationz <= 45 || rotationz >= 315))
            {
                m_transform.Rotate(new Vector3(0, 0, (-Time.deltaTime * rotateSpeed_AxisZ) / 2), Space.Self);    //飞机向右倾斜
            }
            m_transform.Rotate(new Vector3(0, Time.deltaTime * 20, 0), Space.World);          //飞机右转
        }
        else
        {
            BackToBlance();            //如果没有AD键，调用恢复平衡方法
        }
        if ((rotationy >= 0 && rotationy <= 90) || (rotationy >= -90 && rotationy <= 0))
        {
            if (v < 0)           //如果按下W键
            {
                m_transform.Rotate(new Vector3(Time.deltaTime * 30, 0, 0), Space.World);         //飞机上转
                m_transform.Rotate(new Vector3((Time.deltaTime * 3 * rotateSpeed_AxisX), 0, 0), Space.Self);     //飞机向上倾斜
            }
            else if (v > 0)           //如果按下S键
            {
                m_transform.Rotate(new Vector3(-Time.deltaTime * 30, 0, 0), Space.World);         //飞机下转
                m_transform.Rotate(new Vector3((-Time.deltaTime * 3 * rotateSpeed_AxisX), 0, 0), Space.Self);     //飞机向下倾斜
            }
        }
        else if((rotationy>90&&rotationy<=180)||(rotationy>=-180&&rotationy<-90))
        {
            if (v < 0)           //如果按下W键
            {
                //m_transform.Rotate(new Vector3(-Time.deltaTime * 30, 0, 0), Space.World);         //飞机下转
                m_transform.Rotate(new Vector3((-Time.deltaTime * 3 * rotateSpeed_AxisX), 0, 0), Space.Self);     //飞机向下倾斜
            }
            else if (v > 0)           //如果按下S键
            {
                //m_transform.Rotate(new Vector3(Time.deltaTime * 30, 0, 0), Space.World);         //飞机上转
                m_transform.Rotate(new Vector3((Time.deltaTime * 3 * rotateSpeed_AxisX), 0, 0), Space.Self);     //飞机向上倾斜
            }
        }
        else if (v == 0)
        {
            BackToBlance();            //如果没有WS键，调用恢复平衡方法
        }

    }
    void BackToBlance()                //恢复平衡方法
    {
        if ((rotationz <= 180))        //判断如果飞机为右倾状态
        {
            if (rotationz - 0 <= 2)
            {
                m_transform.Rotate(0, 0, Time.deltaTime * -1);       //在阈值内轻微晃动
            }
            else
            {
                m_transform.Rotate(0, 0, Time.deltaTime * -25);      //快速恢复平衡状态
            }
        }

        if ((rotationz > 180))         //判断如果飞机为左倾状态
        {
            if (360 - rotationz <= 2)
            {
                m_transform.Rotate(0, 0, Time.deltaTime * 1);        //在阈值内轻微晃动
            }
            else
            {
                m_transform.Rotate(0, 0, Time.deltaTime * 25);       //快速恢复平衡状态
            }
        }
        if ((rotationx < 0))
        {
            m_transform.Rotate(Time.deltaTime * 15, 0, 0);
        }
        if ((rotationx > 0))
        {
            m_transform.Rotate(Time.deltaTime * 15, 0, 0);
        }
    }
}

