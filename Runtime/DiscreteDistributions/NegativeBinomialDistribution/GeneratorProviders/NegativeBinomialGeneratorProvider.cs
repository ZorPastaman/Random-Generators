// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="NegativeBinomialGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NegativeBinomialDistributionFolder + "Negative Binomial Generator Provider",
		fileName = "NegativeBinomialGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NegativeBinomialGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Range(NumberConstants.NormalEpsilon, 1f)]
		private float m_Probability = NegativeBinomialDistribution.DefaultProbability;
		[SerializeField, SimpleRangeInt(1, 255)]
		private byte m_Successes = NegativeBinomialDistribution.DefaultSuccesses;
#pragma warning restore CS0649

		private NegativeBinomialGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGenerator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => negativeBinomialGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGenerator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedNegativeBinomialGenerator;

		/// <summary>
		/// Creates a new <see cref="NegativeBinomialGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public NegativeBinomialGenerator negativeBinomialGenerator
		{
			[Pure]
			get => new NegativeBinomialGenerator(m_Probability, m_Successes);
		}

		/// <summary>
		/// Returns a shared <see cref="NegativeBinomialGenerator"/>.
		/// </summary>
		[NotNull]
		public NegativeBinomialGenerator sharedNegativeBinomialGenerator
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
