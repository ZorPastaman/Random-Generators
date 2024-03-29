// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="AscendantSequenceFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class AscendantSequenceFilterProvider<T> : DiscreteFilterProvider<T> where T : IComparable<T>
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("Allowed ascendant sequence length.")] private byte m_AscendantSequenceLength =
			AscendantSequenceFiltering.DefaultAscendantSequenceLength;
#pragma warning restore CS0649

		private AscendantSequenceFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => ascendantSequenceFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="AscendantSequenceFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter => sharedAscendantSequenceFilter;

		/// <summary>
		/// Creates a new <see cref="AscendantSequenceFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public AscendantSequenceFilter<T> ascendantSequenceFilter
		{
			[Pure]
			get => new AscendantSequenceFilter<T>(m_AscendantSequenceLength);
		}

		/// <summary>
		/// Returns a shared <see cref="AscendantSequenceFilter{T}"/>.
		/// </summary>
		[NotNull]
		public AscendantSequenceFilter<T> sharedAscendantSequenceFilter
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
		public sealed override void DropSharedFilter()
		{
			m_sharedFilter = null;
		}

		private void OnValidate()
		{
			m_sharedFilter = null;
		}
	}
}
