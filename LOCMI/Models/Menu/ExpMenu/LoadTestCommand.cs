﻿namespace LOCMI.Models.Menu.ExpMenu;

using LOCMI.Controllers;
using LOCMI.Core.Certificates.DTO;
using LOCMI.Core.Certificates.Tests;
using LOCMI.Core.Loaders;

public sealed class LoadTestCommand : IExpMenuCommand
{
    private readonly ScannerController _scannerController;

    private CertificateExperimentalDTO _certifier;

    private ILoader<ITest> _loader;

    private ITest _test;

    public LoadTestCommand()
    {
    }

    public LoadTestCommand(CertificateExperimentalDTO certifier, ScannerController scannerController)
    {
        _certifier = certifier;
        _scannerController = scannerController;
    }

    public void Execute()
    {
        string path = _scannerController.Run();
        //TODO
        //_certifier.SetTest();
    }

    public bool IsExecutable()
    {
        throw new NotImplementedException();
    }

    public void LCC(CertificateExperimentalDTO certifier, ScannerController scannerController)
    {
    }
}