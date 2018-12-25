using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ScriptActionNS
{

    //参数类型
    public enum ParameterType
    {
        Bool,
        Float,
        Int,
        String
    }

    //变量存储的信息
    [System.Serializable]
    public struct ParamInfo
    {
        public string ParamName;
        public ParameterType ParamType;
        public int IntParamValue;
        public string StringParamValue;
        public float FloatParamValue;
        public bool BoolParamValue;
    }

    //脚本方法的名字
    public enum ActionNameEnum
    {
        None,                       //无
        Delay,                      //延迟
        HpDamage,                   //伤害
        AddBuff,                    //添加buff
        AddComponent,               //添加组件
        IF_ELSEIF_ELSE_END,         //如果
        Plus,                       //加法
        Minus,                      //减法
        Multiplication,             //乘法
        Division,                   //除法
        Mod                         //取余数
    }

    //添加的component的枚举
    public enum ComponentEnum
    {
        None,
        MoveComponent,
        FightComponent,
        AttackComponent
    }

    //条件判断
    public enum ConditionEnum
    {
        None,                       //无
        Equal,                      //等于
        NotEqualTo,                 //不等于
        GreaterThan,                //大于
        LessThan,                   //小于
        GreaterThanOrEqualTo,       //大于等于
        LessThanOrEqualTo           //小于等于
    }

    //和editor建立关联 根据不同的方法名展现不同的参数 及返回值
    [System.Serializable]
    public class ActionInfo
    {

        //方法名字
        public ActionNameEnum ActionNameEnum;

        //用于if else 多层嵌套的情况
        public Dictionary<int, List<ActionInfo>> CondentionActionInfoList;

        //条件判断符号
        public ConditionEnum ConditionEnum;

        #region 方法参数

        public bool BoolPara1;
        public bool BoolPara2;
        public bool BoolPara3;
        public bool BoolPara4;

        public float FloatPara1;
        public float FloatPara2;
        public float FloatPara3;
        public float FloatPara4;

        public int IntPara1;
        public int IntPara2;
        public int IntPara3;
        public int IntPara4;

        public string StringPara1;
        public string StringPara2;
        public string StringPara3;
        public string StringPara4;

        public ComponentEnum ComponentEnum1;
        public ComponentEnum ComponentEnum2;
        public ComponentEnum ComponentEnum3;
        public ComponentEnum ComponentEnum4;

        #endregion

        #region 返回值
        public ParamInfo Ret;
        #endregion
    }

    public class ScriptAction : ScriptableObject
    {
        //记录从外部传进来的参数 施法单位 目标单位 目标点 技能蓄力...
        
        //变量内容
        Dictionary<string, ParamInfo> VariableInfoDict;
        
        #region 技能的回调

        //是否有伤害回调
        public bool HasDamageCallBack;
        //是否有到达目标回调
        public bool HasTargetReachedCallBack;

        //伤害回调
        public List<ActionInfo> DamageCallBack;
        //到达目标点回调
        public List<ActionInfo> TargetReachedCallBack;

        #endregion
        public List<ActionInfo> ActionInfoList;
        

    }

    //脚本方法
    public static class StaticActionClass
    {
        //None,                       //无
        //Delay,                      //延迟
        //HpDamage,                   //伤害
        //AddBuff,                    //添加buff
        //AddComponent,               //添加组件
        //IF_ELSEIF_ELSE_END,         //如果
        //Plus,                       //加法
        //Minus,                      //减法
        //Multiplication,             //乘法
        //Division,                   //除法
        //Mod                         //取余数

        public static void Delay(int frameCount)
        {
            Debug.Log("Delay:" + frameCount);
        }

        public static float HpDamage(int unitID, float HPDmg)
        {
            Debug.Log(string.Format("HpDamage({0},{1})", unitID, HPDmg));
            return HPDmg;
        }

        public static void AddBuff(int unitID, int buffID, int buffDuration)
        {
            Debug.Log(string.Format("AddBuff({0},{1},{2})", unitID, buffID, buffDuration));
        }

        public static bool AddComponent(ComponentEnum componentEnum, int defaultValue)
        {
            Debug.Log(string.Format("AddComponent({0},{1})", componentEnum.ToString(), defaultValue));
            return true;
        }

        //Plus,                       //加法
        //Minus,                      //减法
        //Multiplication,             //乘法
        //Division,                   //除法
        //Mod                         //取余数

        //int
        //float

        public static int Plus(int intPara1, int intPara2)
        {
            int ret = intPara1 + intPara2;
            Debug.Log(string.Format("Plus({0},{1})", intPara1, intPara2));
            return ret;
        }

        public static float Plus(float floatPara1, float floatPara2)
        {
            float ret = floatPara1 + floatPara2;
            return ret;
        }
    }

    //条件判断方法
    public static class StaticConditionClass
    {
        //None,                       //无
        //Equal,                      //等于
        //NotEqualTo,                 //不等于
        //GreaterThan,                //大于
        //LessThan,                   //小于
        //GreaterThanOrEqualTo,       //大于等于
        //LessThanOrEqualTo           //小于等于

        
        //bool
        //float
        //int
        //string
        //class
        public static bool Equal(bool boolPara1, bool boolPara2)
        {
            if (boolPara1 == boolPara2)
                return true;
            return false;
        }

        public static bool Equal(float floatPara1, float floatPara2)
        {
            if (floatPara1 == floatPara2)
                return true;
            return false;
        }

        public static bool Equal(int intPara1, int intPara2)
        {
            if (intPara1 == intPara2)
                return true;
            return false;
        }

        public static bool Equal(string stringPara1, string stringPara2)
        {
            if (stringPara1 == stringPara2)
                return true;
            return false;
        }

        public static bool Equal<T>(T boolPara1, T boolPara2) where T : class
        {
            if (boolPara1 == boolPara2)
                return true;
            return false;
        }
    }

}
