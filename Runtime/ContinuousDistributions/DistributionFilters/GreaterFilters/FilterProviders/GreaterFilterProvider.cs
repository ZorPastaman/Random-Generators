// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="GreaterFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.GreaterContinuousFiltersFolder + "Greater Filter Provider",
		fileName = "Greater Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class GreaterFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = GreaterFiltering.DefaultReferenceValue;
		[SerializeField, Tooltip("Allowed greater sequence length.")]
		private byte m_GreaterSequenceLength = GreaterFiltering.DefaultGreaterSequenceLength;
#pragma warning restore CS0649

		private GreaterFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="GreaterFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new GreaterFilter(m_ReferenceValue, m_GreaterSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="GreaterFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = greaterFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="GreaterFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public GreaterFilter greaterFilter
		{
			[Pure]
			get => new GreaterFilter(m_ReferenceValue, m_GreaterSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="GreaterFilter"/>.
		/// </summary>
		[NotNull]
		public GreaterFilter sharedGreaterFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = greaterFilter;
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
		/// Allowed greater sequence length.
		/// </summary>
		public byte greaterSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_GreaterSequenceLength;
			set
			{
				if (m_GreaterSequenceLength == value)
				{
					return;
				}

				m_GreaterSequenceLength = value;
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
