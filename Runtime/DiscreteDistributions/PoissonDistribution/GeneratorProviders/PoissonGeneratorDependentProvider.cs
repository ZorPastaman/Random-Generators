// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="PoissonGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PoissonDistributionFolder + "Poisson Generator Dependent Provider",
		fileName = "Poisson Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class PoissonGeneratorDependentProvider : DiscreteGeneratorProvider<uint>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependentGeneratorProvider;
		[SerializeField] private float m_Lambda;
#pragma warning restore CS0649

		private PoissonGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorDependent{T}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<uint> generator
		{
			[Pure]
			get => new PoissonGeneratorDependent<IContinuousGenerator>(
				m_DependentGeneratorProvider.generator, m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorDependent{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<uint> sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = poissonGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGeneratorDependent<IContinuousGenerator> poissonGenerator
		{
			[Pure]
			get => new PoissonGeneratorDependent<IContinuousGenerator>(
				m_DependentGeneratorProvider.generator, m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorDependent{T}"/>.
		/// </summary>
		public PoissonGeneratorDependent<IContinuousGenerator> sharedPoissonGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = poissonGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
