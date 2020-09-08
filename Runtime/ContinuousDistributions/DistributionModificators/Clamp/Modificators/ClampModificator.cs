// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Clamp modificator for <see cref="IContinuousGenerator"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class ClampModificator<T> : IClampModificator where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private float m_min;
		private float m_max;

		/// <summary>
		/// Creates a <see cref="ClampModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public ClampModificator([NotNull] T dependedGenerator, float min, float max)
		{
			m_dependedGenerator = dependedGenerator;
			m_min = min;
			m_max = max;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public ClampModificator([NotNull] ClampModificator<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_min = other.m_min;
			m_max = other.m_max;
		}

		[NotNull]
		public T dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedGenerator = value;
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_min;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_min = value;
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_max;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_max = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return Mathf.Clamp(m_dependedGenerator.Generate(), m_min, m_max);
		}
	}
}
