using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using SoulsFormats;
using DSUtil;

namespace FogMod
{
    public partial class MainForm : Form
    {
        public static readonly string Version = Application.ProductVersion;
        public static readonly string ProgramTitle = $"DS1 Foggy Hill v{Version}";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckEnableActivateButton();
            this.Text = ProgramTitle;
        }

        private void CheckEnableActivateButton()
        {
            if (FileDialog_Browse.FileName != "")
            {
                Button_Install.Enabled = true;
                Button_RestoreBackups.Enabled = true;
            }
            else
            {
                Button_Install.Enabled = false;
                Button_RestoreBackups.Enabled = false;
            }
            return;
        }

        private void ModifyParams(string datapath)
        {
            var paths = Directory.GetFiles(datapath, "*.parambnd").ToList();
            paths.AddRange(Directory.GetFiles(datapath, "*parambnd.dcx").ToList());

            float lockOnDist = (float)Value_LockOnDist.Value;
            short fogEndDist = (short)Value_FogEndDist.Value;
            var fogBrightness = Value_FogBrightness.Value;

            foreach (string bndPath in paths)
            {
                ConcurrentDictionary<string, PARAM> paramList = new();

                // Load param
                BND3 bnd = BND3.Read(bndPath);
                Util.ApplyParamDefs(_paramDefs, bnd.Files, paramList);

                Parallel.ForEach(Partitioner.Create(paramList), item =>
                {
                    PARAM param = paramList[item.Key];

                    if (param.ParamType == "FOG_BANK")
                    {
                        foreach (var row in param.Rows)
                        {
                            row["degRotW"].Value = (short)100; // Fog thickness

                            row["fogBeginZ"].Value = (short)0;
                            row["fogEndZ"].Value = fogEndDist;

                            row["colR"].Value = (short)(255 * (fogBrightness / 100));
                            row["colG"].Value = (short)(255 * (fogBrightness / 100));
                            row["colB"].Value = (short)(255 * (fogBrightness / 100));

                            row["colA"].Value = (short)150;
                            /*
                            // v1
                            row["degRotW"].Value = (short)100; // Fog thickness

                            row["fogBeginZ"].Value = (short)0;
                            row["fogEndZ"].Value = fogEndDist;

                            row["colR"].Value = (short)255;
                            row["colG"].Value = (short)255;
                            row["colB"].Value = (short)255;

                            row["colA"].Value = (short)150;
                            */
                        }
                    }
                    else if (param.ParamType == "LIGHT_SCATTERING_BANK")
                    {
                        // Default row data with modifications
                        for (var i = 0; i < param.Rows.Count; i++)
                        {
                            PARAM.Row row = param.Rows[i];
                            PARAM.Row newRow = new(row.ID, row.Name, param.AppliedParamdef);
                            newRow["distanceMul"].Value = (short)0;
                            newRow["sunR"].Value = (short)0;
                            newRow["sunG"].Value = (short)0;
                            newRow["sunB"].Value = (short)0;
                            newRow["sunA"].Value = (short)0;
                            param.Rows[i] = newRow;
                        }
                    }
                    else if (param.ParamType == "LOCK_CAM_PARAM_ST")
                    {
                        for (var i = 0; i < param.Rows.Count; i++)
                        {
                            PARAM.Row row = param.Rows[i];
                            row["chrLockRangeMaxRadius"].Value = lockOnDist;
                        }
                    }
                    else if (param.ParamType == "NPC_PARAM_ST")
                    {
                        for (var i = 0; i < param.Rows.Count; i++)
                        {
                            PARAM.Row row = param.Rows[i];
                            row["lockDist"].Value = (byte)0;
                        }
                    }
                    else
                    {
                        // Default row data for everything else
                        for (var i = 0; i < param.Rows.Count; i++)
                        {
                            PARAM.Row row = param.Rows[i];
                            param.Rows[i] = new PARAM.Row(row.ID, row.Name, param.AppliedParamdef);
                        }
                    }
                    /*
                    if (param.ParamType == "LIGHT_SCATTERING_BANK")
                    {
                        for (var i = 0; i < param.Rows.Count; i++)
                        {
                            PARAM.Row row = param.Rows[i];
                            foreach (var cell in param.Rows[i].Cells)
                            {
                                if (cell.Def.DisplayType != PARAMDEF.DefType.dummy8)
                                    cell.Value = cell.Def.Maximum;
                            }
                        }
                    }
                    */
                });

                // Save each param, then the parambnd
                foreach (BinderFile file in bnd.Files)
                {
                    string name = Path.GetFileNameWithoutExtension(file.Name);
                    if (paramList.ContainsKey(name))
                        file.Bytes = paramList[name].Write();
                }

                Create_Backup(bndPath);
                bnd.Write(bndPath);
            }
            return;
        }

        private ConcurrentBag<PARAMDEF> _paramDefs;

        private string _backupExtension = ".fogbak";
        private string _installDirectory = "";

        private void RunProgram()
        {
            Button_Install.Enabled = false;
            Button_RestoreBackups.Enabled = false;

            _paramDefs = Util.LoadParamDefXmls("DS1");
            ModifyParams($@"{_installDirectory}\param\DrawParam");
            ModifyParams($@"{_installDirectory}\param\GameParam");

            Button_Install.Enabled = true;
            Button_RestoreBackups.Enabled = true;

            GC.Collect();

            System.Media.SystemSounds.Exclamation.Play();

            var result = MessageBox.Show("All done!", "Finished", MessageBoxButtons.OK);
        }

        private void Create_Backup(string path)
        {
            if (File.Exists(path + _backupExtension) == false)
                File.Copy(path, path + _backupExtension, false);
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            FileDialog_Browse.ShowDialog();
            _installDirectory = Path.GetDirectoryName(FileDialog_Browse.FileName);
            CheckEnableActivateButton();
        }

        private void Button_Install_Click(object sender, EventArgs e)
        {
            RunProgram();
        }
    }
}