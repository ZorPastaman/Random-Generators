// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Random Generator Depended Simple Provider",
		fileName = "Marsaglia Random Generator Random Generator Depended Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaRandomGeneratorRandomGeneratorDependentSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGenerator;
#pragma warning restore CS0649

		private MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			m_sharedRandomGenerator;

		public override IContinuousRandomGenerator randomGenerator =>
			new MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator);

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

		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			marsagliaRandomGenerator =>
			new MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator);

		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
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
