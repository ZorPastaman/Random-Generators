// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="LessFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LessContinuousFiltersFolder + "Less Filter Provider",
		fileName = "LessFilterProvider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LessFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_ReferenceValue = LessFiltering.DefaultReferenceValue;
		[SerializeField, Tooltip("Allowed less sequence length.")]
		private byte m_LessSequenceLength = LessFiltering.DefaultLessSequenceLength;
#pragma warning restore CS0649

		private LessFilter m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="LessFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => lessFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="LessFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter => sharedLessFilter;

		/// <summary>
		/// Creates a new <see cref="LessFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public LessFilter lessFilter
		{
			[Pure]
			get => new LessFilter(m_ReferenceValue, m_LessSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="LessFilter"/>.
		/// </summary>
		[NotNull]
		public LessFilter sharedLessFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = lessFilter;
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
		/// Allowed less sequence length.
		/// </summary>
		public byte lessSequenceLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_LessSequenceLength;
			set
			{
				if (m_LessSequenceLength == value)
				{
					return;
				}

				m_LessSequenceLength = value;
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
