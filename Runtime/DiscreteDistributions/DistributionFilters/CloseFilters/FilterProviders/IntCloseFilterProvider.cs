// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="IntCloseFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.CloseDiscreteFiltersFolder + "Int Close Filter Provider",
		fileName = "Int Close Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class IntCloseFilterProvider : DiscreteFilterProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_ReferenceValue = IntCloseFilter.DefaultReferenceValue;
		[SerializeField,
		Tooltip("How far from a reference value a value may be to be counted as close enough.")]
		private int m_Range = IntCloseFilter.DefaultRange;
		[SerializeField, Tooltip("Allowed close sequence length.")]
		private byte m_CloseSequenceLength = IntCloseFilter.DefaultCloseSequenceLength;
#pragma warning restore CS0649

		private IntCloseFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="IntCloseFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<int> filter
		{
			[Pure]
			get => new IntCloseFilter(m_ReferenceValue, m_Range, m_CloseSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="IntCloseFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<int> sharedFilter
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

		/// <summary>
		/// Creates a new <see cref="IntCloseFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public IntCloseFilter closeFilter
		{
			[Pure]
			get => new IntCloseFilter(m_ReferenceValue, m_Range, m_CloseSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="IntCloseFilter"/>.
		/// </summary>
		[NotNull]
		public IntCloseFilter sharedCloseFilter
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

		public int referenceValue
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
		public int range
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

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
