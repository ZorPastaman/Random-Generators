// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Generator Dependent Provider",
		fileName = "Irwin-Hall Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallGeneratorDependentProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_StartPoint = IrwinHallDistribution.DefaultStartPoint;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		private IrwinHallGeneratorDependent<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new IrwinHallGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_StartPoint, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorDependent{T}"/>
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
		/// Creates a new <see cref="IrwinHallGeneratorDependent{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorDependent<IContinuousGenerator> irwinHallGenerator
		{
			[Pure]
			get => new IrwinHallGeneratorDependent<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator, m_StartPoint, m_Iids);
		}

		/// <summary>
		/// Returns a shared <see cref="IrwinHallGeneratorDependent{T}"/>.
		/// </summary>
		[NotNull]
		public IrwinHallGeneratorDependent<IContinuousGenerator> sharedIrwinHallGenerator
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
