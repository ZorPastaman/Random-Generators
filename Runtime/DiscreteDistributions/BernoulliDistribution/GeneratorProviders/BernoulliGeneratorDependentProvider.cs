// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BernoulliGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BernoulliDistributionFolder + "Bernoulli Generator Dependent Provider",
		fileName = "BernoulliGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BernoulliGeneratorDependentProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1).")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Range(0f, 1f)] private float m_Probability = BernoulliDistribution.DefaultProbability;
#pragma warning restore CS0649

		private BernoulliGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BernoulliGeneratorDependent{T}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => bernoulliGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGeneratorDependent{T}"/> as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator => sharedBernoulliGenerator;

		/// <summary>
		/// Creates a new <see cref="BernoulliGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BernoulliGeneratorDependent<IContinuousGenerator> bernoulliGenerator
		{
			[Pure]
			get => new BernoulliGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Probability);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BernoulliGeneratorDependent<IContinuousGenerator> sharedBernoulliGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = bernoulliGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
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
