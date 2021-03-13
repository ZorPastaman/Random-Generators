// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEditor;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions;
using Object = UnityEngine.Object;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	[CustomPropertyDrawer(typeof(RequireDiscreteGenerator))]
	public sealed class RequireDiscreteRandomGeneratorEditor : PropertyDrawer
	{
		private const string GeneratorPropertyName = "m_DiscreteGeneratorProvider";
		private const string SharedPropertyName = "m_Shared";

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (property.type != nameof(DiscreteGeneratorProviderReference))
			{
				Debug.LogError($"Attribute {nameof(RequireDiscreteGenerator)} is set on a wrong type: {property.type}. Expected {nameof(DiscreteGeneratorProviderReference)}.");
				return base.GetPropertyHeight(property, label);
			}

			float height = EditorGUI.GetPropertyHeight(property, label, false);

			if (property.isExpanded)
			{
				SerializedProperty generatorProperty = property.FindPropertyRelative(GeneratorPropertyName);
				SerializedProperty sharedProperty = property.FindPropertyRelative(SharedPropertyName);

				height += EditorGUI.GetPropertyHeight(generatorProperty) + EditorGUI.GetPropertyHeight(sharedProperty)
					+ 2f * EditorGUIUtility.standardVerticalSpacing;
			}

			return height;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (property.type != nameof(DiscreteGeneratorProviderReference))
			{
				Debug.LogError($"Attribute {nameof(RequireDiscreteGenerator)} is set on a wrong type: {property.type}. Expected {nameof(DiscreteGeneratorProviderReference)}.");
				return;
			}

			position.height = EditorGUI.GetPropertyHeight(property, false);
			EditorGUI.PropertyField(position, property, label, false);

			if (!property.isExpanded)
			{
				return;
			}

			++EditorGUI.indentLevel;

			SerializedProperty generatorProperty = property.FindPropertyRelative(GeneratorPropertyName);
			position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
			position.height = EditorGUI.GetPropertyHeight(generatorProperty);
			if (!CheckType(generatorProperty))
			{
				generatorProperty.objectReferenceValue = null;
			}
			EditorGUI.PropertyField(position, generatorProperty);

			SerializedProperty sharedProperty = property.FindPropertyRelative(SharedPropertyName);
			position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
			position.height = EditorGUI.GetPropertyHeight(sharedProperty);
			EditorGUI.PropertyField(position, sharedProperty);

			--EditorGUI.indentLevel;
		}

		private bool CheckType(SerializedProperty property)
		{
			Object objectReference = property.objectReferenceValue;
			if (objectReference == null)
			{
				return false;
			}

			Type argumentType = GetGenericArgumentType(objectReference.GetType());
			if (argumentType == null)
			{
				return false;
			}

			return ((RequireDiscreteGenerator)attribute).valueType == argumentType;
		}

		private static Type GetGenericArgumentType(Type type)
		{
			while (type.BaseType != null)
			{
				type = type.BaseType;
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DiscreteGeneratorProvider<>))
				{
					return type.GetGenericArguments()[0];
				}
			}

			return null;
		}
	}
}
