// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides
	/// <see cref="RejectionCurveGeneratorDependent{TValue,TCheck}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RejectionDistributionFolder +
			"Rejection Curve Generator Dependent Provider",
		fileName = "Rejection Curve Generator Dependent Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class RejectionCurveGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_ValueGeneratorProvider;
		[SerializeField] private ContinuousGeneratorProviderReference m_CheckGeneratorProvider;
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		[NonSerialized] private RejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>
			m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="RejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new RejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>(
				m_ValueGeneratorProvider.generator, m_CheckGeneratorProvider.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="RejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
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

		/// <summary>
		/// Creates a new
		/// <see cref="RejectionCurveGeneratorDependent{TValue,TCheck}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public RejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator> rejectionGenerator
		{
			[Pure]
			get => new RejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator>(
				m_ValueGeneratorProvider.generator, m_CheckGeneratorProvider.generator, m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="RejectionCurveGeneratorDependent{TValue,TCheck}"/>.
		/// </summary>
		[NotNull]
		public RejectionCurveGeneratorDependent<IContinuousGenerator, IContinuousGenerator> sharedRejectionGenerator
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

		public ContinuousGeneratorProviderReference checkGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_CheckGeneratorProvider;
			set
			{
				if (m_CheckGeneratorProvider == value)
				{
					return;
				}

				m_CheckGeneratorProvider = value;
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
