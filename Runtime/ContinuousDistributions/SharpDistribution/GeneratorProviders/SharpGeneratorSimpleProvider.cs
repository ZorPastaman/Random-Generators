// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGenerator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpContinuousDistributionFolder + "Sharp Generator Simple Provider",
		fileName = "SharpGeneratorSimpleProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private SharpGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => sharpGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedSharpGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public SharpGenerator sharpGenerator
		{
			[Pure]
			get => new SharpGenerator();
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/>.
		/// </summary>
		[NotNull]
		public SharpGenerator sharedSharpGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = sharpGenerator;
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
