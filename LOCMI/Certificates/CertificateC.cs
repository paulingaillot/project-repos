﻿namespace LOCMI.Certificates;

using LOCMI.Core.Certificates;
using LOCMI.Core.Certificates.Tests;
using LOCMI.Core.Certificates.Tests.TestCases;
using LOCMI.Core.Microcontrollers;

public sealed class CertificateC : Certificate
{
    /// <inheritdoc />
    public CertificateC(Microcontroller microcontroller)
        : base("CertificateC", microcontroller)
    {
        Test = new TestSuite
        {
            new ElectronicVersatilityTest
            {
                3.3,
                5,
            },
            new GPIOTest
            {
                MaxDataPort = 7,
                MinDataPort = 6,
                MaxGround = 2,
                MinGround = 2,
                MaxOtherPort = 3,
                MinOtherPort = 3,
            },
            new ProgrammingLanguageTest { new ("C++", "17") },
            new HasHardDiskTest(),
            new IsMaintainableTest(),
        };
    }
}