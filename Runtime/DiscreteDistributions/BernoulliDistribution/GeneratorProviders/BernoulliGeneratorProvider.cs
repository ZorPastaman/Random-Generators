// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BernoulliGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BernoulliDistributionFolder + "Bernoulli Generator Provider",
		fileName = "Bernoulli Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BernoulliGeneratorProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField] private BernoulliGenerator m_BernoulliGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BernoulliGenerator"/> and returns it as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BernoulliGenerator(m_BernoulliGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGenerator"/> as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
		{
			[Pure]
			get => m_BernoulliGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BernoulliGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BernoulliGenerator bernoulliGenerator
		{
			[Pure]
			get => new BernoulliGenerator(m_BernoulliGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGenerator"/>.
		/// </summary>
		[NotNull]
		public BernoulliGenerator sharedBernoulliGenerator
		{
			[Pure]
			get => m_BernoulliGenerator;
		}
	}
}
