using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float m_Speed;
    public Transform m_Cammera;
    public Transform m_Target;
    float m_Distance;
    public float value;
    public float maxValue;
    Vector3 m_LastMousePostition;
    void Awake() {
        m_Speed = 100.0f;
        m_Distance = 20.0f;
        value = 0;
        maxValue = 0.15f;
    }

    // Use this for initialization
    void Start () {
        m_Cammera.LookAt(m_Target.transform);
	}
	
	// Update is called once per frame
	void Update () {
       
        if (value > 0) {
            value += Time.deltaTime;
        }
        //鼠标 0左键 1右键 2中间
        if (Input.GetMouseButtonDown(1))
        {
            value += 0.01f;
            Debug.Log("1+");
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (value != 0)
            {
                value = 0;
            }
            Debug.Log("1-");
        }
        float temp = Input.GetAxis("Mouse ScrollWheel");
        if (temp != 0)
        {
            m_Cammera.Translate(0, 0, temp * m_Speed * Time.deltaTime);
        }

        if (value > maxValue)
        {
            float tempX = Input.GetAxis("Mouse X") * m_Speed * Time.deltaTime;
            //tempX * m_Speed * Time.deltaTime
            float tempY = Input.GetAxis("Mouse Y") * m_Speed * Time.deltaTime;
            //* tempY * m_Speed * Time.deltaTime
            m_Target.Rotate(0, tempX, 0, Space.World);//迷
            
            m_Target.Rotate(-tempY, 0, 0, Space.Self);//

        }

        if (m_Cammera.localPosition.z < -m_Distance)
        {
            m_Cammera.Translate(0, 0,  -(m_Cammera.localPosition.z + m_Distance));
            Debug.Log("z+");

        }
        else if (m_Cammera.localPosition.z > 0)
        {
            m_Cammera.Translate(0, 0, -m_Cammera.localPosition.z);
            Debug.Log("z-");

        }




    }
}
