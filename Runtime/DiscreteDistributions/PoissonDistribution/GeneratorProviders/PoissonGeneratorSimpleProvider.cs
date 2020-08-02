// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="PoissonGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PoissonDistributionFolder + "Poisson Generator Simple Provider",
		fileName = "Poisson Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class PoissonGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private PoissonGeneratorSimple m_PoissonGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorSimple"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGeneratorSimple(m_PoissonGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorSimple"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get => m_PoissonGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGeneratorSimple poissonGenerator
		{
			[Pure]
			get => new PoissonGeneratorSimple(m_PoissonGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public PoissonGeneratorSimple sharedPoissonGenerator
		{
			[Pure]
			get => m_PoissonGenerator;
		}
	}
}
