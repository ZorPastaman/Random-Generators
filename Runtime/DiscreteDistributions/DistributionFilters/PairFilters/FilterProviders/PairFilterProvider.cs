// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="PairFilter{T}"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class PairFilterProvider<T> : DiscreteFilterProvider<T> where T : IEquatable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_ElementsBetweenPair = PairFiltering.DefaultsElementsBetweenPair;
#pragma warning restore CS0649

		private PairFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="PairFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> filter
		{
			[Pure]
			get => pairFilter;
		}

		/// <summary>
		/// Returns a shared <see cref="PairFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public sealed override IDiscreteFilter<T> sharedFilter => sharedPairFilter;

		/// <summary>
		/// Creates a new <see cref="PairFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public PairFilter<T> pairFilter
		{
			[Pure]
			get => new PairFilter<T>(m_ElementsBetweenPair);
		}

		/// <summary>
		/// Returns a shared <see cref="PairFilter{T}"/>.
		/// </summary>
		[NotNull]
		public PairFilter<T> sharedPairFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = pairFilter;
				}

				return m_sharedFilter;
			}
		}

		public byte elementsBetweenPair
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ElementsBetweenPair;
			set
			{
				if (m_ElementsBetweenPair == value)
				{
					return;
				}

				m_ElementsBetweenPair = value;
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
