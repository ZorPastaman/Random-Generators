// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Round to int Modificator for <see cref="Func{Single}"/>.
	/// </summary>
	public sealed class RoundModificatorFunc : IRoundModificator<int>
	{
		[NotNull] private Func<float> m_dependedFunc;

		/// <summary>
		/// Creates a <see cref="RoundModificatorFunc"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		public RoundModificatorFunc([NotNull] Func<float> dependedFunc)
		{
			m_dependedFunc = dependedFunc;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public RoundModificatorFunc([NotNull] RoundModificatorFunc other)
		{
			m_dependedFunc = other.m_dependedFunc;
		}

		[NotNull]
		public Func<float> dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedFunc = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return Mathf.RoundToInt(m_dependedFunc());
		}
	}
}
