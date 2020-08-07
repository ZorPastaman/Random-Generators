// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Generator Dependent Simple Provider",
		fileName = "Irwin-Hall Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IrwinHallGeneratorDependentSimpleProvider :
		ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids;
#pragma warning restore CS0649

		private IrwinHallGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new IrwinHallGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
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
		/// Creates a new <see cref="IrwinHallGeneratorDependentSimple{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorDependentSimple<IContinuousGenerator> irwinHallGenerator
		{
			[Pure]
			get => new IrwinHallGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorDependentSimple<IContinuousGenerator> sharedIrwinHallGenerator
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
	}
}
