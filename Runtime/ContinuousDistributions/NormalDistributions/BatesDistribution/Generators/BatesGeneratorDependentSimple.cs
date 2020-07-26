// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate{T}(T,byte)"/>.
	/// </summary>
	public sealed class BatesGeneratorDependentSimple<T> : IBatesGenerator
		where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesGeneratorDependentSimple{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BatesGeneratorDependentSimple([NotNull] T dependedGenerator, byte iids = BatesDistribution.DefaultIids)
		{
			m_dependedGenerator = dependedGenerator;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesGeneratorDependentSimple([NotNull] BatesGeneratorDependentSimple<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[Pure]
			get => m_dependedGenerator;
			set => m_dependedGenerator = value;
		}

		public float mean
		{
			[Pure]
			get => BatesDistribution.DefaultMean;
		}

		public float deviation
		{
			[Pure]
			get => BatesDistribution.DefaultDeviation;
		}

		/// <inheritdoc/>
		public byte iids
		{
			[Pure]
			get => m_iids;
			set => m_iids = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return BatesDistribution.Generate(m_dependedGenerator, m_iids);
		}
	}
}
