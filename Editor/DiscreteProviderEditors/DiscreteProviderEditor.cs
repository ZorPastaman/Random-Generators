// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEditor;
using Zor.RandomGenerators.DiscreteDistributions;

namespace Zor.RandomGenerators.DiscreteProviderEditors
{
	/// <summary>
	/// <para>Base class for an editor for <see cref="DiscreteGeneratorProvider_Base"/>.</para>
	/// <para>Use <see cref="DiscreteProviderType"/> to specify supported types.</para>
	/// </summary>
	public abstract class DiscreteProviderEditor
	{
		public abstract void Initialize([NotNull] SerializedObject discreteGeneratorProvider);

		public abstract void Draw();
	}
}
