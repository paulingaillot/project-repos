﻿namespace LOCMI.Core.Certificates.Tests.TestCases;

using LOCMI.Core.Microcontrollers;
using LOCMI.Core.Microcontrollers.Utils.PortTypes;

/// <summary>
///     Test if the microcontroller has the correct number of ports of each type (Data, Ground and Other)
/// </summary>
/// <remarks>Test 3</remarks>
public sealed class GPIOTest : TestCase
{
    public GPIOTest()
        : base("General purpose input/output specifications")
    {
    }

    public int MaxDataPort { get; init; } = int.MaxValue;

    public int MaxGround { get; init; } = int.MaxValue;

    public int MaxOtherPort { get; init; } = int.MaxValue;

    public int MinDataPort { get; init; }

    public int MinGround { get; init; }

    public int MinOtherPort { get; init; }

    /// <inheritdoc />
    protected override IEnumerable<string> Test(Microcontroller microcontroller)
    {
        if (microcontroller.Ports == null)
        {
            if (MinDataPort != 0)
            {
                yield return $"The microcontroller hasn't ports but it must have at least {MinDataPort} data ports";
            }

            if (MinGround != 0)
            {
                yield return $"The microcontroller hasn't ports but it must have at least {MinGround} ground";
            }

            if (MinOtherPort != 0)
            {
                yield return $"The microcontroller hasn't ports but it must have at least {MinOtherPort} ports other than data ports and ground";
            }
        }
        else
        {
            int nbDataPorts = microcontroller.Ports.OfType<DataPort>().Count();
            int nbGround = microcontroller.Ports.OfType<GroundPort>().Count();
            int nbOtherPorts = microcontroller.Ports.Count - nbDataPorts - nbGround;

            string? failureCause = TestNbDataPorts(nbDataPorts);

            if (failureCause != null)
            {
                yield return failureCause;
            }

            failureCause = TestNbGround(nbGround);

            if (failureCause != null)
            {
                yield return failureCause;
            }

            failureCause = TestNbOtherPorts(nbOtherPorts);

            if (failureCause != null)
            {
                yield return failureCause;
            }
        }
    }

    private string? TestNbDataPorts(int nbDataPorts)
    {
        return nbDataPorts < MinDataPort
                   ? $"The microcontroller must have at least {MinDataPort} data ports"
                   : nbDataPorts > MaxDataPort
                       ? $"The microcontroller must have at most {MinDataPort} data ports"
                       : null;
    }

    private string? TestNbGround(int nbGround)
    {
        return nbGround < MinGround
                   ? $"The microcontroller must have at least {MinGround} ground"
                   : nbGround > MaxGround
                       ? $"The microcontroller must have at most {MaxGround} ground"
                       : null;
    }

    private string? TestNbOtherPorts(int nbOtherPorts)
    {
        return nbOtherPorts < MinOtherPort
                   ? $"The microcontroller must have at least {MinOtherPort} ports other than data ports and ground"
                   : nbOtherPorts > MaxOtherPort
                       ? $"The microcontroller must have at most {MaxOtherPort} ports other than data ports and ground"
                       : null;
    }
}