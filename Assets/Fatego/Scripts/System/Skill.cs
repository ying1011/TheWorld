using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//技能
namespace Skill
{
    public class CSkill
    {
        public string name;
        public int id;
        public float data;
        public virtual float GetDamage()
        {
            return data;
        }

        public virtual string GetInfo()
        {
            string str = "技能";
            return str;
        }

        public virtual string GetName()
        {
            return name;
        }
    }
}
