/*
Licensed under the terms of the MIT License (MIT):

Copyright (c) 2015 Dan Stevens <dan.stevens@doomy.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using KeePass.UI;
using System;
using System.Collections.Generic;
using System.Text;
using KeePassLib;
using KeePass.Plugins;
using KeePass.Resources;

namespace AutoTypeEnabledColumnPlugin
{
    public class AutoTypeEnabledColumnProvider : ColumnProvider
    {

        public AutoTypeEnabledColumnProvider(IPluginHost host)
        {
            if (host == null)
                throw new ArgumentNullException("host");
            _host = host;
        }

        public override string[] ColumnNames
        {
            get
            {
                return s_ColumnNames;
            }
        }

        public override string GetCellData(string strColumnName, PwEntry pe)
        {
            if (strColumnName == Properties.Resources.AutoTypeEnabled) {
                return pe.AutoType.Enabled ? KPRes.Yes : KPRes.No;
            } else {
                return string.Empty;
            }
        }

        public override bool SupportsCellAction(string strColumnName)
        {
            if (strColumnName == Properties.Resources.AutoTypeEnabled)
                return true;
            else
                return base.SupportsCellAction(strColumnName);
        }

        public override void PerformCellAction(string strColumnName, PwEntry pe)
        {
            if (strColumnName == Properties.Resources.AutoTypeEnabled) {
                pe.AutoType.Enabled = !pe.AutoType.Enabled;
                _host.MainWindow.UpdateUI(false, null, false, null, true, null, true);
            } else {
                base.PerformCellAction(strColumnName, pe);
            }
        }

        internal void Terminate()
        {
            _host = null;
        }

        private static readonly string[] s_ColumnNames = new string[] {
            Properties.Resources.AutoTypeEnabled
        };

        private IPluginHost _host;
    }
}
