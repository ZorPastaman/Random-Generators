// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class PoissonGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Lambda = PoissonDistribution.DefaultLambda;
#pragma warning restore CS0649

		private PoissonGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorSimple"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGeneratorSimple(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorSimple"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = poissonGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGeneratorSimple poissonGenerator
		{
			[Pure]
			get => new PoissonGeneratorSimple(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public PoissonGeneratorSimple sharedPoissonGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = poissonGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public float lambda
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Lambda;
			set
			{
				if (m_Lambda == value)
				{
					return;
				}

				m_Lambda = value;
				m_sharedGenerator = null;
			}
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
