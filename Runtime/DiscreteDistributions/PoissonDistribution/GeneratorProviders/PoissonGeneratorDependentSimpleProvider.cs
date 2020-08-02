// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="PoissonGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PoissonDistributionFolder + "Poisson Generator Dependent Simple Provider",
		fileName = "Poisson Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class PoissonGeneratorDependentSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependentGeneratorProvider;
		[SerializeField] private float m_Lambda;
#pragma warning restore CS0649

		private PoissonGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGeneratorDependentSimple<IContinuousGenerator>(
				m_DependentGeneratorProvider.generator, m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorDependentSimple{T}"/>
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
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
		/// Creates a new <see cref="PoissonGeneratorDependentSimple{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGeneratorDependentSimple<IContinuousGenerator> poissonGenerator
		{
			[Pure]
			get => new PoissonGeneratorDependentSimple<IContinuousGenerator>(
				m_DependentGeneratorProvider.generator, m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorDependentSimple{T}"/>.
		/// </summary>
		public PoissonGeneratorDependentSimple<IContinuousGenerator> sharedPoissonGenerator
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
