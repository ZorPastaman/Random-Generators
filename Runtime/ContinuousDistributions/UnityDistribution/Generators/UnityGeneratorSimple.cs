// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Unity distribution generator using <see cref="Random.value"/>.
	/// </summary>
	public sealed class UnityGeneratorSimple : IUnityGenerator
	{
		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => UnityGeneratorDefaults.DefaultMin;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => UnityGeneratorDefaults.DefaultMax;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return Random.value;
		}
	}
}
