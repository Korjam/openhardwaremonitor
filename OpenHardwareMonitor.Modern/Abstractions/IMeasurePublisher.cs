using System;

namespace OpenHardwareMonitor.Modern.Abstractions;

public interface IMeasurePublisher<T>
{
    void Publish(T item, TimeSpan timestamp);
    void Register(T item);
    void Remove(T item);
}
