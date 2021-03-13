// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a
	/// <see cref="DiscreteGeneratorProvider_Base"/>
	/// and returning a shared or not <see cref="IDiscreteGenerator{T}"/> by the specified parameter.
	/// </summary>
	/// <seealso cref="RequireDiscreteGenerator"/>.
	[Serializable]
	public struct DiscreteGeneratorProviderReference : IEquatable<DiscreteGeneratorProviderReference>
	{
#pragma warning disable CS0649
		[SerializeField, NotNull] private DiscreteGeneratorProvider_Base m_DiscreteGeneratorProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		public DiscreteGeneratorProviderReference([NotNull] DiscreteGeneratorProvider_Base discreteGeneratorProvider,
			bool shared)
		{
			m_DiscreteGeneratorProvider = discreteGeneratorProvider;
			m_Shared = shared;
		}

		/// <summary>
		/// Returns a shared or not <see cref="IDiscreteGenerator{T}"/> by the specified parameter.
		/// </summary>
		/// <typeparam name="T">Value type.</typeparam>
		/// <returns>Shared or not <see cref="IDiscreteGenerator{T}"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		[Pure]
		public IDiscreteGenerator<T> GetGenerator<T>()
		{
			if (m_DiscreteGeneratorProvider is DiscreteGeneratorProvider<T> discreteGeneratorProvider)
			{
				return m_Shared ? discreteGeneratorProvider.sharedGenerator : discreteGeneratorProvider.generator;
			}

			return null;
		}

		[NotNull]
		public DiscreteGeneratorProvider_Base continuousGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DiscreteGeneratorProvider;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_DiscreteGeneratorProvider = value;
		}

		public bool shared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Shared;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Shared = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool Equals(DiscreteGeneratorProviderReference other)
		{
			return m_DiscreteGeneratorProvider.Equals(other.m_DiscreteGeneratorProvider) & m_Shared == other.m_Shared;
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return obj is DiscreteGeneratorProviderReference other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			unchecked
			{
				return ((m_DiscreteGeneratorProvider != null ? m_DiscreteGeneratorProvider.GetHashCode() : 0) * 397)
					^ m_Shared.GetHashCode();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(DiscreteGeneratorProviderReference left,
			DiscreteGeneratorProviderReference right)
		{
			return left.Equals(right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(DiscreteGeneratorProviderReference left,
			DiscreteGeneratorProviderReference right)
		{
			return !left.Equals(right);
		}
	}
}
