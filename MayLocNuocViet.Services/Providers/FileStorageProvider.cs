using   Fsoft.SKU.CoreApp.Utilities.Configurations;
using   Fsoft.SKU.CoreApp.Utilities.Constants;
using   Fsoft.SKU.CoreApp.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace  Fsoft.SKU.CoreApp.Services.Providers
{
    public class FileStorageProvider
    {
        #region Variables

        private readonly string _defaultDocumentFolder = AppSettings.DefaultDocumentFolder;
        private readonly string _defaultAvatarFolder = AppSettings.DefaultAvatarFolder;
        private readonly string _folderUpload = AppSettings.DefaultFolderUpload;

        #endregion

        #region Methods

        public FolderInfoModel CreateFolder(FolderInfoModel folder)
        {
            GetOriginalPath(folder);
            var path = GetFullPath(folder.Path);
            CreateFolderIfNotExist(path);

            return folder;
        }

        private string GetDefaultPath()
        {
            return GetDefaultPath(_folderUpload);
        }

        private static string GetDefaultPath(string folderUpload)
        {
            var rootpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var path = Path.Combine(rootpath, folderUpload);
            CreateFolderIfNotExist(path);
            return path;
        }

        private static void CreateFolderIfNotExist(string fullPath)
        {
            if (!string.IsNullOrWhiteSpace(fullPath))
            {
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }
        }

        public IEnumerable<FolderInfoModel> GetSubFolders(FolderInfoModel folder)
        {
            if (folder != null)
            {
                var dirInfo = GetFolderInfo(folder);
                CreateFolderIfNotExist(dirInfo.FullName);
                var path = folder.Path.TrimStart('/') + "/";
                var subFolders = dirInfo.GetDirectories();
                return subFolders.Select(x => new FolderInfoModel
                {
                    FolderName = x.Name,
                    Path = path + x.Name,
                    CreatedDate = x.CreationTimeUtc,
                    DocumentType = folder.DocumentType,
                    DocumentId = folder.DocumentId
                });
            }
            return null;
        }

        public IEnumerable<FileInfoModel> GetFiles(FolderInfoModel folder)
        {
            if (folder != null)
            {
                var dirInfo = GetFolderInfo(folder);
                var path = folder.Path.TrimStart('/') + "/";
                var subFolders = dirInfo.GetFiles();
                return subFolders.Select(x => new FileInfoModel
                {
                    FileName = x.Name,
                    FullName = Path.Combine(AppSettings.DefaultFolderUpload, folder.Path, x.Name),
                    Size = x.Length,
                    Path = path + x.Name,
                    CreatedDate = x.LastWriteTimeUtc != new DateTime() ? x.LastWriteTimeUtc : x.CreationTimeUtc,
                    UpdatedDate = x.LastWriteTimeUtc,
                    DocumentType = folder.DocumentType,
                    DocumentId = folder.DocumentId
                });
            }
            return null;
        }

        public FileInfo GetFileInfo(string path)
        {
            try
            {
                var filePath = GetFullPath(path);
                var fi = new FileInfo(filePath);
                return fi;
            }
            catch
            {
                return null;
            }
        }

        public FileInfo GetFileInfo(FileInfoModel file)
        {
            if (file != null)
            {
                GetOriginalPath(file);
                var fileInfo = GetFileInfo(file.Path);
                if (fileInfo != null)
                {
                    if (string.IsNullOrWhiteSpace(file.FileName))
                    {
                        file.FileName = fileInfo.Name;
                    }
                    return fileInfo;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public FileInfoModel RenameFile(FileInfoModel file, string newFileName)
        {
            try
            {
                var fi = GetFileInfo(file);
                if (fi != null)
                {
                    var newFullPath = GetFullPath(GetOriginalPath(newFileName, file.DocumentType, file.DocumentId));
                    if (string.Equals(fi.FullName, newFullPath, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var newTempFullPath =
                            GetFullPath(GetOriginalPath(GetTempName(fi.Name), file.DocumentType, file.DocumentId));
                        fi.MoveTo(newTempFullPath);
                    }
                    fi.CreationTimeUtc = DateTime.UtcNow;
                    fi.MoveTo(newFullPath);
                    file.FileName = fi.Name;
                    file.CreatedDate = fi.CreationTimeUtc;
                    file.UpdatedDate = fi.LastAccessTimeUtc;
                }
            }
            catch
            {
            }
            return file;
        }

        public DirectoryInfo GetFolderInfo(string path)
        {
            try
            {
                var folderPath = GetFullPath(path);
                var dirInfo = new DirectoryInfo(folderPath);
                return dirInfo;
            }
            catch
            {
                return null;
            }
        }

        public DirectoryInfo GetFolderInfo(FolderInfoModel folder)
        {
            if (folder != null)
            {
                GetOriginalPath(folder);
                var folderInfo = GetFolderInfo(folder.Path);
                if (string.IsNullOrWhiteSpace(folder.FolderName))
                {
                    folder.FolderName = folderInfo.Name;
                }
                return folderInfo;
            }
            return null;
        }

        public FolderInfoModel RenameFolder(FolderInfoModel folder, string newFolderName)
        {
            var dir = GetFolderInfo(folder);
            var newFullPath = GetFullPath(GetOriginalPath(newFolderName, folder.DocumentType, folder.DocumentId));
            try
            {
                if (string.Equals(dir.FullName, newFullPath, StringComparison.CurrentCultureIgnoreCase))
                {
                    var newTempFullPath =
                        GetFullPath(GetOriginalPath(GetTempName(dir.Name), folder.DocumentType, folder.DocumentId));
                    dir.MoveTo(newTempFullPath);
                }
                dir.CreationTimeUtc = DateTime.UtcNow;
                dir.MoveTo(newFullPath);

                folder.FolderName = dir.Name;
                folder.CreatedDate = dir.CreationTime;
            }
            catch (Exception ex)
            {
                folder = null;
                throw ex;
            }

            return folder;
        }

        public FileInfoModel MoveFile(FileInfoModel file, FolderInfoModel destinationFolder)
        {
            var newFile = new FileInfoModel();
            try
            {
                var fileInfo = GetFileInfo(file);
                var folderInfo = GetFolderInfo(destinationFolder);
                if (destinationFolder.DocumentType != file.DocumentType && !folderInfo.Exists)
                {
                    folderInfo.Create();
                    folderInfo.Refresh();
                }
                if (fileInfo != null && folderInfo != null && fileInfo.Exists && folderInfo.Exists)
                {
                    var fileName = ProcessFileNameInFolder(folderInfo, fileInfo.Name);
                    file.FileName = fileName;
                    fileInfo.CreationTimeUtc = DateTime.UtcNow;
                    fileInfo.MoveTo(Path.Combine(folderInfo.FullName, fileName));
                    newFile = new FileInfoModel
                    {
                        FileName = fileInfo.Name,
                        Path = fileInfo.FullName,
                        DocumentType = destinationFolder.DocumentType,
                        DocumentId = destinationFolder.DocumentId,
                        Size = fileInfo.Length,
                        Extension = fileInfo.Extension,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    };
                }
            }
            catch
            {
            }
            return newFile;
        }

        public FolderInfoModel MoveFolder(FolderInfoModel sourceFolder, FolderInfoModel destinationFolder)
        {
            DirectoryInfo newFolderInfo = null;
            try
            {
                var sourceFolderInfo = GetFolderInfo(sourceFolder);
                var destinationfolderInfo = GetFolderInfo(destinationFolder);
                if (destinationFolder.DocumentType != sourceFolder.DocumentType && !destinationfolderInfo.Exists)
                {
                    destinationfolderInfo.Create();
                    destinationfolderInfo.Refresh();
                }
                if (sourceFolderInfo != null && destinationfolderInfo != null && sourceFolderInfo.Exists &&
                    destinationfolderInfo.Exists)
                {
                    var newFolderPath = Path.Combine(destinationfolderInfo.FullName, sourceFolderInfo.Name);
                    CreateFolderIfNotExist(newFolderPath);
                    newFolderInfo = GetFolderInfo(newFolderPath);
                    var arrDir = sourceFolderInfo.GetDirectories();
                    foreach (var dir in arrDir)
                    {
                        //using loop to copy files in all sub-folder
                        MoveFolder(new FolderInfoModel { Path = dir.FullName },
                            new FolderInfoModel { Path = newFolderInfo.FullName });
                    }

                    var lstFileCopy = sourceFolderInfo.GetFiles();
                    foreach (var fileInfo in lstFileCopy)
                    {
                        var fileName = ProcessFileNameInFolder(newFolderInfo, fileInfo.Name);
                        fileInfo.MoveTo(Path.Combine(newFolderInfo.FullName, fileName));
                    }
                    sourceFolderInfo.Delete();
                }
            }
            catch (Exception ex)
            {
                if (newFolderInfo != null && newFolderInfo.Exists)
                {
                    newFolderInfo.Delete();
                }
                throw ex;
            }
            return sourceFolder;
        }

        public FileInfoModel CopyFile(FileInfoModel file, FolderInfoModel destinationFolder)
        {
            var newFile = new FileInfoModel();
            try
            {
                var fileInfo = GetFileInfo(file);
                var folderInfo = GetFolderInfo(destinationFolder);
                if (destinationFolder.DocumentType != file.DocumentType && !folderInfo.Exists)
                {
                    folderInfo.Create();
                    folderInfo.Refresh();
                }
                if (fileInfo != null && folderInfo != null && fileInfo.Exists && folderInfo.Exists)
                {
                    var fileName = ProcessFileNameInFolder(folderInfo, fileInfo.Name);
                    file.FileName = fileName;
                    var copyFile = fileInfo.CopyTo(Path.Combine(folderInfo.FullName, fileName));
                    newFile = new FileInfoModel
                    {
                        FileName = copyFile.Name,
                        Path = copyFile.FullName,
                        DocumentType = destinationFolder.DocumentType,
                        DocumentId = destinationFolder.DocumentId,
                        Size = fileInfo.Length,
                        Extension = fileInfo.Extension,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    };
                }
            }
            catch
            {
            }
            return newFile;
        }

        public FolderInfoModel CopyFolder(FolderInfoModel sourceFolder, FolderInfoModel destinationFolder)
        {
            DirectoryInfo newFolderInfo = null;
            try
            {
                var sourceFolderInfo = GetFolderInfo(sourceFolder);
                var destinationfolderInfo = GetFolderInfo(destinationFolder);
                if (destinationFolder.DocumentType != sourceFolder.DocumentType && !destinationfolderInfo.Exists)
                {
                    destinationfolderInfo.Create();
                    destinationfolderInfo.Refresh();
                }
                if (sourceFolderInfo != null && destinationfolderInfo != null && sourceFolderInfo.Exists &&
                    destinationfolderInfo.Exists)
                {
                    var newFolderPath = Path.Combine(destinationfolderInfo.FullName, sourceFolderInfo.Name);
                    CreateFolderIfNotExist(newFolderPath);
                    newFolderInfo = GetFolderInfo(newFolderPath);

                    var arrDir = sourceFolderInfo.GetDirectories();
                    foreach (var dir in arrDir)
                    {
                        //using loop to copy files in all sub-folder
                        CopyFolder(new FolderInfoModel { Path = dir.FullName },
                            new FolderInfoModel { Path = newFolderInfo.FullName });
                    }

                    var lstFileCopy = sourceFolderInfo.GetFiles();
                    foreach (var fileInfo in lstFileCopy)
                    {
                        var fileName = ProcessFileNameInFolder(newFolderInfo, fileInfo.Name);
                        fileInfo.CopyTo(Path.Combine(newFolderInfo.FullName, fileName));
                    }
                }
            }
            catch (Exception ex)
            {
                if (newFolderInfo != null && newFolderInfo.Exists)
                {
                    newFolderInfo.Delete();
                }
                throw ex;
            }
            return sourceFolder;
        }

        public bool DeleteFolder(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    var dirInfo = GetFolderInfo(path);
                    var arrDir = dirInfo.GetDirectories();
                    var arrFile = dirInfo.GetFiles();
                    foreach (var dir in arrDir)
                    {
                        //using loop to delete files in all sub-folder
                        DeleteFolder(dir.FullName);
                    }
                    foreach (var file in arrFile)
                    {
                        file.Delete();
                    }
                    dirInfo.Delete();
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public IList<FolderInfoModel> GetAllFolders(string rootName,
            CommonConstants.DocumentType documentType = CommonConstants.DocumentType.Product, string documentId = null)
        {
            var result = new List<FolderInfoModel>();
            var rootPath = GetOriginalPath(rootName, documentType, documentId);
            var rootFolderInfo = GetFolderInfo(rootPath);
            var fullRootPath = GetDefaultPath();
            var folders = rootFolderInfo.GetDirectories();
            foreach (var folder in folders)
            {
                result.Add(new FolderInfoModel
                {
                    FolderName = folder.Name,
                    Path = folder.FullName.Replace(fullRootPath, ""),
                    DocumentType = documentType,
                    DocumentId = documentId,
                    CreatedDate = folder.CreationTimeUtc,
                    UpdatedDate = folder.LastAccessTimeUtc
                });
                result.AddRange(GetAllFolders(folder.FullName, documentType, documentId));
            }

            return result;
        }

        public IList<FileInfoModel> GetAllFiles(string rootName,
            CommonConstants.DocumentType documentType = CommonConstants.DocumentType.Product, string documentId = null)
        {
            var result = new List<FileInfoModel>();
            var rootPath = GetOriginalPath(rootName, documentType, documentId);
            var rootFolderInfo = GetFolderInfo(rootPath);
            var fullRootPath = GetDefaultPath();
            var folders = rootFolderInfo.GetDirectories();
            var files = rootFolderInfo.GetFiles();
            foreach (var folder in folders)
            {
                result.AddRange(GetAllFiles(folder.FullName, documentType, documentId));
            }
            foreach (var file in files)
            {
                result.Add(new FileInfoModel
                {
                    FileName = file.Name,
                    Path = file.FullName.Replace(fullRootPath, ""),
                    DocumentType = documentType,
                    DocumentId = documentId,
                    Size = file.Length,
                    Extension = file.Extension,
                    CreatedDate = file.CreationTimeUtc,
                    UpdatedDate = file.LastAccessTimeUtc
                });
            }
            return result;
        }

        public bool DeleteFolder(FolderInfoModel folder)
        {
            if (folder != null)
            {
                GetOriginalPath(folder);
                return DeleteFolder(folder.Path);
            }
            return false;
        }

        private string ProcessFileNameInFolder(DirectoryInfo folderInfo, string fileName)
        {
            if (folderInfo != null && folderInfo.Exists)
            {
                var arrFile = folderInfo.GetFiles(fileName);
                if (arrFile.Length > 0)
                {
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    var fileExt = Path.GetExtension(fileName);
                    var arrFileWithoutExt = folderInfo.GetFiles(fileNameWithoutExt + "*" + fileExt);
                    //begin from number 1 if file name existed
                    var suffixForFileName = 1;
                    fileName = StringUtil.MakeNewFileName(fileNameWithoutExt, suffixForFileName, fileExt);
                    var isExist = arrFileWithoutExt.Any(x => x.Name == fileName);
                    while (isExist)
                    {
                        suffixForFileName++;
                        fileName = StringUtil.MakeNewFileName(fileNameWithoutExt, suffixForFileName, fileExt);
                        isExist = arrFileWithoutExt.Any(x => x.Name == fileName);
                    }
                }
            }

            return fileName;
        }

        public static string GetFullPath(string path)
        {
            var fullPath = Path.Combine(GetDefaultPath(AppSettings.DefaultFolderUpload), FixPathBeforeCombine(path));
            fullPath = fullPath.Replace("\\\\", "\\");
            return fullPath;
        }

        private static string FixPathBeforeCombine(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                path = path.TrimStart('/').Replace("/", "\\");
            }
            return path;
        }


        public void GetOriginalPath(FileInfoModel fileInfo)
        {
            if (fileInfo != null)
            {
                fileInfo.Path = GetOriginalPath(fileInfo.Path, fileInfo.DocumentType, fileInfo.DocumentId);
            }
        }

        public void GetOriginalPath(FolderInfoModel folderInfo)
        {
            if (folderInfo != null)
            {
                folderInfo.Path = GetOriginalPath(folderInfo.Path, folderInfo.DocumentType, folderInfo.DocumentId);
            }
        }

        public static string GetOriginalPath(string path,
            CommonConstants.DocumentType documentType = CommonConstants.DocumentType.Product, string documentId = null)
        {
            var comparePath = FixPathBeforeCombine(path);
            if (comparePath.Contains(AppSettings.DefaultDocumentFolder)||  comparePath.Contains(AppSettings.DefaultAvatarFolder))
            {
                return path;
            }
            var folder = AppSettings.DefaultDocumentFolder;
            if (documentType.Equals(CommonConstants.DocumentType.Avatar))
            {
                folder = AppSettings.DefaultAvatarFolder + "/" + documentId;
            }
            return Path.Combine(FixPathBeforeCombine(folder), FixPathBeforeCombine(path));
        }

        public string ReplaceDefaultPath(string fullPath)
        {
            var defaultPath = GetDefaultPath();
            fullPath = fullPath.Replace(defaultPath, "").TrimStart('\\');
            return fullPath;
        }

        public string ReplaceNameForFullPath(string fullPath, string newName)
        {
            var index = fullPath.LastIndexOf('/');
            if (index >= 0)
            {
                var subStr = fullPath.Substring(0, index + 1);
                fullPath = subStr + newName;
            }
            return fullPath;
        }
        private string GetTempName(string name)
        {
            return $"__temp__{name}";
        }

        public string ProcessAndSaveBase64File(string base64String, CommonConstants.DocumentType documentType, string fileName)
        {
            try
            {
                var path = GetFullPath(GetOriginalPath("/", documentType));
                string converted = base64String.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(converted);
                CreateFolderIfNotExist(path);
                var pathName = Path.Combine(path, string.Format("{0}_{1}", DateTime.UtcNow.ToString("ddMMyyyyHHmmss"), fileName));
                File.WriteAllBytes(pathName, bytes);
                return ReplaceDefaultPath(pathName).Replace("\\", "/");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ProcessAndSaveBase64Img(string base64Img, CommonConstants.DocumentType documentType, string documentId)
        {
            try
            {
                var path = GetFullPath(GetOriginalPath("/", documentType));
                byte[] bytes = Convert.FromBase64String(base64Img);
                using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    CreateFolderIfNotExist(path);
                    var img = Image.FromStream(ms, true);
                    path = Path.Combine(path, documentId + ".png");
                    img.Save(path, ImageFormat.Png);
                }
                return ReplaceDefaultPath(path).Replace("\\", "/");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string ConvertImageToBase64(string srcImage, CommonConstants.DocumentType documentType, string documentId)
        {
            try
            {
                var imgBase64 = "";
                var fullPath = GetFullPath(GetOriginalPath(srcImage, documentType));
                if (File.Exists(fullPath))
                {
                    using (Image img = Image.FromFile(fullPath))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            img.Save(ms, img.RawFormat);
                            byte[] byteArr = ms.ToArray();
                            imgBase64 = Convert.ToBase64String(byteArr);
                        }
                    }
                }
                return imgBase64;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}