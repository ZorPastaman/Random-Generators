// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.ContinuousDistributions.GeneratorProviders
{
	/// <summary>
	/// Provides <see cref="ExtremeValueGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeValueDistributionFolder + "Extreme Value Generator Provider",
		fileName = "ExtremeValueGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class ExtremeValueGeneratorProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Location = ExtremeValueDistribution.DefaultLocation;
		[SerializeField, SimpleRangeFloat(NumberConstants.NormalEpsilon, float.MaxValue)]
		private float m_Scale = ExtremeValueDistribution.DefaultScale;

		private ExtremeValueGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="ExtremeValueGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => extremeValueGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeValueGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => sharedExtremeValueGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="ExtremeValueGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public ExtremeValueGenerator extremeValueGenerator
		{
			[Pure]
			get => new ExtremeValueGenerator(m_Location, m_Scale);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeValueGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public ExtremeValueGenerator sharedExtremeValueGenerator => m_sharedGenerator ??= extremeValueGenerator;

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
