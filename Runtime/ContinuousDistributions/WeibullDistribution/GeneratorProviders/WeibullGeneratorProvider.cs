// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="WeibullGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.WeibullDistributionFolder + "Weibull Generator Provider",
		fileName = "WeibullGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class WeibullGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Shape. Must be non-zero.")]
		private float m_Alpha = WeibullDistribution.DefaultAlpha;
		[SerializeField, Tooltip("Scale.")]
		private float m_Beta = WeibullDistribution.DefaultBeta;
#pragma warning restore CS0649

		private WeibullGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="WeibullGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => weibullGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="WeibullGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedWeibullGenerator;

		/// <summary>
		/// Creates a new <see cref="WeibullGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public WeibullGenerator weibullGenerator
		{
			[Pure]
			get => new WeibullGenerator(m_Alpha, m_Beta);
		}

		/// <summary>
		/// Returns a shared <see cref="WeibullGenerator"/>.
		/// </summary>
		[NotNull]
		public WeibullGenerator sharedWeibullGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = weibullGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Shape. Mustn't be zero.
		/// </summary>
		public float alpha
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Alpha;
			set
			{
				if (m_Alpha == value)
				{
					return;
				}

				m_Alpha = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// Scale.
		/// </summary>
		public float beta
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Beta;
			set
			{
				if (m_Beta == value)
				{
					return;
				}

				m_Beta = value;
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
