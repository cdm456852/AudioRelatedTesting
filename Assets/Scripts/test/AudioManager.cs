using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;    // 进行控制的Mixer变量

    public void SetMasterVolume(float volume)    // 控制主音量的函数
    {
        audioMixer.SetFloat("MasterVolume", volume);
        // MasterVolume为我们暴露出来的Master的参数
    }

    public void SetMusicVolume(float volume)    // 控制背景音乐音量的函数
    {
        audioMixer.SetFloat("MusicVolume", volume);
        // MusicVolume为我们暴露出来的Music的参数
    }

    public void SetSoundEffectVolume(float volume)    // 控制音效音量的函数
    {
        audioMixer.SetFloat("SoundEffectVolume", volume);
        // SoundEffectVolume为我们暴露出来的SoundEffect的参数
    }


}


public class ScriptAction:ScriptableObject
{

    //记录从外部传进来的参数 施法单位 目标单位 目标点 技能蓄力...

    public enum ActionNameEnum
    {
        Delay,
        HpDamage,
        AddBuff,
        AddComponent,

    }

    public enum ComponentEnum
    {
        MoveComponent,
        FightComponent,
        AttackComponent
    }


    //和editor建立关联 根据不同的方法名展现不同的参数 及返回值
    [SerializeField]
    public class ActionInfo
    {
        //方法名字
        public ActionNameEnum ActionNameEnum;

        #region 方法添加的组件名字
        public ComponentEnum ComponentEnum;
        #endregion

        #region 技能的回调

        //是否有伤害回调
        public bool HasDamageCallBack;
        //是否有到达目标回调
        public bool HasTargetReachedCallBack;
        


        #endregion

        #region 方法参数

        public bool BoolPara1;
        public bool BoolPara2;
        public bool BoolPara3;
        public bool BoolPara4;

        public int FloatPara1;
        public int FloatPara2;
        public int FloatPara3;
        public int FloatPara4;

        public int IntPara1;
        public int IntPara2;
        public int IntPara3;
        public int IntPara4;

        public string StringPara1;
        public string StringPara2;
        public string StringPara3;
        public string StringPara4;

        #endregion

        #region 返回值

        public bool BoolRtn1;
        public bool FloatRtn1;
        public bool IntRtn1;
        public bool StringRtn1;
        
        #endregion
    }

    public List<ActionInfo> ActionInfoList;
    
}

public static class StaticActionClass
{
    //{
    //    Delay,
    //    HpDamage,
    //    AddBuff,
    //    AddComponent,
    //}

    public static void Delay(int frameCount)
    {
        Debug.Log("Delay:" + frameCount);
    }

    public static float HpDamage(int unitID,float HPDmg)
    {
        Debug.Log(string.Format("HpDamage({0},{1})",unitID,HPDmg));
        return HPDmg;
    }
    
    public static void AddBuff(int unitID,int buffID,int buffDuration)
    {
        Debug.Log(string.Format("AddBuff({0},{1},{2})", unitID, buffID, buffDuration));
    }

    public static bool AddComponent(ScriptAction.ComponentEnum componentEnum,int defaultValue)
    {
        Debug.Log(string.Format("AddComponent({0},{1})", componentEnum.ToString(), defaultValue));
        return true;
    }

}

//测试脚本
public class TestScriptAction
{
    //public ScriptAction 
}