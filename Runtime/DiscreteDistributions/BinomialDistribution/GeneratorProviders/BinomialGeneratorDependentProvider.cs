// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BinomialGeneratorDependent{IContinuousGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BinomialDistributionFolder + "Binomial Generator Dependent Provider",
		fileName = "Binomial Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BinomialGeneratorDependentProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGenerator;
		[SerializeField] private int m_StartPoint = BinomialDistribution.DefaultStartPoint;
		[SerializeField, Range(0f, 1f)] private float m_P;
		[SerializeField] private byte m_N;
#pragma warning restore CS0649

		private BinomialGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorDependent{IContinuousGenerator}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGeneratorDependent<IContinuousGenerator>(
				m_DependedGenerator.generator, m_StartPoint, m_P, m_N);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorDependent{IContinuousGenerator}"/>
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = binomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorDependent{IContinuousGenerator}"/> and returns it.
		/// </summary>
		[NotNull]
		public BinomialGeneratorDependent<IContinuousGenerator> binomialGenerator
		{
			[Pure]
			get => new BinomialGeneratorDependent<IContinuousGenerator>(
				m_DependedGenerator.generator, m_StartPoint, m_P, m_N);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorDependent{IContinuousGenerator}"/>.
		/// </summary>
		[NotNull]
		public BinomialGeneratorDependent<IContinuousGenerator> sharedBinomialGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = binomialGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
