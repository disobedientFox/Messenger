using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Messenger.Core
{
	public interface IFileManager
    {
        Task WriteTextToFileAsync(string text, string path, bool append = false);

        string NormalizePath(string path);

        string ResolvePath(string path);
    }
}