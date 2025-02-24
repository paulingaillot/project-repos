﻿namespace LOCMI.Core.Certificates.Tests;

using LOCMI.Core.Microcontrollers;

public abstract class TestCase : ITest
{
    protected TestCase(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Run(ITestResult testResult, Microcontroller mc)
    {
        IEnumerable<string> failureCauses = Test(mc).ToList();

        if (failureCauses.Any())
        {
            testResult.AddFailure(this, failureCauses);
        }
        else
        {
            testResult.AddSuccess(this);
        }
    }

    protected abstract IEnumerable<string> Test(Microcontroller microcontroller);
}