// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BinomialGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BinomialDistributionFolder + "Binomial Generator Simple Provider",
		fileName = "Binomial Generator Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BinomialGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private BinomialGeneratorSimple m_BinomialGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorSimple"/> and returns it
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGeneratorSimple(m_BinomialGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorSimple"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get => m_BinomialGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BinomialGeneratorSimple binomialGenerator
		{
			[Pure]
			get => new BinomialGeneratorSimple(m_BinomialGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BinomialGeneratorSimple sharedBinomialGenerator
		{
			[Pure]
			get => m_BinomialGenerator;
		}
	}
}
