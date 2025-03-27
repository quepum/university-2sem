namespace Routers;

/// <summary>
/// This exception is used when a negative bandwidth of the router is detected in the input data.
/// </summary>
public class NegativeBandwidthException() : Exception("The throughput capacity of the router cannot be negative.");