﻿using Microsoft.JSInterop;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#api-filesystemfilehandle">FileSystemFileHandle browser specs</see>
/// </summary>
public class FileSystemFileHandle : FileSystemHandle
{
    public static new FileSystemFileHandle Create(IJSRuntime jSRuntime, IJSObjectReference jSReference)
    {
        return new FileSystemFileHandle(jSRuntime, jSReference);
    }

    internal FileSystemFileHandle(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference) { }

    public async Task<FileAPI.File> GetFileAsync()
    {
        IJSObjectReference jSFile = await JSReference.InvokeAsync<IJSObjectReference>("getFile");
        return FileAPI.File.Create(jSRuntime, jSFile);
    }

    public async Task<FileSystemWritableFileStream> CreateWritableAsync(FileSystemCreateWritableOptions? fileSystemCreateWritableOptions = null)
    {
        IJSObjectReference jSFileSystemWritableFileStream = await JSReference.InvokeAsync<IJSObjectReference>("createWritable", fileSystemCreateWritableOptions);
        return new FileSystemWritableFileStream(jSRuntime, jSFileSystemWritableFileStream);
    }
}
