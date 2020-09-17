// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Round to int Modificator for <see cref="IContinuousGenerator"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class RoundModificator<T> : IRoundModificator<int> where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;

		/// <summary>
		/// Creates a <see cref="RoundModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		public RoundModificator([NotNull] T dependedGenerator)
		{
			m_dependedGenerator = dependedGenerator;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public RoundModificator([NotNull] RoundModificator<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
		}

		[NotNull]
		public T dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedGenerator = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return Mathf.RoundToInt(m_dependedGenerator.Generate());
		}
	}
}
