// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

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
		fileName = "ClampModificatorProvider",
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

		private ClampModificator<IDiscreteGenerator<int>> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="ClampModificator{T}"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => clampModificator;
		}

		/// <summary>
		/// Returns a shared <see cref="ClampModificator{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedClampModificator;

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
				if (m_sharedModificator == null)
				{
					m_sharedModificator = clampModificator;
				}

				return m_sharedModificator;
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
				m_sharedModificator = null;
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
				m_sharedModificator = null;
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
				m_sharedModificator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedModificator = null;
		}

		private void OnValidate()
		{
			m_sharedModificator = null;
		}
	}
}
