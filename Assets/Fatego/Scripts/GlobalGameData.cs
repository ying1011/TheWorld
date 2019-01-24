using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBaseOne;
using Unit;
using TheWorld;

public struct UserData {
    public int level;       //等级
    public string name;     //名字
  
}

public struct SceneData {
    public List<CUnit> m_UnitList;
}

public struct BattleData
{
    public List<CUnit> m_UnitList;
}

public class GlobalGameData {

    static GlobalGameData   self;           //本体指针

    public UserData         m_UserData;     //用户数据

    public SceneData        m_SceneData;    //场景数据

    public BattleData       m_BattleData;   //战斗数据


    GlobalGameData() {
        InitUserData();

        m_SceneData.m_UnitList = new List<CUnit>();
        m_BattleData.m_UnitList = new List<CUnit>();

    }
    ~GlobalGameData() { }

    public static GlobalGameData GetGlobalGameData() {
        if (self == null) {
            self = new GlobalGameData();
        }
        return self;
    }

    void InitUserData() {
     
        if(PlayerPrefs.HasKey(""))
        m_UserData.name = PlayerPrefs.GetString("UserData.name");
        m_UserData.level = PlayerPrefs.GetInt("UserData.level");
    }

}
