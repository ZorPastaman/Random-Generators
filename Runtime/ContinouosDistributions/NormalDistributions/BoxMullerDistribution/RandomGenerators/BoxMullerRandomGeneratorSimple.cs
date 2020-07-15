// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Box-Muller Random Generator using <see cref="BoxMullerDistribution.Generate()"/>.
	/// </summary>
	public sealed class BoxMullerRandomGeneratorSimple : IBoxMullerRandomGenerator
	{
		private float m_spared;
		private bool m_hasSpared;

		public float mean => BoxMullerDistribution.DefaultMean;

		public float deviation => BoxMullerDistribution.DefaultDeviation;

		/// <inheritdoc/>
		public float Generate()
		{
			if (m_hasSpared)
			{
				m_hasSpared = false;
				return m_spared;
			}

			float answer;
			(answer, m_spared) = BoxMullerDistribution.Generate();
			m_hasSpared = true;

			return answer;
		}
	}
}
