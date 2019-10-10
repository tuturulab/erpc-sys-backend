using System;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace erpc_system_backend.Classes
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        internal interface IPDFService
        {
            Task<byte[]> Create();
        } 


        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }
        protected override IntPtr LoadUnmanagedDll(String unmanagedDllName)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllName);
        }
        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }
}