// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Multiply modificator for <see cref="Func{Single}"/>.
	/// </summary>
	public sealed class MultiplyModificatorFunc : IMultiplyModificator
	{
		[NotNull] private Func<float> m_dependedFunc;
		private float m_multiplier;

		/// <summary>
		/// Creates <see cref="MultiplyModificatorFunc"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		/// <param name="multiplier"></param>
		public MultiplyModificatorFunc([NotNull] Func<float> dependedFunc, float multiplier)
		{
			m_dependedFunc = dependedFunc;
			m_multiplier = multiplier;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public MultiplyModificatorFunc([NotNull] MultiplyModificatorFunc other)
		{
			m_dependedFunc = other.m_dependedFunc;
			m_multiplier = other.m_multiplier;
		}

		[NotNull]
		public Func<float> dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedFunc = value;
		}

		public float multiplier
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_multiplier;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_multiplier = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return m_dependedFunc() * m_multiplier;
		}
	}
}
