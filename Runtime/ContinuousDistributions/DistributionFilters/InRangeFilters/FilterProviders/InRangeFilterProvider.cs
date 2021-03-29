// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="InRangeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.InRangeContinuousFiltersFolder + "In Range Filter Provider",
		fileName = "InRangeFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class InRangeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = InRangeFiltering.DefaultMin;
		[SerializeField] private float m_Max = InRangeFiltering.DefaultMax;
		[SerializeField, Tooltip("Allowed in range sequence length.")]
		private byte m_InRangeSequenceLength = InRangeFiltering.DefaultInRangeSequenceLength;
#pragma warning restore CS0649

		private InRangeFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="InRangeFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => inRangeFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="InRangeFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter => sharedInRangeFilter;

		/// <summary>
		/// Creates a new <see cref="InRangeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public InRangeFilter inRangeFilter
		{
			[Pure]
			get => new InRangeFilter(m_Min, m_Max, m_InRangeSequenceLength);
		}

		/// <summary>
		/// Returns a shared see cref="InRangeFilter"/>.
		/// </summary>
		[NotNull]
		public InRangeFilter sharedInRangeFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = inRangeFilter;
				}

				return m_sharedFilter;
			}
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedFilter = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedFilter = null;
			}
		}

		/// <summary>
		/// Allowed in range sequence length.
		/// </summary>
		public byte inRangeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InRangeSequenceLength;
			set
			{
				if (m_InRangeSequenceLength == value)
				{
					return;
				}

				m_InRangeSequenceLength = value;
				m_sharedFilter = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedFilter()
		{
			m_sharedFilter = null;
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
