// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.value"/>.
	/// </summary>
	[Serializable]
	public sealed class UnityGeneratorSimple : IContinuousGenerator
	{
		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return Random.value;
		}
	}
}
