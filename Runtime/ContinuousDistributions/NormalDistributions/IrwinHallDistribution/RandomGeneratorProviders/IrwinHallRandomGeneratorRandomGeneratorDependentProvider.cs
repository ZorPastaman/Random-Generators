// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="IrwinHallRandomGeneratorRandomGeneratorDependent{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.IrwinHallDistributionFolder + "Irwin-Hall Random Generator Random Generator Dependent Provider",
		fileName = "Irwin-Hall Random Generator Random Generator Dependent Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class IrwinHallRandomGeneratorRandomGeneratorDependentProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGenerator;
		[SerializeField] private float m_StartPoint = IrwinHallDistribution.DefaultStartPoint;
		[SerializeField, Tooltip("How many independent and identically distributed random variables are generated.")]
		private byte m_Iids = IrwinHallDistribution.DefaultIids;
#pragma warning restore CS0649

		private IrwinHallRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorRandomGeneratorDependent{T}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator =>
			new IrwinHallRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator, m_StartPoint, m_Iids);

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorRandomGeneratorDependent{T}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = irwinHallRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="IrwinHallRandomGeneratorRandomGeneratorDependent{T}"/> and returns it.
		/// </summary>
		public IrwinHallRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> irwinHallRandomGenerator =>
			new IrwinHallRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator>(
				m_DependedRandomGenerator.randomGenerator, m_StartPoint, m_Iids);

		/// <summary>
		/// Returns a shared <see cref="IrwinHallRandomGeneratorRandomGeneratorDependent{T}"/>.
		/// </summary>
		public IrwinHallRandomGeneratorRandomGeneratorDependent<IContinuousRandomGenerator> sharedIrwinHallRandomGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = irwinHallRandomGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
