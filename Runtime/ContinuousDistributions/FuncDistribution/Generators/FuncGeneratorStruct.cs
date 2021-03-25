// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Generator using <see cref="Func{Single}"/>.
	/// </summary>
	public struct FuncGeneratorStruct : IFuncGenerator
	{
		[NotNull] private Func<float> m_func;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public FuncGeneratorStruct([NotNull] Func<float> func)
		{
			m_func = func;
		}

		public Func<float> func
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_func;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_func = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return m_func();
		}
	}
}
