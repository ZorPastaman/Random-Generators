// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
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
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BinomialGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Range(0f, NumberConstants.SubOne)]
		private float m_Probability = BinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_UpperBound = BinomialDistribution.DefaultUpperBound;
#pragma warning restore CS0649

		[NonSerialized] private BinomialGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorSimple"/> and returns it
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGeneratorSimple(m_Probability, m_UpperBound);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorSimple"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = binomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BinomialGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public BinomialGeneratorSimple binomialGenerator
		{
			[Pure]
			get => new BinomialGeneratorSimple(m_Probability, m_UpperBound);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public BinomialGeneratorSimple sharedBinomialGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = binomialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// True threshold in range [0, 1).
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

		public byte upperBound
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_UpperBound;
			set
			{
				if (m_UpperBound == value)
				{
					return;
				}

				m_UpperBound = value;
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
