// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="FloatCloseFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.CloseDiscreteFiltersFolder + "Float Close Filter Provider",
		fileName = "FloatCloseFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class FloatCloseFilterProvider : DiscreteFilterProvider<float>
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = FloatCloseFilter.DefaultReferenceValue;
		[SerializeField,
		Tooltip("How far from a reference value a value may be to be counted as close enough.")]
		private float m_Range = FloatCloseFilter.DefaultRange;
		[SerializeField, Tooltip("Allowed close sequence length.")]
		private byte m_CloseSequenceLength = FloatCloseFilter.DefaultCloseSequenceLength;
#pragma warning restore CS0649

		private FloatCloseFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="FloatCloseFilter"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<float> filter
		{
			[Pure]
			get => new FloatCloseFilter(m_ReferenceValue, m_Range, m_CloseSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="FloatCloseFilter"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<float> sharedFilter
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
		/// Creates a new <see cref="FloatCloseFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public FloatCloseFilter closeFilter
		{
			[Pure]
			get => new FloatCloseFilter(m_ReferenceValue, m_Range, m_CloseSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="FloatCloseFilter"/>.
		/// </summary>
		[NotNull]
		public FloatCloseFilter sharedCloseFilter
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
