// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Struct for Unity serializable objects holding a reference to a <see cref="ContinuousGeneratorProvider"/>
	/// and returning a shared or not <see cref="IContinuousGenerator"/> by the specified parameter.
	/// </summary>
	[Serializable]
	public struct ContinuousGeneratorProviderReference : IEquatable<ContinuousGeneratorProviderReference>
	{
#pragma warning disable CS0649
		[SerializeField, NotNull] private ContinuousGeneratorProvider m_ContinuousGeneratorProvider;
		[SerializeField] private bool m_Shared;
#pragma warning restore CS0649

		public ContinuousGeneratorProviderReference([NotNull] ContinuousGeneratorProvider continuousGeneratorProvider,
			bool shared)
		{
			m_ContinuousGeneratorProvider = continuousGeneratorProvider;
			m_Shared = shared;
		}

		/// <summary>
		/// Returns a shared or not <see cref="IContinuousGenerator"/> by the specified parameter.
		/// </summary>
		/// <returns>Shared or not <see cref="IContinuousGenerator"/>.</returns>
		/// <remarks>
		/// It's recommended to cache the result.
		/// </remarks>
		[NotNull]
		public IContinuousGenerator generator
		{
			[Pure]
			get => m_Shared ? m_ContinuousGeneratorProvider.sharedGenerator : m_ContinuousGeneratorProvider.generator;
		}

		[NotNull]
		public ContinuousGeneratorProvider continuousGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ContinuousGeneratorProvider;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_ContinuousGeneratorProvider = value;
		}

		public bool shared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Shared;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_Shared = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public bool Equals(ContinuousGeneratorProviderReference other)
		{
			return Equals(m_ContinuousGeneratorProvider, other.m_ContinuousGeneratorProvider) &
				m_Shared == other.m_Shared;
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return obj is ContinuousGeneratorProviderReference other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			unchecked
			{
				return ((m_ContinuousGeneratorProvider != null ? m_ContinuousGeneratorProvider.GetHashCode() : 0) * 397)
					^ m_Shared.GetHashCode();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(ContinuousGeneratorProviderReference left,
			ContinuousGeneratorProviderReference right)
		{
			return left.Equals(right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(ContinuousGeneratorProviderReference left,
			ContinuousGeneratorProviderReference right)
		{
			return !left.Equals(right);
		}
	}
}
