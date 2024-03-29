// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Generator Provider",
		fileName = "IrwinHallGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IrwinHallGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField, Tooltip("How many independent and identically distributed random values are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		private IrwinHallGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallGenerator"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => irwinHallGenerator;
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedIrwinHallGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallGenerator irwinHallGenerator
		{
			[Pure]
			get => new IrwinHallGenerator(m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGenerator"/>.
		/// </summary>
		[NotNull]
		public IrwinHallGenerator sharedIrwinHallGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = irwinHallGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// How many independent and identically distributed random values are generated.
		/// </summary>
		public byte iids
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Iids;
			set
			{
				if (m_Iids == value)
				{
					return;
				}

				m_Iids = value;
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
