// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="NotInRangeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NotInRangeContinuousFiltersFolder + "Not In Range Filter Provider",
		fileName = "Not In Range Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class NotInRangeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = NotInRangeFilter.DefaultMin;
		[SerializeField] private float m_Max = NotInRangeFilter.DefaultMax;
		[SerializeField, Tooltip("Allowed not in range sequence length.")]
		private byte m_NotInRangeSequenceLength = NotInRangeFilter.DefaultNotInRangeSequenceLength;
#pragma warning restore CS0649

		private NotInRangeFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="NotInRangeFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new NotInRangeFilter(m_Min, m_Max, m_NotInRangeSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="NotInRangeFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = notInRangeFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="NotInRangeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public NotInRangeFilter notInRangeFilter
		{
			[Pure]
			get => new NotInRangeFilter(m_Min, m_Max, m_NotInRangeSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="NotInRangeFilter"/>.
		/// </summary>
		[NotNull]
		public NotInRangeFilter sharedNotInRangeFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = notInRangeFilter;
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
		/// Allowed not in range sequence length.
		/// </summary>
		public byte notInRangeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_NotInRangeSequenceLength;
			set
			{
				if (m_NotInRangeSequenceLength == value)
				{
					return;
				}

				m_NotInRangeSequenceLength = value;
				m_sharedFilter = null;
			}
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
