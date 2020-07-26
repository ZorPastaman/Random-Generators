// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Marsaglia Random Generator using <see cref="MarsagliaDistribution.Generate()"/>.
	/// </summary>
	[Serializable]
	public sealed class MarsagliaGeneratorSimple : IMarsagliaGenerator
	{
		private float m_spared;
		private bool m_hasSpared;

		public float mean
		{
			[Pure]
			get => MarsagliaDistribution.DefaultMean;
		}

		public float deviation
		{
			[Pure]
			get => MarsagliaDistribution.DefaultDeviation;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = MarsagliaDistribution.Generate();
			m_hasSpared = true;

			return answer;
		}
	}
}
