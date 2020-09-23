// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Generator Dependent Provider",
		fileName = "Box-Muller Generator Dependent Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoxMullerGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Mean = BoxMullerDistribution.DefaultMean;
		[SerializeField] private float m_Deviation = BoxMullerDistribution.DefaultDeviation;
#pragma warning restore CS0649

		private BoxMullerGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="BoxMullerGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BoxMullerGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGeneratorDependent{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
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
		/// Creates a new <see cref="BoxMullerGeneratorDependent{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorDependent<IContinuousGenerator> boxMullerGenerator
		{
			[Pure]
			get => new BoxMullerGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Mean, m_Deviation);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorDependent<IContinuousGenerator> sharedBoxMullerGenerator
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

		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
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

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
