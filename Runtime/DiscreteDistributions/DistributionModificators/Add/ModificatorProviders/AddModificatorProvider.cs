// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.PropertyDrawerAttributes;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="AddModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.DiscreteDistributionsFolder + "Add Modificator Provider",
		fileName = "AddModificatorProvider",
		order = CreateAssetMenuConstants.ModificatorOrder
		)]
	public sealed class AddModificatorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField, RequireDiscreteGenerator(typeof(int))]
		private DiscreteGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private int m_Item = AddModificatorDefaults.DefaultItem;
#pragma warning restore CS0649

		private AddModificator<IDiscreteGenerator<int>> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="AddModificator{T}"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => addModificator;
		}

		/// <summary>
		/// Returns a shared <see cref="AddModificator{T}"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedAddModificator;

		/// <summary>
		/// Creates a new <see cref="AddModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public AddModificator<IDiscreteGenerator<int>> addModificator
		{
			[Pure]
			get => new AddModificator<IDiscreteGenerator<int>>(m_DependedGeneratorProvider.GetGenerator<int>(), m_Item);
		}

		/// <summary>
		/// Returns a shared <see cref="AddModificator{T}"/>.
		/// </summary>
		[NotNull]
		public AddModificator<IDiscreteGenerator<int>> sharedAddModificator
		{
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = addModificator;
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

		public int item
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Item;
			set
			{
				if (m_Item == value)
				{
					return;
				}

				m_Item = value;
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
