﻿using System.Dynamic;

namespace KristofferStrube.Blazor.FileSystemAccess;

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-directorypickeroptions">DirectoryPickerOptions browser specs</see>
/// </summary>
public class DirectoryPickerOptionsStartInWellKnownDirectory : BaseDirectoryPickerOptions
{
    public WellKnownDirectory? StartIn { get; set; }

    internal override ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (StartIn != null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}

/// <summary>
/// <see href="https://wicg.github.io/file-system-access/#dictdef-directorypickeroptions">DirectoryPickerOptions browser specs</see>
/// </summary>
public class DirectoryPickerOptionsStartInFileSystemHandle : BaseDirectoryPickerOptions
{
    public FileSystemHandle? StartIn { get; set; }

    internal override ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (StartIn != null)
        {
            res.startIn = StartIn;
        }

        return res;
    }
}

public abstract class BaseDirectoryPickerOptions
{
    public string? Id { get; set; }

    internal virtual ExpandoObject Serializable()
    {
        dynamic res = new ExpandoObject();
        if (Id != null)
        {
            res.id = Id;
        }

        return res;
    }
}
