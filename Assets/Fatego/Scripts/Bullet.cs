using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float m_power;
    public float life;
	// Use this for initialization
	void Start () {
        Rigidbody c = transform.GetComponent<Rigidbody>();
        Vector3 V = transform.position - Camera.main.transform.position;
        V.Normalize();
        c.AddForce(V * m_power);
	}
	
	// Update is called once per frame
	void Update () {
        if (life > 0)
        {
            life -= Time.deltaTime;
        }
        else {
            GameObject.Destroy(gameObject);
        }
	}
}
