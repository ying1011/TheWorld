using System;
using Unit;
using System.Collections.Generic;
using UnityEngine;
using System.Configuration;

namespace TheWorld
{

    //自己懒得写向量  
    public class CVector3
    {
        float x;
        float y;
        float z;
    }

    public class CInfo
    {
        public string ModelName;    //文件路径
        public string ModelPath;    //文件路径
        public Vector3 Position;    //位置
        public Vector3 Rotate;      //方向
        public CInfo() {
            Position = Vector3.zero;
            Rotate = Vector3.zero;
        }
    }

    public class CPlayer : CUnit
    {
        public CInfo Info;              //信息
        public GameObject Model;        //游戏对象
        public int UserID;              //玩家ID
        public CPlayer() {
            Info = new CInfo();
        }

        public void Init(string path, string name)
        {
            Info.ModelPath = path;
            Info.ModelName = name;
            GameObject res = Resources.Load<GameObject>(Info.ModelPath + Info.ModelName);
            Model = GameObject.Instantiate<GameObject>(res);
            Model.transform.SetParent(GameObject.Find("GameObject").transform);
            Model.transform.position = Info.Position;
            Model.transform.rotation = Quaternion.Euler(Info.Rotate);
        }

        public override void Run()
        {
            base.Run();
            if (UserID != 0)
            {
                //AI操作
            }
        }
    }


    public struct OperateData
    {
        public int ID;
        public int Operate;  //操作
        public int Data;
    }

    public struct MoveData
    {
        public int ID;
        public CVector3 Rotate;  //方向

    }

    public class CTheWorld
    {
        public CUnit MainUnit;
        public List<CUnit> m_UnitList;          //单位列表
        public List<CUnit> TempUnitList;         //单位列表
        static CTheWorld self;

        CTheWorld()
        {
            m_UnitList = new List<CUnit>();
            Init();
        }

        public static CTheWorld GetGameCore()
        {
            if (self == null)
            {
                self = new CTheWorld();
            }
            return self;
        }

        public void Init()
        {

            //读取数据库
            CPlayer p1 = new CPlayer()
            {
                Id = 1,
                UserID = 1,
            };
            p1.Init("", "child_01");

            m_UnitList.Add(p1);

        }

        public void Run()
        {
            //更新画面

            List<CUnit> c = new List<CUnit>();
            List<CUnit> d = new List<CUnit>();

            //删除单位

            //单位
            foreach (CUnit unit in m_UnitList)
            {
                unit.Run();
            }


        }

        //创造
        public void Create(Zero zero)
        {

        }

        //毁灭
        public void Destroy(Zero zero)
        {

        }

        public void Save()
        {
            foreach (CUnit unit in m_UnitList)
            {
                unit.Save();
            }
        }

        //操作
        public void Operate(OperateData data)
        {
            CPlayer unit = (CPlayer)m_UnitList[data.ID];

        }

        //移动
        public void Move(MoveData data)
        {
            CPlayer unit = (CPlayer)m_UnitList[data.ID];
        }



    }
}

