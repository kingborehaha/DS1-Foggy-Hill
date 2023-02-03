using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SoulsFormats;

namespace DSUtil
{
    public static class Util
    {
        public static void WritePortedSoulsFile(ISoulsFile file, string dataPath, string filePath, DCX.Type dcxType = DCX.Type.None)
        {
            string writePath = GetOutputPath(dataPath, filePath, dcxType != DCX.Type.None);
            file.Write(writePath, dcxType);
        }
        public static string GetVirtualPath(string dataPath, string filePath)
        {
            var fileName = filePath.Split(dataPath)[1];
            var virtualPath = fileName.Split("\\")[..^1];
            return Path.Join(virtualPath);
        }
        public static string GetOutputPath(string dataPath, string filePath, bool isDCX = true)
        {
            string outputDirectory = $"{Directory.GetCurrentDirectory()}\\output\\{GetVirtualPath(dataPath, filePath)}";
            string fileName = Path.GetFileName(filePath);
            string outputPath = $"{outputDirectory}\\{fileName}";
            Directory.CreateDirectory(outputDirectory);
            if (isDCX && !outputPath.EndsWith(".dcx"))
            {
                outputPath += ".dcx";
            }
            return outputPath;
        }
        public static string GetByteArrayString(byte[] field)
        {
            string bytestr = "";
            for (var i = 0; i < field.Length; i++)
            {
                bytestr += field[i];
            }
            bytestr = bytestr[..^1];
            return bytestr + "]";
        }

        public static bool HasModifiedScaling(Vector3 v1)
        {
            return Vector3IsEqual(v1, new Vector3(1.0f, 1.0f, 1.0f));
        }

        public static bool Vector3IsEqual(Vector3 v1, Vector3 v2)
        {
            if (Vector3.Distance(v1, v2) > 0.001f)
            {
                return true;
            }
            return false;
        }

        public static bool FloatIsEqual(float f1, float f2)
        {
            if (Math.Abs(f1 - f2) < 0.001f)
            {
                return true;
            }
            return false;
        }

        public static ConcurrentBag<PARAMDEF> LoadParamDefXmls(string gameType)
        {
            ConcurrentBag<PARAMDEF> paramdefs_ptde = new();
            foreach (string path in Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Paramdex\\{gameType}\\Defs", "*.xml", SearchOption.AllDirectories))
            {
                var paramdef = PARAMDEF.XmlDeserialize(path);
                paramdefs_ptde.Add(paramdef);
            }
            return paramdefs_ptde;
        }

        /// <summary>
        /// Apply param defs for list of BinderFiles
        /// </summary>
        public static void ApplyParamDefs(ConcurrentBag<PARAMDEF> paramdefs, List<BinderFile> fileList, ConcurrentDictionary<string, PARAM> paramList)
        {
            ConcurrentBag<string> warningList = new();
            Parallel.ForEach(Partitioner.Create(fileList), file =>
            {
                PARAM? param = null;
                try
                {
                    if (file.Name.Contains("m99") || !file.Name.EndsWith(".param"))
                    {
                        // Not a param
                        return;
                    }

                    string name = Path.GetFileNameWithoutExtension(file.Name);
                    param = PARAM.Read(file.Bytes);
                    param = Util.ApplyDefWithWarnings(param, paramdefs);
                    if (param != null)
                        paramList.TryAdd(name, param);
                }
                catch (InvalidDataException)
                {
                }
            });
        }
  
        public static void ApplyRowNames(ConcurrentDictionary<string, string[]> rowNames, ConcurrentDictionary<string, PARAM> paramList)
        {
            Parallel.ForEach(Partitioner.Create(rowNames), file =>
            {
                if (paramList.TryGetValue(file.Key.Replace(".txt", ""), out PARAM param))
                {
                    foreach (string line in file.Value)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] split = line.Split(' ');
                        int id = int.Parse(split[0]);
                        string name = string.Join(' ', split[1..]);

                        PARAM.Row? row = param[id];
                        if (row != null)
                        {
                            row.Name = name;
                        }
                    }
                }
            });
        }

        public static PARAM? ApplyDef(PARAM param, PARAMDEF paramdef)
        {
            try
            {
                param.ApplyParamdef(paramdef);
                return param;
            }
            catch(InvalidDataException e)
            {
                return null;
            }
        }

        public static PARAM? ApplyDefWithWarnings(PARAM param, ConcurrentBag<PARAMDEF> paramdefs)
        {
            bool matchType = false;
            bool matchDefVersion = false;
            int bestDefVersion = -420;
            long bestRowsize = -69;
            long bestDefRowSize = -999;

            foreach (PARAMDEF paramdef in paramdefs)
            {
                if (param.ParamType == paramdef.ParamType)
                {
                    matchType = true;
                    bestDefVersion = paramdef.DataVersion;
                    if (param.ParamdefDataVersion == paramdef.DataVersion)
                    {
                        matchDefVersion = true;
                        bestRowsize = param.DetectedSize;
                        bestDefRowSize = paramdef.GetRowSize();
                        if (param.DetectedSize == -1 || param.DetectedSize == bestDefRowSize)
                        {
                            return ApplyDef(param, paramdef);
                        }
                    }
                }
            }

            // Def could not be applied.
            if (!matchType && !matchDefVersion)
                throw new InvalidDataException($"Could not apply ParamDef for {param.ParamType}. Valid ParamDef could not be found.");
            else if (matchType && !matchDefVersion)
                throw new InvalidDataException($"Could not apply ParamDef for {param.ParamType}. Cannot find ParamDef version {param.ParamdefDataVersion}.");
            else if (matchType && matchDefVersion)
                throw new InvalidDataException($"Could not apply ParamDef for {param.ParamType}. Row sizes do not match. Param: {bestRowsize}, Def: {bestDefRowSize}.");
            else
                throw new Exception("Unhandled Apply ParamDef error.");
        }


        private static void RestoreBackup(string sourcePath, string targetPath)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(targetPath,
                Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            File.Move(sourcePath, targetPath, false);
        }

        public static void RestoreBackups(string installDirectory, string backupExtension)
        {
            string[] files = Directory.GetFiles($"{installDirectory}", $"*{backupExtension}", System.IO.SearchOption.AllDirectories);

            foreach (var file in files)
            {
                RestoreBackup(file, file.Replace(backupExtension, ""));
            }

            System.Media.SystemSounds.Exclamation.Play();

            if (files.Length > 0)
                MessageBox.Show("Backups restored.", "Restore Backups");
            else
                MessageBox.Show("No backups were found!", "Restore Backups");
        }
    }
}
