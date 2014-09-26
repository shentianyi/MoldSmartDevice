using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ToolingDataSys.Code
{
    public enum FileDataOperateType
    {
        Insert,
        Update,
        Delete,
        TransPosition
    }
    public interface IFileData
    {
        List<Message> Insert(DataTable dt);
        List<Message> Update(DataTable dt);
        List<Message> Delete(DataTable dt);
    }
}
