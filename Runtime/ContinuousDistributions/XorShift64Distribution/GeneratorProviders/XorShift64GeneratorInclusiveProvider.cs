// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift64GeneratorInclusive"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift64ContinuousDistributionFolder +
			"XorShift64 Generator Inclusive Provider",
		fileName = "XorShift64GeneratorInclusiveProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift64GeneratorInclusiveProvider : ContinuousGeneratorProvider
	{
		[SerializeField, SimpleRangeLong(1L, long.MaxValue)]
		private ulong m_InitialState = XorShift64Defaults.InitialState;

		private XorShift64GeneratorInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="XorShift64GeneratorInclusive"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => xorShift64GeneratorInclusive;
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64GeneratorInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedXorShift64GeneratorInclusive;

		/// <summary>
		/// Creates a new <see cref="XorShift64GeneratorInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public XorShift64GeneratorInclusive xorShift64GeneratorInclusive
		{
			[Pure]
			get => new XorShift64GeneratorInclusive(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="XorShift64GeneratorInclusive"/>.
		/// </summary>
		[NotNull]
		public XorShift64GeneratorInclusive sharedXorShift64GeneratorInclusive
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = xorShift64GeneratorInclusive;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Initial state of <see cref="XorShift64"/>. Must be non-zero.
		/// </summary>
		public ulong initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InitialState;
			set
			{
				if (m_InitialState == value)
				{
					return;
				}

				m_InitialState = value;
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
