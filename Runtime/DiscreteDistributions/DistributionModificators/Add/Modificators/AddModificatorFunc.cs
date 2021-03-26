// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.DiscreteDistributions.DistributionModificators
{
	/// <summary>
	/// Add modificator for <see cref="Func{Single}"/>.
	/// </summary>
	public sealed class AddModificatorFunc : IAddModificator<int>
	{
		[NotNull] private Func<int> m_dependedFunc;
		private int m_item;

		/// <summary>
		/// Creates <see cref="AddModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		/// <param name="item"></param>
		public AddModificatorFunc([NotNull] Func<int> dependedFunc, int item)
		{
			m_dependedFunc = dependedFunc;
			m_item = item;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public AddModificatorFunc([NotNull] AddModificatorFunc other)
		{
			m_dependedFunc = other.m_dependedFunc;
			m_item = other.m_item;
		}

		[NotNull]
		public Func<int> dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedFunc = value;
		}

		public int item
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_item;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_item = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public int Generate()
		{
			return m_dependedFunc() + m_item;
		}
	}
}
