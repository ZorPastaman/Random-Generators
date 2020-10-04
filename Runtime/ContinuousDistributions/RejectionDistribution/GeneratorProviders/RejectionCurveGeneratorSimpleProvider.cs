// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="RejectionCurveGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.RejectionDistributionFolder + "Rejection Curve Generator Simple Provider",
		fileName = "Rejection Curve Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class RejectionCurveGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField,
		Tooltip("X - generated value\nY - its probability\nAt least one point must have possibility 1.")]
		private AnimationCurve m_ProbabilityCurve;
#pragma warning restore CS0649

		[NonSerialized] private RejectionCurveGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="RejectionCurveGeneratorSimple"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new RejectionCurveGeneratorSimple(m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared <see cref="RejectionCurveGeneratorSimple"/>
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
		/// Creates a new <see cref="RejectionCurveGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public RejectionCurveGeneratorSimple rejectionGenerator
		{
			[Pure]
			get => new RejectionCurveGeneratorSimple(m_ProbabilityCurve);
		}

		/// <summary>
		/// Returns a shared <see cref="RejectionCurveGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public RejectionCurveGeneratorSimple sharedRejectionGenerator
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
