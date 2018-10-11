using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TapiskAPP.Services
{
    public interface IStatusBarColorManager
    {
        void SetColor(int a, int r, int g, int b);
    }
}
