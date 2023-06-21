using Crosstales.FB;
using System;

public static class NativeFileBrowser 
{
    public static void GetFilePathsToOpen(string[] extensions, Action<string[]> onSuccess, Action<Exception> onError) {
        string[] extensionArray = PreprocessExtensions(extensions);

        try {
            FileBrowser.OpenFilesAsync(onSuccess, FileBrowser.canOpenMultipleFiles, extensionArray);
        } catch(Exception ex) {
            onError(ex);
        }
    }

    public static void GetFilePathToOpenNonAsync(string[] extensions, Action<string> onSuccess, Action<Exception> onError) {
        string[] extensionArray = PreprocessExtensions(extensions);

        try {
            string[] paths = FileBrowser.OpenFiles("Select 3d Model", "*", extensionArray);
            onSuccess(paths[0]);

        } catch(Exception ex) {
            onError(ex);
        }
    }

    public static void GetFilePathToOpen(string[] extensions, Action<string> onSuccess, Action<Exception> onError) {
        string[] extensionArray = PreprocessExtensions(extensions);

        try {
            FileBrowser.OpenFilesAsync((files) => {
                if(null != files && files.Length > 0)
                    onSuccess(files[0]);
                else
                    onSuccess("");
            }, false, extensionArray);
        } catch(Exception ex) {
            onError(ex);
        }
    }

    public static void GetFilePathToSave(string extension, string fileName, Action<string> onSuccess, Action<Exception> onError) {
        string extensionStr = extension ?? "*";

        try {
            FileBrowser.SaveFileAsync(onSuccess, fileName, extensionStr);
        } catch(Exception ex) {
            onError(ex);
        }
    }

    public static void GetFolderPathsToOpen(Action<string[]> onSuccess, Action<Exception> onError) {
        try {
            FileBrowser.OpenFoldersAsync(onSuccess, FileBrowser.canOpenMultipleFolders);
        } catch(Exception ex) {
            onError(ex);
        }
    }

    public static void GetFolderPathToOpen(Action<string> onSuccess, Action<Exception> onError) {
        try {
            FileBrowser.OpenFoldersAsync((folders) => {
                if(null != folders && folders.Length > 0)
                    onSuccess(folders[0]);
                else
                    onSuccess("");
            }, false);
        } catch(Exception ex) {
            onError(ex);
        }
    }

    private static string[] PreprocessExtensions(string[] extensions) {
        return extensions ?? (new string[] { "*" });
    }
}
