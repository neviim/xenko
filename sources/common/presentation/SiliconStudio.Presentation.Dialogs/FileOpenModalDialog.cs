// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using SiliconStudio.Presentation.Services;

namespace SiliconStudio.Presentation.Dialogs
{
    public class FileOpenModalDialog : ModalDialogBase, IFileOpenModalDialog
    {
        internal FileOpenModalDialog(IDispatcherService dispatcher)
            : base(dispatcher)
        {
            Dialog = new CommonOpenFileDialog { EnsureFileExists = true };
            Filters = new List<FileDialogFilter>();
            FilePaths = new List<string>();
        }

        /// <inheritdoc/>
        public bool AllowMultiSelection { get { return OpenDlg.Multiselect; } set { OpenDlg.Multiselect = value; } }

        /// <inheritdoc/>
        public IList<FileDialogFilter> Filters { get; set; }

        /// <inheritdoc/>
        public IReadOnlyCollection<string> FilePaths { get; private set; }

        /// <inheritdoc/>
        public string InitialDirectory { get { return OpenDlg.InitialDirectory; } set { OpenDlg.InitialDirectory = value != null ? value.Replace('/', '\\') : null; } }

        /// <inheritdoc/>
        public string DefaultFileName { get { return OpenDlg.DefaultFileName; } set { OpenDlg.DefaultFileName = value; } }

        private CommonOpenFileDialog OpenDlg => (CommonOpenFileDialog)Dialog;

        /// <inheritdoc/>
        public override async Task<DialogResult> ShowModal()
        {
            OpenDlg.Filters.Clear();
            foreach (var filter in Filters.Where(x => !string.IsNullOrEmpty(x.ExtensionList)))
            {
                OpenDlg.Filters.Add(new CommonFileDialogFilter(filter.Description, filter.ExtensionList));
            }
            await InvokeDialog();
            FilePaths = Result != DialogResult.Cancel ? new List<string>(OpenDlg.FileNames) : new List<string>();
            return Result;
        }
    }
}