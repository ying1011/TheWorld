using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour {

    public RectTransform pack;
    public Button bTemp;
    int[] data;
    public int num;
    public float m_Size;
    int m_W;
    int m_H;
    Button[] list;
    void Init() {
        if (m_Size == 0) {
            m_Size = 10;
        }

        if (num == 0) {
            num = 1;
        }
        list = new Button[10];
    }

    void UpdateHeight() {
        if (num == 0)
        {
            num = 1;
        }
        m_H = num / m_W;
        pack.sizeDelta = new Vector2(pack.sizeDelta.x, m_H * m_Size);
    }

    // Use this for initialization
    void Start () {
        Init();
        //float hight = 0 / (num + 1);
        m_W = Mathf.FloorToInt(pack.rect.width / m_Size);
        UpdateHeight();
        for (int i = 0; i < num; i++) {
            CreatButton(i);
        }
    }

    void CreatButton(int index) {
        Button b = GameObject.Instantiate<Button>(bTemp,transform);
        float tempX = index % m_W;
        float tempY = index / m_W;
        b.GetComponentInChildren<Text>().text = "" + index;
        b.GetComponent<RectTransform>().anchoredPosition = new Vector2(tempX * m_Size, tempY * m_Size);
        list[index] = b;
    }
	// Update is called once per frame
	void Update () {
        UpdateHeight();

    }

    public void OnClickb(int id) {

    }
}
