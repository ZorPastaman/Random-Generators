// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="AscendantSequenceFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.AscendantSequenceContinuousFiltersFolder +
			"Ascendant Sequence Filter Provider",
		fileName = "Ascendant Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class AscendantSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed ascendant sequence length.")]
		private byte m_AscendantSequenceLength = AscendantSequenceFiltering.DefaultAscendantSequenceLength;
#pragma warning restore CS0649

		private AscendantSequenceFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new AscendantSequenceFilter(m_AscendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="AscendantSequenceFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = ascendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public AscendantSequenceFilter ascendantSequenceFilter
		{
			[Pure]
			get => new AscendantSequenceFilter(m_AscendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="AscendantSequenceFilter"/>.
		/// </summary>
		[NotNull]
		public AscendantSequenceFilter sharedAscendantSequenceFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = ascendantSequenceFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Allowed ascendant sequence length.
		/// </summary>
		public byte ascendantSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_AscendantSequenceLength;
			set
			{
				if (m_AscendantSequenceLength == value)
				{
					return;
				}

				m_AscendantSequenceLength = value;
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
