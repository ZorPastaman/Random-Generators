// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="ClampModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteModificatorsFolder + "Clamp Modificator Provider",
		fileName = "Clamp Modificator Provider",
		order = CreateAssetMenuConstants.ModificatorOrder
		)]
	public sealed class ClampModificatorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, RequireDiscreteGenerator(typeof(int))]
		private DiscreteGeneratorProviderReference m_DependedGenerator;
		[SerializeField] private int m_Min;
		[SerializeField] private int m_Max = 1;
#pragma warning restore CS0649

		private ClampModificator<IDiscreteGenerator<int>> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new ClampModificator<IDiscreteGenerator<int>>(
				m_DependedGenerator.GetGenerator<int>(), m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = clampModificator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public ClampModificator<IDiscreteGenerator<int>> clampModificator
		{
			[Pure]
			get => new ClampModificator<IDiscreteGenerator<int>>(
				m_DependedGenerator.GetGenerator<int>(), m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/>.
		/// </summary>
		[NotNull]
		public ClampModificator<IDiscreteGenerator<int>> sharedClampModificator
		{
			[Pure]
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = clampModificator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
