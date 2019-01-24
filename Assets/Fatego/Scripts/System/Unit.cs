using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skill;
using Item;
using TheWorld;

    /*
     *  unitType
     *  1人物
     *  2材料
     *  
     *
     *
     *
     *
     *
     *
     *
     *
     *
     *
     *
     */


namespace Unit
{


    public class CBaseAttribute{
        //基础属性
        public float HP;             //血
        public float MaxHP;          //血
        public float MP;             //蓝
        public float MaxMP;          //蓝
        public CBaseAttribute() {
            HP      = 100;
            MaxHP = 100;
            MP = 100;
            MaxMP = 100;
        }
    }

    public class CUnitAttribute: CBaseAttribute {

        //基础属性
        public float STR;  //力量 +攻击力
        public float AGL;  //敏捷
        public float INT;  //智力 
        public float CON;  //体质
        public float ATK;  //攻击力 ATK=ATK+STR*N+ADD
        public float DEF;  //防御力 DEF=DEF+ADD
        public float SPD;  //速度

        //其它属性
        public float LCK;  //幸运

        //进阶属性
        public float DEX;  //灵巧
        public float VIT;  //耐力
        public float WIS;  //魔防
        public float MGA;  //魔攻
        public float RCV;  //恢复力0
        public float HIT;  //命中/伤害次数
        public float AVD;  //回避
        public float CRI;  //必杀/暴击
        public float CTR;  //反击
        public float CHR;  //魅力

        public CUnitAttribute() {
            STR = 100;
            AGL = 100;
            INT = 100;
            CON = 100;
            ATK = 100;
            DEF = 100;
            SPD = 100;
            LCK = 100;
            DEX = 100;
            VIT = 100;
            WIS = 100;
            MGA = 100;
            RCV = 100;
            HIT = 100;
            AVD = 100;
            CRI = 100;
            CTR = 100;
            CHR = 100;
        }
    }

    public class CUnitBaseInfo {
        public int Type;            //类型
        public int Team;            //队伍
        public string Name;         //
        public int State;           //状态
        public CUnitBaseInfo() {
            Type = 0;
            Team = 0;
            Name = "";
            State = 0;
        }

    }

    public class CUnit: Zero
    {
        public int Id;              //id

        public CUnitAttribute m_BaseAttribute;
        public CUnitAttribute m_AddAttribute;
        public CUnitAttribute m_CurAttribute;

        public CUnitBaseInfo BaseInfo;

        public List<CSkill> SkillList;    //技能列表
        public List<CItem> Backpack;      //背包

        public List<int> Status;          //持续状态

        public CUnit()
        {
            m_BaseAttribute = new CUnitAttribute();
            m_AddAttribute = new CUnitAttribute();
            m_CurAttribute = new CUnitAttribute();
            Status = new List<int>();
            SkillList = new List<CSkill>();
            Backpack = new List<CItem>();
            BaseInfo = new CUnitBaseInfo();
            Id = 0;
        }

        ~CUnit() { }

        public void UpdateCurAttribute()
        {
            m_CurAttribute = AddAttributr(m_BaseAttribute, m_AddAttribute);
        }

        public CUnitAttribute AddAttributr(CUnitAttribute l, CUnitAttribute r)
        {
            CUnitAttribute Attribute = new CUnitAttribute();
            Attribute.HP = l.HP + r.HP;
            Attribute.MaxHP = l.MaxHP + r.MaxHP;
            Attribute.MP = l.MP + r.MP;
            Attribute.MaxMP = l.MaxMP + r.MaxMP;
            Attribute.STR = l.STR + r.STR;
            Attribute.ATK = l.ATK + r.ATK;
            Attribute.DEF = l.DEF + r.DEF;

            return Attribute;
        }
        
    }

}
