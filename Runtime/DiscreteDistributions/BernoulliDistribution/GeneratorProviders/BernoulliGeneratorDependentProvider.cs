// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		fileName = "Bernoulli Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BernoulliGeneratorDependentProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Range(0f, 1f)] private float m_P = 0.5f;
#pragma warning restore CS0649

		private BernoulliGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BernoulliGeneratorDependent{T}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BernoulliGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_P);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGeneratorDependent{T}"/> as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
		{
			[Pure]
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
		/// Creates a new <see cref="BernoulliGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public BernoulliGeneratorDependent<IContinuousGenerator> bernoulliGenerator
		{
			[Pure]
			get => new BernoulliGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_P);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BernoulliGeneratorDependent<IContinuousGenerator> sharedBernoulliGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = bernoulliGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
