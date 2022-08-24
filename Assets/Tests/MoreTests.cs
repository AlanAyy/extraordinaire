using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MoreTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Test1()
    {
        int x = 1;

        // Use the Assert class to test conditions
        Assert.IsTrue(x == 1);
    }

    [Test]
    public void Test2()
    {
        int x = 1;
        int y = x;

        Assert.IsTrue(y == x);
    }
}
