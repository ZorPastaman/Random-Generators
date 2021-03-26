// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="PoissonGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PoissonDistributionFolder + "Poisson Generator Provider",
		fileName = "PoissonGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class PoissonGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Lambda = PoissonDistribution.DefaultLambda;
#pragma warning restore CS0649

		[NonSerialized] private PoissonGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="PoissonGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGenerator(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
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
		/// Creates a new <see cref="PoissonGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGenerator poissonGenerator
		{
			[Pure]
			get => new PoissonGenerator(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGenerator"/>.
		/// </summary>
		[NotNull]
		public PoissonGenerator sharedPoissonGenerator
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
