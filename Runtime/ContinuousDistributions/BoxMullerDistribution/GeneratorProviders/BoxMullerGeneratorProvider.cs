// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Generator Provider",
		fileName = "Box-Muller Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoxMullerGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = BoxMullerDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BoxMullerDistribution.DefaultDeviation;
#pragma warning disable CS0649

		private BoxMullerGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoxMullerGenerator"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BoxMullerGenerator(m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = boxMullerGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="BoxMullerGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerGenerator boxMullerGenerator
		{
			[Pure]
			get => new BoxMullerGenerator(m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGenerator"/>.
		/// </summary>
		[NotNull]
		public BoxMullerGenerator sharedBoxMullerGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = boxMullerGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public float mean
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Mean;
			set
			{
				if (m_Mean == value)
				{
					return;
				}

				m_Mean = value;
				m_sharedGenerator = null;
			}
		}

		public float deviation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Deviation;
			set
			{
				if (m_Deviation == value)
				{
					return;
				}

				m_Deviation = value;
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
