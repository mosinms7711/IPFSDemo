using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NethereumWithTraditionalMVVM.Interfaces
{
    public interface IFileEngine
    {
        Task WriteTextAsync(string storedText, string text);
        Task<string> ReadTextAsync(string storedText);
        Task<IEnumerable<string>> GetFilesAsync();
    }
}
