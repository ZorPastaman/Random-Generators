// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Simple Provider",
		fileName = "Marsaglia Random Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaRandomGeneratorSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private MarsagliaRandomGeneratorSimple m_MarsagliaRandomGenerator;
#pragma warning restore CS0649

		public override IContinuousRandomGenerator randomGenerator => new MarsagliaRandomGeneratorSimple();

		public override IContinuousRandomGenerator sharedRandomGenerator => m_MarsagliaRandomGenerator;

		public MarsagliaRandomGeneratorSimple marsagliaRandomGenerator => new MarsagliaRandomGeneratorSimple();

		public MarsagliaRandomGeneratorSimple sharedMarsagliaRandomGenerator => m_MarsagliaRandomGenerator;
	}
}
