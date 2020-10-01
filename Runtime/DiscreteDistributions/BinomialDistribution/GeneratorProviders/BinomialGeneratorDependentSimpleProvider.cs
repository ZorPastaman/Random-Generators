// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BinomialGeneratorDependentSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Range(0f, 1f)] private float m_Probability = BinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_UpperBound = BinomialDistribution.DefaultUpperBound;
#pragma warning restore CS0649

		private BinomialGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGeneratorDependentSimple<IContinuousGenerator>(m_DependedGeneratorProvider.generator,
				m_Probability, m_UpperBound);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
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
			get => new BinomialGeneratorDependentSimple<IContinuousGenerator>(m_DependedGeneratorProvider.generator,
				m_Probability, m_UpperBound);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorDependentSimple{IContinuousGenerator}"/>.
		/// </summary>
		[NotNull]
		public BinomialGeneratorDependentSimple<IContinuousGenerator> sharedBinomialGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = binomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// True threshold in range [0, 1].
		/// </summary>
		public float probability
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Probability;
			set
			{
				if (m_Probability == value)
				{
					return;
				}

				m_Probability = value;
				m_sharedGenerator = null;
			}
		}

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_UpperBound;
			set
			{
				if (m_UpperBound == value)
				{
					return;
				}

				m_UpperBound = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
