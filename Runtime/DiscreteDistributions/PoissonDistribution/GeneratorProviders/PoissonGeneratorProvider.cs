// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		fileName = "Poisson Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class PoissonGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Lambda = PoissonDistribution.DefaultLambda;
		[SerializeField] private int m_StartPoint = PoissonDistribution.DefaultStartPoint;
#pragma warning restore CS0649

		private PoissonGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="PoissonGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new PoissonGenerator(m_Lambda, m_StartPoint);
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
			get => new PoissonGenerator(m_Lambda, m_StartPoint);
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

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
