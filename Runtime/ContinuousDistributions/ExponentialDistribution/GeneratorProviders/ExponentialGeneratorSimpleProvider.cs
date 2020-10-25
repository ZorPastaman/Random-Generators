// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="ExponentialGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExponentialDistributionFolder + "Exponential Generator Simple Provider",
		fileName = "Exponential Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class ExponentialGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Mustn't be zero.")]
		private float m_Lambda = ExponentialDistribution.DefaultLambda;
#pragma warning restore CS0649

		[NonSerialized] private ExponentialGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="ExponentialGeneratorSimple"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new ExponentialGeneratorSimple(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="ExponentialGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = exponentialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="ExponentialGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public ExponentialGeneratorSimple exponentialGenerator
		{
			[Pure]
			get => new ExponentialGeneratorSimple(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="ExponentialGenerator"/>.
		/// </summary>
		[NotNull]
		public ExponentialGeneratorSimple sharedExponentialGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = exponentialGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Lambda. Mustn't be zero.
		/// </summary>
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
