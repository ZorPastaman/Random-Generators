// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
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
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		/// <param name="iids">
		/// How many independent and identically distributed random variables are generated.
		/// </param>
		public BatesGeneratorDependent([NotNull] T dependedGenerator,
			float mean, float deviation, byte iids = BatesDistribution.DefaultIids)
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
			get => m_mean;
			set => m_mean = value;
		}

		public float deviation
		{
			[Pure]
			get => m_deviation;
			set => m_deviation = value;
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
			return BatesDistribution.Generate(m_dependedGenerator, m_mean, m_deviation, m_iids);
		}
	}
}
