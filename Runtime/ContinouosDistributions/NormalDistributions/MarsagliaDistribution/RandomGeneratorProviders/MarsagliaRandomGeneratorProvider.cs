// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Provider",
		fileName = "Marsaglia Random Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaRandomGeneratorProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private MarsagliaRandomGenerator m_MarsagliaRandomGenerator;
#pragma warning restore CS0649

		public override IContinuousRandomGenerator randomGenerator =>
			new MarsagliaRandomGenerator(m_MarsagliaRandomGenerator);

		public override IContinuousRandomGenerator sharedRandomGenerator => m_MarsagliaRandomGenerator;

		public MarsagliaRandomGenerator marsagliaRandomGenerator =>
			new MarsagliaRandomGenerator(m_MarsagliaRandomGenerator);

		public MarsagliaRandomGenerator sharedMarsagliaRandomGenerator => m_MarsagliaRandomGenerator;
	}
}
