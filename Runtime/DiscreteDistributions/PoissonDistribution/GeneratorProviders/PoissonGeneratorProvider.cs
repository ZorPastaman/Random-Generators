// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="PoissonGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PoissonDistributionFolder + "Poisson Generator Provider",
		fileName = "Poisson Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class PoissonGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private PoissonGenerator m_PoissonGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="PoissonGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGenerator(m_PoissonGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get => m_PoissonGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="PoissonGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGenerator poissonGenerator
		{
			[Pure]
			get => new PoissonGenerator(m_PoissonGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGenerator"/>.
		/// </summary>
		[NotNull]
		public PoissonGenerator sharedPoissonGenerator
		{
			[Pure]
			get => m_PoissonGenerator;
		}
	}
}
