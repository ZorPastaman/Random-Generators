// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="NormalGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NormalDistributionFolder + "Normal Generator Provider",
		fileName = "NormalGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NormalGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Mean = NormalDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = NormalDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private NormalGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NormalGenerator"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => normalGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="NormalGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedNormalGenerator;

		/// <summary>
		/// Creates a new <see cref="NormalGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public NormalGenerator normalGenerator
		{
			[Pure]
			get => new NormalGenerator(m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="NormalGenerator"/>.
		/// </summary>
		[NotNull]
		public NormalGenerator sharedNormalGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = normalGenerator;
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
