// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEditor;
using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	[CustomPropertyDrawer(typeof(SimpleRangeFloat))]
	public sealed class SimpleRangeFloatEditor : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var simpleRange = (SimpleRangeFloat)attribute;
			property.floatValue = Mathf.Clamp(property.floatValue, simpleRange.min, simpleRange.max);
			EditorGUI.PropertyField(position, property, label);
		}
	}
}
