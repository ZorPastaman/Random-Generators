﻿// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.ContinuousDistributions;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="GeometricGeneratorDependent{IContinuousGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GeometricDistributionFolder + "Geometric Generator Dependent Provider",
		fileName = "GeometricGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class GeometricGeneratorDependentProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1].")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Range(NumberConstants.NormalEpsilon, NumberConstants.SubOne)]
		private float m_Probability = GeometricDistribution.DefaultProbability;
		[SerializeField] private int m_StartPoint = GeometricDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		[NonSerialized] private GeometricGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="GeometricGeneratorDependent{IContinuousGenerator}"/>
		/// and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new GeometricGeneratorDependent<IContinuousGenerator>(m_DependedGeneratorProvider.generator,
				m_Probability, m_StartPoint);
		}

		/// <summary>
		/// Returns a shared <see cref="GeometricGeneratorDependent{IContinuousGenerator}"/>
		/// as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = geometricGeneratorDependent;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="GeometricGeneratorDependent{IContinuousGenerator}"/> and returns it.
		/// </summary>
		[NotNull]
		public GeometricGeneratorDependent<IContinuousGenerator> geometricGeneratorDependent
		{
			[Pure]
			get => new GeometricGeneratorDependent<IContinuousGenerator>(m_DependedGeneratorProvider.generator,
				m_Probability, m_StartPoint);
		}

		/// <summary>
		/// Returns a shared <see cref="GeometricGeneratorDependent{IContinuousGenerator}"/>.
		/// </summary>
		[NotNull]
		public GeometricGeneratorDependent<IContinuousGenerator> sharedGeometricGeneratorDependent
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = geometricGeneratorDependent;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1].
		/// </summary>
		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// True threshold in range (0, 1).
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