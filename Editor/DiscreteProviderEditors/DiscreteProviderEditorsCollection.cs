// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEditor;

namespace Zor.RandomGenerators.DiscreteProviderEditors
{
	[InitializeOnLoad]
	public static class DiscreteProviderEditorsCollection
	{
		private static readonly Dictionary<Type, Type> s_discreteEditorsCollection = new Dictionary<Type, Type>();

		static DiscreteProviderEditorsCollection()
		{
			Type[] editorTypes = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
					where !domainAssembly.IsDynamic
					from assemblyType in domainAssembly.GetExportedTypes()
					where !assemblyType.IsAbstract && !assemblyType.IsGenericType
						&& typeof(DiscreteProviderEditor).IsAssignableFrom(assemblyType)
					select assemblyType)
				.ToArray();

			for (int i = 0, count = editorTypes.Length; i < count; ++i)
			{
				Type editorType = editorTypes[i];
				var providerType = editorType.GetCustomAttribute<DiscreteProviderType>();

				if (providerType != null)
				{
					for (int j = 0, typesCount = providerType.types.Length; j < typesCount; ++j)
					{
						s_discreteEditorsCollection[providerType.types[j]] = editorType;
					}
				}
			}
		}

		[CanBeNull]
		public static DiscreteProviderEditor GetEditor([NotNull] Type type)
		{
			do
			{
				if (s_discreteEditorsCollection.TryGetValue(type, out Type discreteEditorType))
				{
					return (DiscreteProviderEditor)Activator.CreateInstance(discreteEditorType);
				}

				if (type.IsGenericType &&
					s_discreteEditorsCollection.TryGetValue(type.GetGenericTypeDefinition(), out discreteEditorType))
				{
					return (DiscreteProviderEditor)Activator.CreateInstance(discreteEditorType);
				}

				type = type.BaseType;
			} while (type != null);

			return null;
		}
	}
}
