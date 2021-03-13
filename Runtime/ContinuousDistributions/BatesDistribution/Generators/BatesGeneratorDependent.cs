// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate{T}(T,float,float,byte)"/>.
	/// </summary>
	public sealed class BatesGeneratorDependent<T> : IBatesGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private float m_mean;
		private float m_deviation;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator">
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <param name="iids">
		/// How many independent and identically distributed random values are generated.
		/// </param>
		/// <remarks>
		/// <paramref name="iids"/> must be greater than 0.
		/// </remarks>
		public BatesGeneratorDependent([NotNull] T dependedGenerator, float mean, float deviation, byte iids)
		{
			m_dependedGenerator = dependedGenerator;
			m_mean = mean;
			m_deviation = deviation;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesGeneratorDependent([NotNull] BatesGeneratorDependent<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedGenerator = value;
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_mean;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_mean = value;
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_deviation;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_deviation = value;
		}

		/// <inheritdoc/>
		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_iids;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_iids = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return BatesDistribution.Generate(m_dependedGenerator, m_mean, m_deviation, m_iids);
		}
	}
}
