// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="BinomialGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BinomialDistributionFolder + "Binomial Generator Provider",
		fileName = "BinomialGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BinomialGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Range(0f, NumberConstants.SubOne)]
		private float m_Probability = BinomialDistribution.DefaultProbability;
		[SerializeField] private byte m_UpperBound = BinomialDistribution.DefaultUpperBound;
#pragma warning restore CS0649

		[NonSerialized] private BinomialGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BinomialGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new BinomialGenerator(m_Probability, m_UpperBound);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
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
		/// Creates a new <see cref="BinomialGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BinomialGenerator binomialGenerator
		{
			[Pure]
			get => new BinomialGenerator(m_Probability, m_UpperBound);
		}

		/// <summary>
		/// Returns a shared <see cref="BinomialGenerator"/>.
		/// </summary>
		[NotNull]
		public BinomialGenerator sharedBinomialGenerator
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
