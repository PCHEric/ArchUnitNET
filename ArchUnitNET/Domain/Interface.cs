﻿/*
 * Copyright 2019 Florian Gather <florian.gather@tngtech.com>
 * Copyright 2019 Paula Ruiz <paularuiz22@gmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Collections.Generic;
using ArchUnitNET.Domain.Dependencies.Types;

namespace ArchUnitNET.Domain
{
    public class Interface : IType
    {
        public Interface(IType type)
        {
            Type = type;
        }

        public IType Type { get; }
        public string Name => Type.Name;
        public string FullName => Type.FullName;

        public Visibility Visibility => Type.Visibility;
        public bool IsNested => Type.IsNested;

        public Namespace Namespace => Type.Namespace;
        public Assembly Assembly => Type.Assembly;

        public List<Attribute> Attributes { get; } = new List<Attribute>();

        public List<ITypeDependency> Dependencies => Type.Dependencies;
        public List<ITypeDependency> BackwardsDependencies => Type.BackwardsDependencies;
        public IEnumerable<IType> ImplementedInterfaces => Type.ImplementedInterfaces;

        public MemberList Members => Type.Members;
        public List<IType> GenericTypeParameters => Type.GenericTypeParameters;
        public IType GenericType => Type.GenericType;
        public List<IType> GenericTypeArguments => Type.GenericTypeArguments;

        public bool Implements(IType intf)
        {
            return Type.Implements(intf);
        }

        public bool Implements(string interfacePattern)
        {
            return Type.Implements(interfacePattern);
        }

        public bool IsAssignableTo(IType assignableToType)
        {
            if (assignableToType is Interface @interface)

            {
                return Implements(@interface);
            }

            return false;
        }

        public bool IsAssignableTo(string pattern)
        {
            return Implements(pattern);
        }

        public override string ToString()
        {
            return FullName;
        }

        private bool Equals(Interface other)
        {
            return Equals(Type, other.Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Interface) obj);
        }

        public override int GetHashCode()
        {
            return Type != null ? Type.GetHashCode() : 0;
        }
    }
}