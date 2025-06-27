// <copyright file="NetworkDisconnectedException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// This exception is used when a router network connectivity issue is detected.
/// Indicates problems with the network topology, in which routers cannot efficiently transfer data between themselves.
/// </summary>
public class NetworkDisconnectedException() : Exception("The network is not connected.");