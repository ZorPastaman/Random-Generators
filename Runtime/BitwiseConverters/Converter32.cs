// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.InteropServices;

namespace Zor.RandomGenerators.BitwiseConverters
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Converter32
	{
		[FieldOffset(0)] public int intValue;
		[FieldOffset(0)] public uint uintValue;
		[FieldOffset(0)] public float floatValue;
	}
}
