﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ToolingDataSys.Code
{
    public interface IMoldFile:IFileData
    {
        List<Message> TransPosition(DataTable dt);
    }
}
