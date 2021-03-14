// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BernoulliGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BernoulliDistributionFolder + "Bernoulli Generator Provider",
		fileName = "BernoulliGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BernoulliGeneratorProvider : DiscreteGeneratorProvider<bool>
	{
#pragma warning disable CS0649
		[SerializeField, Range(0f, 1f)] private float m_Probability = BernoulliDistribution.DefaultProbability;
#pragma warning restore CS0649

		[NonSerialized] private BernoulliGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BernoulliGenerator"/> and returns it as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> generator
		{
			[Pure]
			get => new BernoulliGenerator(m_Probability);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGenerator"/> as <see cref="IDiscreteGenerator{Boolean}"/>.
		/// </summary>
		public override IDiscreteGenerator<bool> sharedGenerator
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
		/// Creates a new <see cref="BernoulliGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BernoulliGenerator bernoulliGenerator
		{
			[Pure]
			get => new BernoulliGenerator(m_Probability);
		}

		/// <summary>
		/// Returns a shared <see cref="BernoulliGenerator"/>.
		/// </summary>
		[NotNull]
		public BernoulliGenerator sharedBernoulliGenerator
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
