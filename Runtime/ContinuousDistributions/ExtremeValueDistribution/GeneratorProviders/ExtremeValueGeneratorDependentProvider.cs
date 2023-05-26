// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions.GeneratorProviders
{
	/// <summary>
	/// Provides <see cref="ExtremeValueGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeValueDistributionFolder + "Extreme Value Generator Dependent Provider",
		fileName = "ExtremeValueGeneratorDependentProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class ExtremeValueGeneratorDependentProvider : ContinuousGeneratorProvider
	{
		[SerializeField, Tooltip("Random generator that returns an independent and identically distributed random value in range [0, 1).")]
		private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Location = ExtremeValueDistribution.DefaultLocation;
		[SerializeField, SimpleRangeFloat(NumberConstants.NormalEpsilon, float.MaxValue)]
		private float m_Scale = ExtremeValueDistribution.DefaultScale;

		private ExtremeValueGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="ExtremeValueGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => extremeValueGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeValueGeneratorDependent{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedExtremeValueGenerator;

		/// <summary>
		/// Creates a new <see cref="ExtremeValueGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public ExtremeValueGeneratorDependent<IContinuousGenerator> extremeValueGenerator
		{
			[Pure]
			get => new(m_DependedGeneratorProvider.generator, m_Location, m_Scale);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeValueGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public ExtremeValueGeneratorDependent<IContinuousGenerator> sharedExtremeValueGenerator =>
			m_sharedGenerator ??= extremeValueGenerator;

		/// <summary>
		/// Random generator that returns an independent and identically distributed random value in range [0, 1).
		/// </summary>
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

		public float location
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Location;
			set
			{
				if (m_Location == value)
				{
					return;
				}

				m_Location = value;
				m_sharedGenerator = null;
			}
		}

		/// <remarks>Must be more than 0.</remarks>
		public float scale
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Scale;
			set
			{
				if (m_Scale == value)
				{
					return;
				}

				m_Scale = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
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
