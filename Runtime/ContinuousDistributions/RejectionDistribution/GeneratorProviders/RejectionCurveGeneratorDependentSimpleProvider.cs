// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides
	/// <see cref="RejectionCurveGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RejectionDistributionFolder +
			"Rejection Curve Generator Dependent Simple Provider",
		fileName = "RejectionCurveGeneratorDependentSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class RejectionCurveGeneratorDependentSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_ValueGeneratorProvider;
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		private RejectionCurveGeneratorDependentSimple<IContinuousGenerator>
			m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="RejectionCurveGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => rejectionGenerator;
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="RejectionCurveGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedRejectionGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="RejectionCurveGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		[NotNull]
		public RejectionCurveGeneratorDependentSimple<IContinuousGenerator> rejectionGenerator
		{
			[Pure]
			get => new RejectionCurveGeneratorDependentSimple<IContinuousGenerator>(
				m_ValueGeneratorProvider.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="RejectionCurveGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public RejectionCurveGeneratorDependentSimple<IContinuousGenerator> sharedRejectionGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = rejectionGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public ContinuousGeneratorProviderReference valueGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ValueGeneratorProvider;
			set
			{
				if (m_ValueGeneratorProvider == value)
				{
					return;
				}

				m_ValueGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// X - generated value\nY - its probability\nAt least one point must have possibility 1.
		/// </summary>
		[NotNull]
		public AnimationCurve probabilityCurve
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ProbabilityCurve;
			set
			{
				if (m_ProbabilityCurve.Equals(value))
				{
					return;
				}

				m_ProbabilityCurve = value;
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
