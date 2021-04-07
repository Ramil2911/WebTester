using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.CSharp;
using System.Threading.Tasks;

namespace tester.Data.Services
{
    public class CodePadService
    {

        //TPL
        static CancellationTokenSource _cts = new CancellationTokenSource();

        private TaskFactory _factory = new TaskFactory(
            _cts.Token,
            TaskCreationOptions.PreferFairness,
            TaskContinuationOptions.PreferFairness,
            TaskScheduler.Default);

        public Task ScheduleCompiling(string text, List<KeyValuePair<List<string>, List<string>>> tests, CompilerHandler handler)
        => _factory.StartNew(() => CheckCSharp(text, tests, handler));

        private static void CheckCSharp(string text, List<KeyValuePair<List<string>, List<string>>> tests, CompilerHandler handler)
        {
            //prepare compiler
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true, 
                IncludeDebugInformation = true,
                ReferencedAssemblies = {"System.dll"},
                OutputAssembly = "program.exe"
            };
            
            //compile
            var assembly = provider.CompileAssemblyFromSource(parameters, text);
            if (assembly.Errors.HasErrors)
            {
                handler.ErrorCollection = assembly.Errors;
                handler.Output = assembly.Output.ToString();
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = true,
                FileName = assembly.PathToAssembly,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using Process proc = Process.Start(startInfo);
                proc.Exited += ((_, _) => handler.Finished = true);
                proc.OutputDataReceived += ((_, args) => handler.Output += args.Data);
                proc.ErrorDataReceived += ((_, args) => handler.Output += args.Data);
                proc.WaitForExit();
            }
            catch
            {
                handler.Finished = true;
            }
        }

        public class CompilerHandler
        {
            public CompilerErrorCollection ErrorCollection { get; set; }
            
            private string _output;
            public string Output
            {
                get => _output;
                set { _output = value;
                    OnOutputUpdated?.Invoke(_output);
                }
            }

            public delegate void OutputUpdatedHandler(string output);
            public event OutputUpdatedHandler OnOutputUpdated;
            
            private bool _finished;

            public bool Finished
            {
                get => _finished;
                set
                {
                    _finished = value;
                    OnFinished?.Invoke();
                }
            }

            public delegate void FinishedHandler();
            public event FinishedHandler OnFinished;
        }
    }
}