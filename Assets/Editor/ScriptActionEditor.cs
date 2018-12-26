using ScriptActionNS;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptAction))]
public class ScriptActionEditor:Editor
{

    public override void OnInspectorGUI()
    {
        ScriptAction scriptAction= target as ScriptAction;
        if(scriptAction==null)
        {
            Debug.LogError("scriptAction==null");
            return;
        }
        if (scriptAction.ActionInfoList == null)
            scriptAction.ActionInfoList = new List<ActionInfo>();
        if(scriptAction.ActionInfoList==null)
        {
            Debug.LogError("scriptAction.ActionInfoList==null");
            return;
        }

        if (scriptAction.ActionInfoList!=null&&scriptAction.ActionInfoList.Count <= 0)
        {
            if( GUILayout.Button("Create"))
            {
                scriptAction.ActionInfoList.Add(new ActionInfo());
            }
        }

        for (int i = 0; i < scriptAction.ActionInfoList.Count; i++)
        {
            ActionInfo actionInfo= scriptAction.ActionInfoList[i];
            HandleEditActionInfo(actionInfo);
            //如果是最后一个
            if (i == scriptAction.ActionInfoList.Count - 1)
            {
                EditorGUILayout.BeginVertical();
                if (GUILayout.Button("Add"))
                {
                    scriptAction.ActionInfoList.Add(new ActionInfo());
                }
                if (GUILayout.Button("Save"))
                {
                    AssetDatabase.SaveAssets();
                }
                EditorGUILayout.EndVertical();
            }
        }

    }

    //处理技能信息的编辑
    public void HandleEditActionInfo(ActionInfo actionInfo)
    {
        //每一行技能脚本的开始
        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();

        //GUILayout.Button(actionInfo.ActionNameEnum.ToString());

        //if (GUILayout.Button("X"))
        //{
        //    scriptAction.ActionInfoList.RemoveAt(i);
        //    return;
        //}
        actionInfo.ActionNameEnum= (ActionNameEnum)EditorGUILayout.EnumPopup("ActionNameEnum", actionInfo.ActionNameEnum,
                                    GUILayout.Width(100), GUILayout.Height(20),
                                    GUILayout.MaxWidth(200),GUILayout.MaxHeight(80),GUILayout.ExpandHeight(true),GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();

        //每一行技能脚本的结束
        EditorGUILayout.EndVertical();
    }

}

public static class UtilClass
{
    [MenuItem("Tools/CreateScriptAction")]
    public static void CreateScriptAction()
    {
        ScriptAction scriptAction = ScriptableObject.CreateInstance<ScriptAction>();
        FileUtil.DeleteFileOrDirectory("Assets/Res/ScriptActionAsset.asset");
        AssetDatabase.Refresh();
        AssetDatabase.CreateAsset(scriptAction, "Assets/Res/ScriptActionAsset.asset");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

//{
//using UnityEngine;
//using System.Collections; using FastCollections;
//using UnityEditor;

//namespace Lockstep.Integration
//{
//    [CustomEditor(typeof(LSProjectile))]
//    public class EditorLSProjectile : Editor
//    {
//        SerializedObject so { get { return base.serializedObject; } }
//        public override void OnInspectorGUI()
//        {
//            EditorGUI.BeginChangeCheck();

//            //Targeting
//            EditorGUILayout.LabelField("Targeting Settings", EditorStyles.boldLabel);
//            so.PropertyField("_targetingBehavior");
//            TargetingType targetingBehavior = (TargetingType)so.FindProperty("_targetingBehavior").enumValueIndex;
//            switch (targetingBehavior)
//            {
//                case TargetingType.Directional:
//                    so.PropertyField("_speed");
//                    break;
//                case TargetingType.Positional:
//                case TargetingType.Homing:
//                    so.PropertyField("_speed");
//                    so.PropertyField("_visualArc");
//                    break;
//                case TargetingType.Timed:
//                    so.PropertyField("_delay");
//                    so.PropertyField("_lastingDuration");
//                    so.PropertyField("_tickRate");
//                    break;
//            }
//            EditorGUILayout.Space();

//            //Damage
//            EditorGUILayout.LabelField("Damage Settings", EditorStyles.boldLabel);
//            so.PropertyField("_hitBehavior");
//            switch ((HitType)so.FindProperty("_hitBehavior").enumValueIndex)
//            {
//                case HitType.Cone:
//                    so.PropertyField("_angle");
//                    so.PropertyField("_radius");
//                    break;
//                case HitType.Area:
//                    so.PropertyField("_radius");
//                    break;

//                case HitType.Single:

//                    break;
//            }
//            EditorGUILayout.Space();

//            //Trajectory
//            EditorGUILayout.LabelField("Trajectory Settings", EditorStyles.boldLabel);

//            EditorGUILayout.Space();

//            //Visuals
//            EditorGUILayout.LabelField("Visuals Settings", EditorStyles.boldLabel);

//            SerializedProperty useEffectProp = so.FindProperty("UseEffects");

//            EditorGUILayout.PropertyField(useEffectProp);


//            if (useEffectProp.boolValue)
//            {
//                so.PropertyField("_startFX");
//                so.PropertyField("_hitFX");
//                so.PropertyField("_attachEndEffectToTarget");
//            }

//            //PAPPS ADDED THIS:
//            so.PropertyField("DoReleaseChildren");

//            if (EditorGUI.EndChangeCheck())
//            {
//                serializedObject.ApplyModifiedProperties();
//                EditorUtility.SetDirty(target);
//            }
//        }
//    }
//}
//}