// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="ExtremeFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeContinuousFiltersFolder + "Extreme Filter Provider",
		fileName = "Extreme Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class ExtremeFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ExpectedMin = ExtremeFiltering.DefaultExpectedMin;
		[SerializeField] private float m_ExpectedMax = ExtremeFiltering.DefaultExpectedMax;
		[SerializeField,
		Tooltip("How far from an expected minimum or maximum a value may be to be counted as close enough.")]
		private float m_Range = ExtremeFiltering.DefaultRange;
		[SerializeField, Tooltip("Allowed extreme sequence length.")]
		private byte m_ExtremeSequenceLength = ExtremeFiltering.DefaultExtremeSequenceLength;
#pragma warning restore CS0649

		private ExtremeFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="ExtremeFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new ExtremeFilter(m_ExpectedMin, m_ExpectedMax, m_Range, m_ExtremeSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = extremeFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="ExtremeFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public ExtremeFilter extremeFilter
		{
			[Pure]
			get => new ExtremeFilter(m_ExpectedMin, m_ExpectedMax, m_Range, m_ExtremeSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeFilter"/>.
		/// </summary>
		[NotNull]
		public ExtremeFilter sharedExtremeFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = extremeFilter;
				}

				return m_sharedFilter;
			}
		}

		public float expectedMin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExpectedMin;
			set
			{
				if (m_ExpectedMin == value)
				{
					return;
				}

				m_ExpectedMin = value;
				m_sharedFilter = null;
			}
		}

		public float expectedMax
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExpectedMax;
			set
			{
				if (m_ExpectedMax == value)
				{
					return;
				}

				m_ExpectedMax = value;
				m_sharedFilter = null;
			}
		}

		/// <summary>
		/// How far from an expected minimum or maximum a value may be to be counted as close enough.
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
		/// Allowed extreme sequence length.
		/// </summary>
		public byte extremeSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ExtremeSequenceLength;
			set
			{
				if (m_ExtremeSequenceLength == value)
				{
					return;
				}

				m_ExtremeSequenceLength = value;
				m_sharedFilter = null;
			}
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
