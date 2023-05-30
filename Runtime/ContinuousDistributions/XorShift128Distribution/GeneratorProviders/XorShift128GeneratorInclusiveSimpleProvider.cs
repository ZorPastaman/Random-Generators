// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="XorShift128GeneratorInclusive"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.XorShift128ContinuousDistributionFolder +
			"XorShift128 Generator Inclusive Simple Provider",
		fileName = "XorShift128GeneratorInclusiveSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class XorShift128GeneratorInclusiveSimpleProvider : ContinuousGeneratorProvider
	{
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
			get => new XorShift128GeneratorInclusive();
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
