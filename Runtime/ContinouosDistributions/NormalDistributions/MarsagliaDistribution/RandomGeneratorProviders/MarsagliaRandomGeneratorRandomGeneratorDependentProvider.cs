// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Random Generator Depended Provider",
		fileName = "Marsaglia Random Generator Random Generator Depended Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaRandomGeneratorRandomGeneratorDependentProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGenerator;
		[SerializeField] private float m_Mean;
		[SerializeField] private float m_Deviation;
#pragma warning restore CS0649

		private MarsagliaRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> m_sharedRandomGenerator;

		public override IContinuousRandomGenerator randomGenerator =>
			new MarsagliaRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator, m_Mean, m_Deviation);

		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = marsagliaRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}

		public MarsagliaRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> marsagliaRandomGenerator =>
			new MarsagliaRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator, m_Mean, m_Deviation);

		public MarsagliaRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>
			sharedMarsagliaRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = marsagliaRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}
	}
}
