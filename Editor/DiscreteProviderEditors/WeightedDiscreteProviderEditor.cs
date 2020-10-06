// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Globalization;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Zor.RandomGenerators.DiscreteDistributions;

namespace Zor.RandomGenerators.DiscreteProviderEditors
{
	[UsedImplicitly,
	DiscreteProviderType(typeof(WeightedGeneratorProvider<>), typeof(WeightedGeneratorDependentProvider<>))]
	public sealed class WeightedDiscreteProviderEditor : DiscreteProviderEditor
	{
		private const string ValuesPropertyName = "m_Values";
		private const string WeightsPropertyName = "m_Weights";

		private static readonly GUIContent s_valueGuiContent = new GUIContent("Value");
		private static readonly GUIContent s_weightGuiContent = new GUIContent("Weight");

		private SerializedObject m_discreteGeneratorProvider;
		private SerializedProperty m_valuesProperty;
		private SerializedProperty m_weightsProperty;
		private ReorderableList m_list;

		public override void Initialize(SerializedObject discreteGeneratorProvider)
		{
			m_discreteGeneratorProvider = discreteGeneratorProvider;
			m_valuesProperty = discreteGeneratorProvider.FindProperty(ValuesPropertyName);
			m_weightsProperty = discreteGeneratorProvider.FindProperty(WeightsPropertyName);

			m_list = new ReorderableList(discreteGeneratorProvider, m_valuesProperty, true, true, true, true)
			{
				drawHeaderCallback = DrawHeader,
				drawElementCallback = DrawElement,
				elementHeightCallback = GetElementHeight,
				onReorderCallbackWithDetails = OnReorder,
				onAddCallback = OnAdd,
				onRemoveCallback = OnRemove
			};
		}

		public override void Draw()
		{
			m_list.DoLayoutList();
		}

		private void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect,
				$"Values. Size: {m_list.count.ToString()}. Weights Sum: {GetWeightsSum().ToString()}");
		}

		private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
		{
			SerializedProperty valueProperty = m_valuesProperty.GetArrayElementAtIndex(index);
			SerializedProperty weightProperty = m_weightsProperty.GetArrayElementAtIndex(index);

			rect.y += EditorGUIUtility.standardVerticalSpacing;
			rect.height = EditorGUI.GetPropertyHeight(valueProperty);
			EditorGUI.PropertyField(rect, valueProperty, s_valueGuiContent, true);

			rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;
			rect.height = EditorGUI.GetPropertyHeight(weightProperty);
			EditorGUI.PropertyField(rect, weightProperty, s_weightGuiContent, true);

			rect.y += rect.height + EditorGUIUtility.standardVerticalSpacing;
			rect.height = EditorGUIUtility.singleLineHeight;
			EditorGUI.LabelField(rect, "Probability",
				((double)weightProperty.longValue / GetWeightsSum()).ToString(CultureInfo.InvariantCulture));

			m_discreteGeneratorProvider.ApplyModifiedProperties();
		}

		private float GetElementHeight(int index)
		{
			SerializedProperty valueProperty = m_valuesProperty.GetArrayElementAtIndex(index);
			SerializedProperty weightProperty = m_weightsProperty.GetArrayElementAtIndex(index);

			return EditorGUI.GetPropertyHeight(valueProperty) + EditorGUI.GetPropertyHeight(weightProperty)
				+ EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing * 4f;
		}

		private void OnReorder(ReorderableList list, int oldIndex, int newIndex)
		{
			m_weightsProperty.MoveArrayElement(oldIndex, newIndex);

			m_discreteGeneratorProvider.ApplyModifiedProperties();
		}

		private void OnAdd(ReorderableList list)
		{
			++m_valuesProperty.arraySize;
			++m_weightsProperty.arraySize;

			m_discreteGeneratorProvider.ApplyModifiedProperties();
		}

		private void OnRemove(ReorderableList list)
		{
			int index = list.index;
			m_valuesProperty.DeleteArrayElementAtIndex(index);
			m_weightsProperty.DeleteArrayElementAtIndex(index);

			m_discreteGeneratorProvider.ApplyModifiedProperties();
		}

		private uint GetWeightsSum()
		{
			uint weights = 0u;

			for (int i = 0, count = m_weightsProperty.arraySize; i < count; ++i)
			{
				weights += (uint)m_weightsProperty.GetArrayElementAtIndex(i).longValue;
			}

			return weights;
		}
	}
}
