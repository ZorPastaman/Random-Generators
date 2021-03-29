// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="ExponentialGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExponentialDistributionFolder + "Exponential Generator Provider",
		fileName = "ExponentialGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class ExponentialGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Must be non-zero.")]
		private float m_Lambda = ExponentialDistribution.DefaultLambda;
#pragma warning restore CS0649

		private ExponentialGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="ExponentialGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => exponentialGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="ExponentialGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedExponentialGenerator;

		/// <summary>
		/// Creates a new <see cref="ExponentialGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public ExponentialGenerator exponentialGenerator
		{
			[Pure]
			get => new ExponentialGenerator(m_Lambda);
		}

		/// <summary>
		/// Returns a shared <see cref="ExponentialGenerator"/>.
		/// </summary>
		[NotNull]
		public ExponentialGenerator sharedExponentialGenerator
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
