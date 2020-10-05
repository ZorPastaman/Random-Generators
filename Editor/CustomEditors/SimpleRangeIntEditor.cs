// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEditor;
using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	[CustomPropertyDrawer(typeof(SimpleRangeInt))]
	public sealed class SimpleRangeIntEditor : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var simpleRange = (SimpleRangeInt)attribute;
			property.intValue = Mathf.Clamp(property.intValue, simpleRange.min, simpleRange.max);
			EditorGUI.PropertyField(position, property, label);
		}
	}
}
