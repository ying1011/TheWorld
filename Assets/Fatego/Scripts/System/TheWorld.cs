using System;
using Unit;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Configuration;

namespace TheWorld {

    //自己懒得写向量  直接调用unity的
    public class CVector3 {
        float x;
        float y;
        float z;
    }

    public class CInfo {
        public string ModelName;    //文件路径
        public string ModelPath;    //文件路径
        public Vector3 Position;    //位置
        public Vector3 Rotate;      //方向
    }

    public class CPlayer: CUnit{
        public CInfo Info;                 //信息
        public GameObject Model;    //游戏对象
        public int UserID;              //玩家ID


        public override void Run()
        {
            base.Run();
            if (UserID != 0) {
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

    public class TheWorld {
        public List<CUnit> m_UnitList;          //单位列表
        public List<CUnit> TempUnitList;         //单位列表


        public void Init() {

            CUnitAttribute att = new CUnitAttribute() {
                HP    =  100,
                MaxHP =  100,
            };
            //读取数据库
            CPlayer p1 = new CPlayer() {
                m_BaseAttribute = att,
                Id = 1,

            };
            m_UnitList.Add(p1);

        }

        public void Run()
        {

            List<CUnit> c = new List<CUnit>();
            List<CUnit> d = new List<CUnit>();

            foreach (CUnit unit in m_UnitList)
            {
                unit.Run();
                
                //创造
                CUnit u = (CUnit)unit.Create();
                if (u != null)
                {
                    c.Add(u);
                }

                //毁灭
              
                if (unit.Destroy())
                {
                    d.Add(unit);
                }
            }

            //从单位删除
            foreach (CUnit unit in d)
            {
                m_UnitList.Remove(unit);
            }

            //加入单位组
            foreach (CUnit unit in c)
            {
                m_UnitList.Add(unit);
            }

        }

        //创造
        public void Create(Zero zero) {

        }

        //毁灭
        public void Destroy(Zero zero){

        }

        public void Save(){
            foreach (CUnit unit in m_UnitList)
            {
                unit.Save();
            }
        }

        //操作
        public void Operate(OperateData data)
        {
            CPlayer unit = (CPlayer)m_UnitList[data.ID];
            unit.Operate(data);
        }

        //移动
        public void Move(MoveData data)
        {
            CPlayer unit = (CPlayer)m_UnitList[data.ID];
            unit.Move(data);
        }



    }
}

