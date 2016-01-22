using Microsoft.Dnx.Compilation.CSharp;

namespace CompileModuleSample
{
    public class OverflowCheckCompilationModule : ICompileModule
    {
        public void BeforeCompile(BeforeCompileContext context)
        {
            var optionsOverflowCheck = context.Compilation.Options.WithOverflowChecks(true);
            context.Compilation = context.Compilation.WithOptions(optionsOverflowCheck);
        }
        
        public void AfterCompile(AfterCompileContext context) { }
    }
}