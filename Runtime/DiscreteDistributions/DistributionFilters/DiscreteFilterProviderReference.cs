// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionFilters
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a
	/// <see cref="DiscreteFilterProvider_Base"/>
	/// and returning a shared or not <see cref="IDiscreteFilter{T}"/> by the specified parameter.
	/// </summary>
	/// <seealso cref="Zor.RandomGenerators.PropertyDrawerAttributes.RequireDiscreteFilter"/>.
	[Serializable]
	public struct DiscreteFilterProviderReference : IEquatable<DiscreteFilterProviderReference>
	{
#pragma warning disable CS0649
		[SerializeField, NotNull] private DiscreteFilterProvider_Base m_FilterProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		public DiscreteFilterProviderReference([NotNull] DiscreteFilterProvider_Base filterProvider,
			bool shared)
		{
			m_FilterProvider = filterProvider;
			m_Shared = shared;
		}

		/// <summary>
		/// Returns a shared or not <see cref="IDiscreteFilter{T}"/> by the specified parameter.
		/// </summary>
		/// <typeparam name="T">Value type.</typeparam>
		/// <returns>Shared or not <see cref="IDiscreteFilter{T}"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		public IDiscreteFilter<T> GetFilter<T>()
		{
			if (m_FilterProvider is DiscreteFilterProvider<T> typedFilterProvider)
			{
				return m_Shared ? typedFilterProvider.sharedFilter : typedFilterProvider.filter;
			}

			return null;
		}

		[NotNull]
		public DiscreteFilterProvider_Base filterProvider
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
		public bool Equals(DiscreteFilterProviderReference other)
		{
			return m_FilterProvider.Equals(other.m_FilterProvider) & m_Shared == other.m_Shared;
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return obj is DiscreteFilterProviderReference other && Equals(other);
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
		public static bool operator ==(DiscreteFilterProviderReference left, DiscreteFilterProviderReference right)
		{
			return left.Equals(right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(DiscreteFilterProviderReference left, DiscreteFilterProviderReference right)
		{
			return !left.Equals(right);
		}
	}
}
