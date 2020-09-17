// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
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
		private DiscreteGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private int m_Min = ClampModificatorDefaults.DefaultMin;
		[SerializeField] private int m_Max = ClampModificatorDefaults.DefaultMax;
#pragma warning restore CS0649

		private ClampModificator<IDiscreteGenerator<int>> m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new ClampModificator<IDiscreteGenerator<int>>(
				m_DependedGeneratorProvider.GetGenerator<int>(), m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
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
				m_DependedGeneratorProvider.GetGenerator<int>(), m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/>.
		/// </summary>
		[NotNull]
		public ClampModificator<IDiscreteGenerator<int>> sharedClampModificator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = clampModificator;
				}

				return m_sharedGenerator;
			}
		}

		public DiscreteGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		public int min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedGenerator = null;
			}
		}

		public int max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedGenerator = null;
			}
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
