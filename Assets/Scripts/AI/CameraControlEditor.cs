using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraControl))]
public class CameraControlEditor : Editor
{
    override public void OnInspectorGUI()
    {
        CameraControl script = target as CameraControl;

        script.unlockX = EditorGUILayout.Toggle("Unlock X", script.unlockX);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(script.unlockX)))
        {
            if (group.visible)
            {
                script.minX = EditorGUILayout.FloatField("Left", script.minX);
                script.maxX = EditorGUILayout.FloatField("Right", script.maxX);
            }
        }

        script.unlockY = EditorGUILayout.Toggle("Unlock Y", script.unlockY);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(script.unlockY)))
        {
            if (group.visible)
            {
                script.minY = EditorGUILayout.FloatField("Bottom", script.minY);
                script.maxY = EditorGUILayout.FloatField("Top", script.maxY);
            }
        }
    }
}