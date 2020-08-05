// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BinomialDistributionFolder + "Binomial Generator Dependent Simple Provider",
		fileName = "Binomial Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BinomialGeneratorDependentSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGenerator;
		[SerializeField, Range(0f, 1f)] private float m_P;
		[SerializeField] private byte m_N;
#pragma warning restore CS0649

		private BinomialGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGeneratorDependentSimple<IContinuousGenerator>(m_DependedGenerator.generator, m_P, m_N);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>
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
		/// Creates a new <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/> and returns it.
		/// </summary>
		[NotNull]
		public BinomialGeneratorDependentSimple<IContinuousGenerator> binomialGenerator
		{
			[Pure]
			get => new BinomialGeneratorDependentSimple<IContinuousGenerator>(m_DependedGenerator.generator, m_P, m_N);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>.
		/// </summary>
		[NotNull]
		public BinomialGeneratorDependentSimple<IContinuousGenerator> sharedBinomialGenerator
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
