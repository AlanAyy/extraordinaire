using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SomeTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Test1()
    {
        // Use the Assert class to test conditions
        Assert.IsTrue(2 == 1 + 1);
    }

    [Test]
    public void Test2FailsOnPurpose()
    {
        Assert.IsTrue(2 == 1);
    }
}
