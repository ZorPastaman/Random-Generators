// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate{T}(T,byte)"/>.
	/// </summary>
	public sealed class BatesRandomGeneratorRandomGeneratorDependentSimple<T> : IBatesRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesRandomGeneratorRandomGeneratorDependentSimple{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedRandomGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		public BatesRandomGeneratorRandomGeneratorDependentSimple([NotNull] T dependedRandomGenerator,
			byte iids = BatesDistribution.DefaultIids)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesRandomGeneratorRandomGeneratorDependentSimple(
			[NotNull] BatesRandomGeneratorRandomGeneratorDependentSimple<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[Pure]
			get => m_dependedRandomGenerator;
			set => m_dependedRandomGenerator = value;
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
			return BatesDistribution.Generate(m_dependedRandomGenerator, m_iids);
		}
	}
}
