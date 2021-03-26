// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Multiply Modificator for <see cref="IContinuousGenerator"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class MultiplyModificator<T> : IMultiplyModificator where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private float m_multiplier;

		/// <summary>
		/// Creates <see cref="MultiplyModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		/// <param name="multiplier"></param>
		public MultiplyModificator([NotNull] T dependedGenerator, float multiplier)
		{
			m_dependedGenerator = dependedGenerator;
			m_multiplier = multiplier;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public MultiplyModificator([NotNull] MultiplyModificator<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_multiplier = other.m_multiplier;
		}

		[NotNull]
		public T dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedGenerator = value;
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
			return m_dependedGenerator.Generate() * m_multiplier;
		}
	}
}
