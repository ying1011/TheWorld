using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TurnBaseOne;
using Unit;


public class CDamageSystem
{
    float GetDamageSystem(float atk, float def) {

        float temp = atk * (1 - (def / (def + Mathf.Max(1, atk - def))));
        //temp += STR * 3;
        return temp;
    }
}




//已废弃
namespace TurnBaseOne {


    public class TurnBased
    {
        int             m_CurIndex;         //当前操作下标
        public List<CUnit>     m_UnitList;         //单位列表
        public enum State {
            PAUSE,
            RUN,
            SRART_OPERATE,
            BATTLE_OPERATE,
            END_OPERATE,
            ANIMATION 
        }
 
        State m_State;            //状态 0 暂停 1运行 2操作
  
        public TurnBased() {
            LoadUnits();
        }

        public void Start() {
            m_State = State.RUN;
        }

        public void Run() {
            
            switch (m_State)
            {
                case State.PAUSE:
                    {
                        break;
                    }
                case State.RUN:
                    {
                        foreach (CUnit unit in m_UnitList){
                            unit.Run();
                        }
                        CheckOperate();
                        break;
                    }
                case State.ANIMATION:
                    {
                        break;
                    }
                case State.SRART_OPERATE:
                    {
                        break;
                    }
                case State.BATTLE_OPERATE:
                    {
                        break;
                    }
                case State.END_OPERATE:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }

        public void CheckOperate() {
            foreach (CPlayer unit in m_UnitList){
                if (unit.Operate != 0) {
                    m_State = State.SRART_OPERATE;
                    return;
                }
            }
        }

        void LoadUnits() {
            m_UnitList = GlobalGameData.GetGlobalGameData().m_BattleData.m_UnitList;
        }
    }

    class CPlayer : CUnit {
        public int AP;              //行动点
        public int MaxAP;           //最大AP
        public int AddAP;           //每回合行动点

        public int Operate;         //操作

        public float Energy;        //行动条
        public float MaxEnergy;     //行条100

        public virtual void Run()
        {
            Energy += m_CurAttribute.SPD;
            if (Energy >= MaxEnergy)
            {
                m_CurAttribute.SPD = 0;
                AP += AddAP;
                Operate = 1;
                AP = Mathf.Min(MaxAP, AP);
            }
        }
    }

}



public class TurnBasedOne : MonoBehaviour {

    TurnBased       m_TurnBased;
    float           m_FrameTime;
    public float    frame;
    float           m_CurTime;
    public float    m_TeamDistance;

    void Awake() {
        if (frame <= 0) {
            frame = 30;
        }

        //测试
        CPlayer cPlayer1 = new CPlayer
        {
            //ModelName = "child_01",
            //ModelPath = "",
            //Team = 0,

        };
        GlobalGameData.GetGlobalGameData().m_BattleData.m_UnitList.Add(cPlayer1);
        CPlayer cPlayer2 = new CPlayer
        {
            //ModelName = "child_01",
            //ModelPath = "",
            //Team = 1,
        };
        GlobalGameData.GetGlobalGameData().m_BattleData.m_UnitList.Add(cPlayer2);
        m_TurnBased = new TurnBased();
        m_FrameTime = 1 / frame;
    }
    

	// Use this for initialization
	void Start () {

        foreach (CUnit unit in m_TurnBased.m_UnitList){

            CreatGameUnit(unit);
        }
    }

    void CreatGameUnit(CUnit unit) {
        //Debug.Log(""+unit.ModelName);
        //GameObject res = Resources.Load<GameObject>(unit.ModelPath + unit.ModelName);
        //unit.Model = GameObject.Instantiate<GameObject>(res);
        //if (unit.Team == 1){
        //    unit.Model.transform.Translate(-m_TeamDistance, 0, 0);
        //    unit.Model.transform.SetParent(GameObject.Find("team1").transform);
        //}
        //else {
        //    unit.Model.transform.Translate(m_TeamDistance, 0, 0);
        //    unit.Model.transform.SetParent(GameObject.Find("team2").transform);
        //}
        //unit.Model.transform.LookAt(GameObject.Find("Origin").transform);
    }

    void SetCurUnit(int index) {

    }
	
	// Update is called once per frame
	void Update () {
        m_CurTime += Time.deltaTime;
        if (m_CurTime > m_FrameTime) {
            m_CurTime = 0;
            //刷新画面
            //TODO
            //执行逻辑
            m_TurnBased.Run();
        }
    }

    //使用技能
    void Op() {

    }
    void Op(int id){

    }
}

