// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.RandomGenerators.BitwiseConverters;

namespace Zor.RandomGenerators.RandomEngines
{
	public struct XorShift32
	{
		private uint m_state;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift32(uint state)
		{
			m_state = state;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift32(int seed)
		{
			unchecked
			{
				m_state = (uint)seed;
			}
		}

		public uint state
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_state;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_state = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool NextBool()
		{
			NextState();
			uint answer = m_state & 1u;
			return *(bool*)&answer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte NextByte()
		{
			NextState();

			unchecked
			{
				return (byte)m_state;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte NextByte(byte min, byte max)
		{
			return (byte)((max - min) * NextFloat01() + min);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte NextSbyte()
		{
			NextState();

			unchecked
			{
				return (sbyte)m_state;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte NextSbyte(sbyte min, sbyte max)
		{
			return (sbyte)((max - min) * NextFloat01() + min);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short NextShort()
		{
			NextState();

			unchecked
			{
				return (short)m_state;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short NextShort(short min, short max)
		{
			return (short)((max - min) * NextFloat01() + min);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort NextUshort()
		{
			NextState();

			unchecked
			{
				return (ushort)m_state;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort NextUshort(ushort min, ushort max)
		{
			return (ushort)((max - min) * NextFloat01() + min);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt()
		{
			NextState();

			unchecked
			{
				return (int)~m_state;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt(int min, int max)
		{
			return (int)((max - min) * NextFloat01()) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint()
		{
			NextState();
			return ~m_state;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint(uint min, uint max)
		{
			return (uint)((max - min) * NextFloat01()) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long NextLong()
		{
			NextState();
			long answer = (long)m_state << 32;
			NextState();
			return ~(answer | m_state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long NextLong(long min, long max)
		{
			return (long)((max - min) * NextDouble()) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong NextUlong()
		{
			NextState();
			ulong answer = (ulong)m_state << 32;
			NextState();
			return ~(answer | m_state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong NextUlong(ulong min, ulong max)
		{
			return (ulong)((max - min) * NextDouble()) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat01()
		{
			NextState();
			return new Converter32{uintValue = (m_state >> 9) | 0x3F800000u}.floatValue - 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat()
		{
			NextState();
			return new Converter32{uintValue = ~m_state}.floatValue;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat(float min, float max)
		{
			return (max - min) * NextFloat01() + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble()
		{
			NextState();
			return (double)~m_state / uint.MaxValue;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble(double min, double max)
		{
			return (max - min) * NextDouble() + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void NextState()
		{
			m_state ^= m_state << 13;
			m_state ^= m_state >> 17;
			m_state ^= m_state << 5;
		}
	}
}
