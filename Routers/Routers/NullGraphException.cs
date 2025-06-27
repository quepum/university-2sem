// <copyright file="NullGraphException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// This exception is used when input file is empty.
/// </summary>
public class NullGraphException() : Exception("Empty network");