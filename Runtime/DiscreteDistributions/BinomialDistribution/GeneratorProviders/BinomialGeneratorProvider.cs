// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BinomialGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BinomialDistributionFolder + "Binomial Generator Provider",
		fileName = "Binomial Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BinomialGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private BinomialGenerator m_BinomialGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BinomialGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGenerator(m_BinomialGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get => m_BinomialGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BinomialGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BinomialGenerator binomialGenerator
		{
			[Pure]
			get => new BinomialGenerator(m_BinomialGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGenerator"/>.
		/// </summary>
		[NotNull]
		public BinomialGenerator sharedBinomialGenerator
		{
			[Pure]
			get => m_BinomialGenerator;
		}
	}
}
