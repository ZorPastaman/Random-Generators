// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaRandomGenerator"/>.
	/// </summary>
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

		/// <summary>
		/// Creates a new <see cref="MarsagliaRandomGenerator"/> and returns it
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new MarsagliaRandomGenerator(m_MarsagliaRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="MarsagliaRandomGenerator"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_MarsagliaRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="MarsagliaRandomGenerator"/> and returns it.
		/// </summary>
		public MarsagliaRandomGenerator marsagliaRandomGenerator =>
			new MarsagliaRandomGenerator(m_MarsagliaRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="MarsagliaRandomGenerator"/>.
		/// </summary>
		public MarsagliaRandomGenerator sharedMarsagliaRandomGenerator => m_MarsagliaRandomGenerator;
	}
}
