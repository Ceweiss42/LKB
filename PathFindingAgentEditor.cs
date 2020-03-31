using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace roundbeargames_tutorial
{
	[CustomEditor(typeof(PathfindingAgent))]
	public class PathFindingAgentEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			PathfindingAgent pathFindingAgent = (PathfindingAgent)target;

			if (GUILayout.Button("Go To Target"))
			{
				pathFindingAgent.GoToTarget();
			}
		}
	}
}