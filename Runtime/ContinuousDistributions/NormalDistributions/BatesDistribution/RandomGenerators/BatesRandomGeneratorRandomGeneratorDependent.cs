// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Bates Random Generator using <see cref="BatesDistribution.Generate{T}(T,float,float,byte)"/>.
	/// </summary>
	public sealed class BatesRandomGeneratorRandomGeneratorDependent<T> : IBatesRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;
		private float m_mean;
		private float m_deviation;
		private byte m_iids;

		/// <summary>
		/// Creates a <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedRandomGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesRandomGeneratorRandomGeneratorDependent([NotNull] T dependedRandomGenerator,
			float mean, float deviation, byte iids = BatesDistribution.DefaultIids)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
			m_mean = mean;
			m_deviation = deviation;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BatesRandomGeneratorRandomGeneratorDependent(
			[NotNull] BatesRandomGeneratorRandomGeneratorDependent<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
			m_mean = other.m_mean;
			m_deviation = other.m_deviation;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			get => m_dependedRandomGenerator;
			set => m_dependedRandomGenerator = value;
		}

		public float mean
		{
			get => m_mean;
			set => m_mean = value;
		}

		public float deviation
		{
			get => m_deviation;
			set => m_deviation = value;
		}

		/// <inheritdoc/>
		public byte iids
		{
			get => m_iids;
			set => m_iids = value;
		}

		/// <inheritdoc/>
		public float Generate()
		{
			return BatesDistribution.Generate(m_dependedRandomGenerator, m_mean, m_deviation, m_iids);
		}
	}
}
