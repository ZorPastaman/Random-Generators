// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="LittleDifferenceFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LittleDifferenceContinuousFiltersFolder + "Little Difference Filter Provider",
		fileName = "Little Difference Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LittleDifferenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_RequiredDifference = LittleDifferenceFiltering.DefaultRequiredDifference;
		[SerializeField, Tooltip("Allowed little difference sequence length.")]
		private byte m_LittleDifferenceSequenceLength = LittleDifferenceFiltering.DefaultLittleDifferenceSequenceLength;
#pragma warning restore CS0649

		private LittleDifferenceFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="LittleDifferenceFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new LittleDifferenceFilter(m_RequiredDifference, m_LittleDifferenceSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="LittleDifferenceFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = littleDifferenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="LittleDifferenceFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public LittleDifferenceFilter littleDifferenceFilter
		{
			[Pure]
			get => new LittleDifferenceFilter(m_RequiredDifference, m_LittleDifferenceSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="LittleDifferenceFilter"/>.
		/// </summary>
		[NotNull]
		public LittleDifferenceFilter sharedLittleDifferenceFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = littleDifferenceFilter;
				}

				return m_sharedFilter;
			}
		}

		public float requiredDifference
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_RequiredDifference;
			set
			{
				if (m_RequiredDifference == value)
				{
					return;
				}

				m_RequiredDifference = value;
				m_sharedFilter = null;
			}
		}

		/// <summary>
		/// Allowed little difference sequence length.
		/// </summary>
		public byte littleDifferenceSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_LittleDifferenceSequenceLength;
			set
			{
				if (m_LittleDifferenceSequenceLength == value)
				{
					return;
				}

				m_LittleDifferenceSequenceLength = value;
				m_sharedFilter = null;
			}
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
