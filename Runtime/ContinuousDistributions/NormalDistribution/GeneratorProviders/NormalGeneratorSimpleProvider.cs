// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="NormalGeneratorSimple"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.NormalDistributionFolder + "Normal Generator Simple Provider",
		fileName = "NormalGeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class NormalGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private NormalGeneratorSimple m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="NormalGeneratorSimple"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => normalGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="NormalGeneratorSimple"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedNormalGenerator;

		/// <summary>
		/// Creates a new <see cref="NormalGeneratorSimple"/> and returns it.
		/// </summary>
		[NotNull]
		public NormalGeneratorSimple normalGenerator
		{
			[Pure]
			get => new NormalGeneratorSimple();
		}

		/// <summary>
		/// Returns a shared <see cref="NormalGeneratorSimple"/>.
		/// </summary>
		[NotNull]
		public NormalGeneratorSimple sharedNormalGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = normalGenerator;
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
