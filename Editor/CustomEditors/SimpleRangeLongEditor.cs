// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEditor;
using UnityEngine;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	[CustomPropertyDrawer(typeof(SimpleRangeLong))]
	public sealed class SimpleRangeLongEditor : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var simpleRange = (SimpleRangeLong)attribute;
			long value = property.longValue;

			if (value < simpleRange.min)
			{
				value = simpleRange.min;
			}
			else if (value > simpleRange.max)
			{
				value = simpleRange.max;
			}

			property.longValue = value;
			EditorGUI.PropertyField(position, property, label);
		}
	}
}
