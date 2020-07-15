// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Random Generator Random Generator Dependent Simple Provider",
		fileName = "Box-Muller Random Generator Random Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoxMullerRandomGeneratorRandomGeneratorDependentSimpleProvider : ContinuousRandomGeneratorProvider
	{
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGeneratorProvider;

		private BoxMullerRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			m_sharedRandomGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="BoxMullerRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new BoxMullerRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_DependedRandomGeneratorProvider.randomGenerator);

		/// <summary>
		/// Returns a shared
		/// <see cref="BoxMullerRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = boxMullerRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}

		/// <summary>
		/// Creates a new
		/// <see cref="BoxMullerRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// and returns it.
		/// </summary>
		public BoxMullerRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			boxMullerRandomGenerator =>
			new BoxMullerRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
				m_DependedRandomGeneratorProvider.randomGenerator);

		/// <summary>
		/// Returns a shared
		/// <see cref="BoxMullerRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>.
		/// </summary>
		public BoxMullerRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			sharedBoxMullerRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = boxMullerRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}
	}
}
