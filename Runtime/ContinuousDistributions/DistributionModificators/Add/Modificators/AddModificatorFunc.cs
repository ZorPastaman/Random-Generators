// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Add modificator for <see cref="Func{Single}"/>.
	/// </summary>
	public sealed class AddModificatorFunc : IAddModificator
	{
		[NotNull] private Func<float> m_dependedFunc;
		private float m_item;

		/// <summary>
		/// Creates <see cref="AddModificatorFunc"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedFunc"></param>
		/// <param name="item"></param>
		public AddModificatorFunc([NotNull] Func<float> dependedFunc, float item)
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
		public Func<float> dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedFunc;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedFunc = value;
		}

		public float item
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_item;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_item = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return m_dependedFunc() + m_item;
		}
	}
}
