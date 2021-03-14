// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="NegativeBinomialGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NegativeBinomialDistributionFolder +
			"Negative Binomial Generator Simple Provider",
		fileName = "NegativeBinomialGeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NegativeBinomialGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Range(NumberConstants.NormalEpsilon, 1f)]
		private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField, SimpleRangeInt(1, 255)]
		private byte m_Successes = NegativeBinomialDistribution.DefaultSuccesses;
#pragma warning restore CS0649

		[NonSerialized] private NegativeBinomialGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGeneratorSimple"/> and returns it
		/// as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new NegativeBinomialGeneratorSimple(m_Probability, m_Successes);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorSimple"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = negativeBinomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorSimple negativeBinomialGenerator
		{
			[Pure]
			get => new NegativeBinomialGeneratorSimple(m_Probability, m_Successes);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public NegativeBinomialGeneratorSimple sharedNegativeBinomialGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = negativeBinomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// True threshold in range (0, 1].
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

		/// <remarks>
		/// <paramref name="value"/> must be greater than 0.
		/// </remarks>
		public byte successes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Successes;
			set
			{
				if (m_Successes == value)
				{
					return;
				}

				m_Successes = value;
				m_sharedGenerator = null;
			}
		}

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
