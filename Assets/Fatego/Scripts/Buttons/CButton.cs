using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class CButton : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("name = " + PlayerPrefs.GetString("name"));

        PlayerPrefs.SetString("UserData.name", "tom");
        //GlobalGameData.GetGlobalGameData().m_UserData.name = "ako";
        Debug.Log("name = " + GlobalGameData.GetGlobalGameData().m_UserData.name);

        
    }

    public void ChangeScene1()
    {
        SceneManager.LoadScene(0);
        //Debug.Log("name = " + PlayerPrefs.GetString("name"));

        PlayerPrefs.SetString("name", "tom");
        Debug.Log("name = " + GlobalGameData.GetGlobalGameData().m_UserData.name);

    }

    public void OnEnterButton()
    {
        //Debug.Log("name = " + PlayerPrefs.GetString("name"));

        Debug.Log("enter" );
        

    }



    // Update is called once per frame
    //void Update () {

    //}
}
