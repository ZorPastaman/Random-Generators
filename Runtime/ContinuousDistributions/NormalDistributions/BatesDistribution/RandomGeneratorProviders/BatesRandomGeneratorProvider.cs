// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesRandomGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Random Generator Provider",
		fileName = "Bates Random Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BatesRandomGeneratorProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private BatesRandomGenerator m_BatesRandomGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BatesRandomGenerator"/> and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator => new BatesRandomGenerator(m_BatesRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGenerator"/> as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator => m_BatesRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesRandomGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesRandomGenerator batesRandomGenerator => new BatesRandomGenerator(m_BatesRandomGenerator);

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGenerator"/>.
		/// </summary>
		[NotNull]
		public BatesRandomGenerator sharedBatesRandomGenerator => m_BatesRandomGenerator;
	}
}
