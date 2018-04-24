using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NativeCustomDialogs
{
    public interface ICallDialog
    {
        Task CallDialog(object viewModel);
    }
}
