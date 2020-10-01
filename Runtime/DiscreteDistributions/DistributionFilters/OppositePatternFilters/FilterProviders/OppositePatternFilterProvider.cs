// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="OppositePatternFilter{T}"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>
	/// Type <typeparamref name="T"/> must take only two values like <see cref="bool"/>.
	/// </remarks>
	public abstract class OppositePatternFilterProvider<T> : DiscreteFilterProvider<T> where T : IEquatable<T>
	{
#pragma warning disable CS0649
		[SerializeField] private byte m_PatternLength = OppositePatternFiltering.DefaultPatterLength;
#pragma warning restore CS0649

		private OppositePatternFilter<T> m_sharedFilter;

		/// <summary>
		/// Creates a new <see cref="OppositePatternFilter{T}"/> and returns it as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<T> filter
		{
			[Pure]
			get => new OppositePatternFilter<T>(m_PatternLength);
		}

		/// <summary>
		/// Returns a shared <see cref="OppositePatternFilter{T}"/> as <see cref="IDiscreteFilter{T}"/>.
		/// </summary>
		public override IDiscreteFilter<T> sharedFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = oppositePatternFilter;
				}

				return m_sharedFilter;
			}
		}

		/// <summary>
		/// Creates a new <see cref="OppositePatternFilter{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public OppositePatternFilter<T> oppositePatternFilter
		{
			[Pure]
			get => new OppositePatternFilter<T>(m_PatternLength);
		}

		/// <summary>
		/// Returns a shared <see cref="OppositePatternFilter{T}"/>.
		/// </summary>
		[NotNull]
		public OppositePatternFilter<T> sharedOppositePatternFilter
		{
			get
			{
				if (m_sharedFilter == null)
				{
					m_sharedFilter = oppositePatternFilter;
				}

				return m_sharedFilter;
			}
		}

		public byte patternLength
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_PatternLength;
			set
			{
				if (m_PatternLength == value)
				{
					return;
				}

				m_PatternLength = value;
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
