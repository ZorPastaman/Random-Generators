// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Dependent Provider",
		fileName = "Bates Generator Dependent Provider",
		order = 446
	)]
	public sealed class BatesGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Mean = BatesDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BatesDistribution.DefaultDeviation;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = BatesDistribution.DefaultIids;
#pragma warning restore CS0649

		private BatesGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BatesGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGeneratorDependent<IContinuousGenerator> batesGenerator
		{
			[Pure]
			get => new BatesGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BatesGeneratorDependent<IContinuousGenerator> sharedBatesGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = batesGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
