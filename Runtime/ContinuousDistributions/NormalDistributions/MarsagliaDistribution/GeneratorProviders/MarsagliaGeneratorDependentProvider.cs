// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Generator Depended Provider",
		fileName = "Marsaglia Generator Depended Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class MarsagliaGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGenerator;
		[SerializeField] private float m_Mean;
		[SerializeField] private float m_Deviation;
#pragma warning restore CS0649

		private MarsagliaGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="MarsagliaGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new MarsagliaGeneratorDependent<IContinuousGenerator>(
				m_DependedGenerator.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = marsagliaGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="MarsagliaGeneratorDependent{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public MarsagliaGeneratorDependent<IContinuousGenerator> marsagliaGenerator
		{
			[Pure]
			get => new MarsagliaGeneratorDependent<IContinuousGenerator>(
				m_DependedGenerator.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public MarsagliaGeneratorDependent<IContinuousGenerator> sharedMarsagliaGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = marsagliaGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
