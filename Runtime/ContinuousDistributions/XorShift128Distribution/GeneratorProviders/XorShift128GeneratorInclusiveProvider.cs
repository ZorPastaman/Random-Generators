// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift128GeneratorInclusive"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128ContinuousDistributionFolder +
			"XorShift128 Generator Inclusive Provider",
		fileName = "XorShift128GeneratorInclusiveProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift128GeneratorInclusiveProvider : ContinuousGeneratorProvider
	{
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateA = XorShift128Defaults.InitialStateA;
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateB = XorShift128Defaults.InitialStateB;
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateC = XorShift128Defaults.InitialStateC;
		[SerializeField, SimpleRangeLong(1u, uint.MaxValue)]
		private uint m_InitialStateD = XorShift128Defaults.InitialStateD;

		private XorShift128GeneratorInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift128GeneratorInclusive"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift128GeneratorInclusive;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128GeneratorInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift128GeneratorInclusive;

		/// <summary>
		/// Creates a new <see cref="XorShift128GeneratorInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift128GeneratorInclusive xorShift128GeneratorInclusive
		{
			[Pure]
			get => new XorShift128GeneratorInclusive(m_InitialStateA, m_InitialStateB, m_InitialStateC, m_InitialStateD);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift128GeneratorInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift128GeneratorInclusive sharedXorShift128GeneratorInclusive
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift128GeneratorInclusive;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Initial state of <see cref="XorShift128"/>. Every item must be non-zero.
		/// </summary>
		public (uint, uint, uint, uint) initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (m_InitialStateA, m_InitialStateB, m_InitialStateC, m_InitialStateD);
			set
			{
				if (m_InitialStateA == value.Item1 & m_InitialStateB == value.Item2 &
					m_InitialStateC == value.Item3 & m_InitialStateD == value.Item4)
				{
					return;
				}

				m_InitialStateA = value.Item1;
				m_InitialStateB = value.Item2;
				m_InitialStateC = value.Item3;
				m_InitialStateD = value.Item4;

				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
