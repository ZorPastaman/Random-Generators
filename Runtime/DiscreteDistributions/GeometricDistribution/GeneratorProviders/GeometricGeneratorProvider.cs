// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="GeometricGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GeometricDistributionFolder + "Geometric Generator Provider",
		fileName = "GeometricGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class GeometricGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, Range(NumberConstants.NormalEpsilon, NumberConstants.SubOne)]
		private float m_Probability = GeometricDistribution.DefaultProbability;
#pragma warning restore CS0649

		[NonSerialized] private GeometricGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="GeometricGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new GeometricGenerator(m_Probability);
		}

		/// <summary>
		/// Returns a shared <see cref="GeometricGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = geometricGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="GeometricGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public GeometricGenerator geometricGenerator
		{
			[Pure]
			get => new GeometricGenerator(m_Probability);
		}

		/// <summary>
		/// Returns a shared <see cref="GeometricGenerator"/>.
		/// </summary>
		[NotNull]
		public GeometricGenerator sharedGeometricGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = geometricGenerator;
				}

				return m_sharedGenerator;
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
