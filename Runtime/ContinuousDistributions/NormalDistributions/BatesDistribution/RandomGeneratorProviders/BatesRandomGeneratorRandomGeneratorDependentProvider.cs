// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Random Generator Random Generator Dependent Provider",
		fileName = "Bates Random Generator Random Generator Dependent Provider",
		order = 446
	)]
	public sealed class BatesRandomGeneratorRandomGeneratorDependentProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGeneratorProvider;
		[SerializeField] private float m_Mean = BatesDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BatesDistribution.DefaultDeviation;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		private BatesRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new BatesRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGeneratorProvider.randomGenerator, m_Mean, m_Deviation, m_Iids);

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> batesRandomGenerator =>
			new BatesRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGeneratorProvider.randomGenerator, m_Mean, m_Deviation, m_Iids);

		/// <summary>
		/// Returns a shared <see cref="BatesRandomGeneratorRandomGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BatesRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> sharedBatesRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
