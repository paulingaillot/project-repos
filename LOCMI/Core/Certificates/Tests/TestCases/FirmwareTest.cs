﻿namespace LOCMI.Core.Certificates.Tests.TestCases;

using LOCMI.Core.Microcontrollers;

public sealed class FirmwareTest : TestCase
{
    public FirmwareTest()
        : base("Firmware test")
    {
    }

    /// <inheritdoc />
    protected override IEnumerable<string> Test(Microcontroller microcontroller)
    {
        throw new NotImplementedException();
    }
}