// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Random Generator Random Generator Dependent Provider",
		fileName = "Box-Muller Random Generator Random Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoxMullerRandomGeneratorRandomGeneratorDependentProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGeneratorProvider;
		[SerializeField] private float m_Mean = BoxMullerDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BoxMullerDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private BoxMullerRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> m_sharedRandomGenerator;

		/// <summary>
		/// Creates a new <see cref="BoxMullerRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new BoxMullerRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGeneratorProvider.randomGenerator, m_Mean, m_Deviation);

		/// <summary>
		/// Returns a shared <see cref="BoxMullerRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator}"/>
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
		/// Creates a new <see cref="BoxMullerRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator}"/>
		/// and returns it.
		/// </summary>
		public BoxMullerRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> boxMullerRandomGenerator =>
			new BoxMullerRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGeneratorProvider.randomGenerator, m_Mean, m_Deviation);

		/// <summary>
		/// Returns a shared <see cref="BoxMullerRandomGeneratorRandomGeneratorDependent{IContinuousRandomGenerator}"/>.
		/// </summary>
		public BoxMullerRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>
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
