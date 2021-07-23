// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEditor;
using Zor.RandomGenerators.DiscreteProviderEditors;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	[CustomEditor(typeof(DiscreteGeneratorProvider_Base), true)]
	public sealed class DiscreteGeneratorProviderEditor : Editor
	{
		private DiscreteProviderEditor m_discreteProviderEditor;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			m_discreteProviderEditor?.Draw();
		}

		private void OnEnable()
		{
			m_discreteProviderEditor = DiscreteProviderEditorsCollection.GetEditor(target.GetType());
			m_discreteProviderEditor?.Initialize(serializedObject);
		}
	}
}
