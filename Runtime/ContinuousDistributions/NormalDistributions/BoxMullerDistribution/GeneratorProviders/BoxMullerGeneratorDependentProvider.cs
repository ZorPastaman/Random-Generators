// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Generator Dependent Provider",
		fileName = "Box-Muller Generator Dependent Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoxMullerGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Mean = BoxMullerDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BoxMullerDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private BoxMullerGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoxMullerGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BoxMullerGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = boxMullerGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BoxMullerGeneratorDependent{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorDependent<IContinuousGenerator> boxMullerGenerator
		{
			[Pure]
			get => new BoxMullerGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorDependent<IContinuousGenerator>
			sharedBoxMullerGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = boxMullerGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
