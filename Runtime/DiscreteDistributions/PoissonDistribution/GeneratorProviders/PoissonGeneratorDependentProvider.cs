// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="PoissonGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.PoissonDistributionFolder + "Poisson Generator Dependent Provider",
		fileName = "Poisson Generator Dependent Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class PoissonGeneratorDependentProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependentGeneratorProvider;
		[SerializeField] private float m_Lambda = PoissonDistribution.DefaultLambda;
		[SerializeField] private int m_StartPoint = PoissonDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		[NonSerialized] private PoissonGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="PoissonGeneratorDependent{T}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGeneratorDependent<IContinuousGenerator>(
				m_DependentGeneratorProvider.generator, m_Lambda, m_StartPoint);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorDependent{T}"/>
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
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
		/// Creates a new <see cref="PoissonGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public PoissonGeneratorDependent<IContinuousGenerator> poissonGenerator
		{
			[Pure]
			get => new PoissonGeneratorDependent<IContinuousGenerator>(
				m_DependentGeneratorProvider.generator, m_Lambda, m_StartPoint);
		}

		/// <summary>
		/// Returns a shared <see cref="PoissonGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public PoissonGeneratorDependent<IContinuousGenerator> sharedPoissonGenerator
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

		public ContinuousGeneratorProviderReference dependentGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependentGeneratorProvider;
			set
			{
				if (m_DependentGeneratorProvider == value)
				{
					return;
				}

				m_DependentGeneratorProvider = value;
				m_sharedGenerator = null;
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

		public int startPoint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_StartPoint;
			set
			{
				if (m_StartPoint == value)
				{
					return;
				}

				m_StartPoint = value;
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
