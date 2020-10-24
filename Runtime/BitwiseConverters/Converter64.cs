// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.InteropServices;

namespace Zor.RandomGenerators.BitwiseConverters
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Converter64
	{
		[FieldOffset(0)] public long longValue;
		[FieldOffset(0)] public ulong ulongValue;
		[FieldOffset(0)] public double doubleValue;
	}
}
