// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using UnityEditor;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions.DistributionFilters;
using Object = UnityEngine.Object;

namespace Zor.RandomGenerators.PropertyDrawerAttributes
{
	[CustomPropertyDrawer(typeof(RequireDiscreteFilter))]
	public sealed class RequireDiscreteRandomFilterEditor : PropertyDrawer
	{
		private const string FilterPropertyName = "m_FilterProvider";
		private const string SharedPropertyName = "m_Shared";

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (property.type != nameof(DiscreteFilterProviderReference))
			{
				Debug.LogError($"Attribute {nameof(RequireDiscreteFilter)} is set on a wrong type: {property.type}. Expected {nameof(DiscreteFilterProviderReference)}.");
				return base.GetPropertyHeight(property, label);
			}

			float height = EditorGUI.GetPropertyHeight(property, label, false);

			if (property.isExpanded)
			{
				SerializedProperty filterProperty = property.FindPropertyRelative(FilterPropertyName);
				SerializedProperty sharedProperty = property.FindPropertyRelative(SharedPropertyName);

				height += EditorGUI.GetPropertyHeight(filterProperty) + EditorGUI.GetPropertyHeight(sharedProperty)
					+ 2f * EditorGUIUtility.standardVerticalSpacing;
			}

			return height;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (property.type != nameof(DiscreteFilterProviderReference))
			{
				Debug.LogError($"Attribute {nameof(RequireDiscreteFilter)} is set on a wrong type: {property.type}. Expected {nameof(DiscreteFilterProviderReference)}.");
				return;
			}

			position.height = EditorGUI.GetPropertyHeight(property, false);
			EditorGUI.PropertyField(position, property, label, false);

			if (!property.isExpanded)
			{
				return;
			}

			++EditorGUI.indentLevel;

			SerializedProperty filterProperty = property.FindPropertyRelative(FilterPropertyName);
			position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
			position.height = EditorGUI.GetPropertyHeight(filterProperty);
			if (!CheckType(filterProperty))
			{
				filterProperty.objectReferenceValue = null;
			}
			EditorGUI.PropertyField(position, filterProperty);

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

			return ((RequireDiscreteFilter)attribute).valueType == argumentType;
		}

		private static Type GetGenericArgumentType(Type type)
		{
			while (type.BaseType != null)
			{
				type = type.BaseType;
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DiscreteFilterProvider<>))
				{
					return type.GetGenericArguments()[0];
				}
			}

			return null;
		}
	}
}
