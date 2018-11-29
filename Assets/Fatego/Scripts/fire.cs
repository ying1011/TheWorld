using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
    public float maxInterval;
    float m_Interval;
    public GameObject obj;
    void Awake() {
        m_Interval = 0;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Interval > 0) {
            m_Interval -= Time.deltaTime;
        }
        if (Input.GetAxis("Fire1") != 0 && m_Interval <= 0) {
            GameObject.Instantiate(obj, Camera.main.transform);
            m_Interval = maxInterval;
        }
	}
}
