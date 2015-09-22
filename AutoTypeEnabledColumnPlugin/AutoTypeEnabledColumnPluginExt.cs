/*
Licensed under the terms of the MIT License (MIT)

Copyright (c) 2015 Dan Stevens

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

using KeePass.Plugins;
using KeePass.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTypeEnabledColumnPlugin
{
    public class AutoTypeEnabledColumnPluginExt : Plugin
    {

        public override bool Initialize(IPluginHost host)
        {
            base.Initialize(host);
            _host = host;
            _columnProvider = new AutoTypeEnabledColumnProvider(_host);
            _host.ColumnProviderPool.Add(_columnProvider);
            return true;
        }

        public override void Terminate()
        {
            _host.ColumnProviderPool.Remove(_columnProvider);
            _columnProvider.Terminate();
            _host = null;
            base.Terminate();
        }

        private IPluginHost _host;
        private AutoTypeEnabledColumnProvider _columnProvider;
    }
}
