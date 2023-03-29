using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Kanadeiar.Core.Container;
using Kanadeiar.Core.Encoders;
using Moq;
using Xunit;

namespace Kanadeiar.Core.Tests.Container;

public class KndContainerTests
{
    [Fact]
    public void Register_ServiceInplementation_ShouldOk()
    {
        var container = new KndContainer();

        container.Register<ITestTest, TestTest>();

        var fi = typeof(KndContainer).GetField("_regs", BindingFlags.NonPublic | BindingFlags.Instance);
        var dict = (IDictionary<Type, Func<object>>)fi.GetValue(container);
        Assert.Equal(1, dict.Count);
        Assert.IsType<TestTest>(dict[typeof(ITestTest)].Invoke());
    }
    [Fact]
    public void Register_ServiceFactory_ShouldOk()
    {
        var expected = new TestTest();
        var container = new KndContainer();

        container.Register<ITestTest>(() => expected);

        var fi = typeof(KndContainer).GetField("_regs", BindingFlags.NonPublic | BindingFlags.Instance);
        var dict = (IDictionary<Type, Func<object>>)fi.GetValue(container);
        Assert.Equal(1, dict.Count);
        Assert.IsType<TestTest>(dict[typeof(ITestTest)].Invoke());
    }
    [Fact]
    public void Register_ServiceInstance_ShouldOk()
    {
        var expected = new TestTest();
        var container = new KndContainer();

        container.RegisterInstance<ITestTest>(expected);

        var fi = typeof(KndContainer).GetField("_regs", BindingFlags.NonPublic | BindingFlags.Instance);
        var dict = (IDictionary<Type, Func<object>>)fi.GetValue(container);
        Assert.Equal(1, dict.Count);
        Assert.IsType<TestTest>(dict[typeof(ITestTest)].Invoke());
    }
    [Fact]
    public void Register_ServiceSIngleton_ShouldOk()
    {
        var expected = new TestTest();
        var container = new KndContainer();

        container.RegisterSingleton<ITestTest>(() => expected);

        var fi = typeof(KndContainer).GetField("_regs", BindingFlags.NonPublic | BindingFlags.Instance);
        var dict = (IDictionary<Type, Func<object>>)fi.GetValue(container);
        Assert.Equal(1, dict.Count);
        Assert.IsType<TestTest>(dict[typeof(ITestTest)].Invoke());
    }
    [Fact]
    public void Resolve_CorrectData_ShouldOk()
    {
        var container = new KndContainer();
        container.Register<ITestTest, TestTest>();

        var service = container.Resolve<ITestTest>();

        Assert.IsType<TestTest>(service);
    }
}

internal interface ITestTest
{
    public string? Message { get; set; }
}
internal class TestTest : ITestTest
{
    public string? Message { get; set; }
}