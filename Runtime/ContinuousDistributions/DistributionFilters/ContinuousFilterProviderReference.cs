// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a <see cref="ContinuousFilterProvider"/>
	/// and returning a shared or not <see cref="IContinuousFilter"/> by the specified parameter.
	/// </summary>
	[Serializable]
	public struct ContinuousFilterProviderReference : IEquatable<ContinuousFilterProviderReference>
	{
#pragma warning disable CS0649
		[SerializeField, NotNull] private ContinuousFilterProvider m_FilterProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		public ContinuousFilterProviderReference([NotNull] ContinuousFilterProvider filterProvider, bool shared)
		{
			m_FilterProvider = filterProvider;
			m_Shared = shared;
		}

		/// <summary>
		/// Returns a shared or not <see cref="IContinuousFilter"/> by the specified parameter.
		/// </summary>
		/// <returns>Shared or not <see cref="IContinuousFilter"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		[NotNull]
		public IContinuousFilter filter
		{
			[Pure]
			get => m_Shared ? m_FilterProvider.sharedFilter : m_FilterProvider.filter;
		}

		[NotNull]
		public ContinuousFilterProvider filterProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_FilterProvider;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_FilterProvider = value;
		}

		public bool shared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Shared;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Shared = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool Equals(ContinuousFilterProviderReference other)
		{
			return Equals(m_FilterProvider, other.m_FilterProvider) && m_Shared == other.m_Shared;
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return obj is ContinuousFilterProviderReference other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			unchecked
			{
				return ((m_FilterProvider != null ? m_FilterProvider.GetHashCode() : 0) * 397) ^ m_Shared.GetHashCode();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(ContinuousFilterProviderReference left, ContinuousFilterProviderReference right)
		{
			return left.Equals(right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(ContinuousFilterProviderReference left, ContinuousFilterProviderReference right)
		{
			return !left.Equals(right);
		}
	}
}
