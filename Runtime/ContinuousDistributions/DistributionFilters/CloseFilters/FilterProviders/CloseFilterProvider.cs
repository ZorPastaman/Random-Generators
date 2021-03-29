// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="CloseFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.CloseContinuousFiltersFolder + "Close Filter Provider",
		fileName = "CloseFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class CloseFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = CloseFiltering.DefaultReferenceValue;
		[SerializeField,
		Tooltip("How far from a reference value a value may be to be counted as close enough.")]
		private float m_Range = CloseFiltering.DefaultRange;
		[SerializeField, Tooltip("Allowed close sequence length.")]
		private byte m_CloseSequenceLength = CloseFiltering.DefaultCloseSequenceLength;
#pragma warning restore CS0649

		private CloseFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="CloseFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => closeFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="CloseFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter => sharedCloseFilter;

		/// <summary>
		/// Creates a new <see cref="CloseFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public CloseFilter closeFilter
		{
			[Pure]
			get => new CloseFilter(m_ReferenceValue, m_Range, m_CloseSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="CloseFilter"/>.
		/// </summary>
		[NotNull]
		public CloseFilter sharedCloseFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = closeFilter;
				}

				return m_sharedFilter;
			}
		}

		public float referenceValue
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ReferenceValue;
			set
			{
				if (m_ReferenceValue == value)
				{
					return;
				}

				m_ReferenceValue = value;
				m_sharedFilter = null;
			}
		}

		/// <summary>
		/// How far from a reference value a value may be to be counted as close enough.
		/// </summary>
		public float range
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Range;
			set
			{
				if (m_Range == value)
				{
					return;
				}

				m_Range = value;
				m_sharedFilter = null;
			}
		}

		/// <summary>
		/// Allowed close sequence length.
		/// </summary>
		public byte closeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_CloseSequenceLength;
			set
			{
				if (m_CloseSequenceLength == value)
				{
					return;
				}

				m_CloseSequenceLength = value;
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
