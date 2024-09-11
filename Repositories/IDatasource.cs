using System.Collections.Generic;

namespace Repositories;

public interface IDatasource
{
    List<T> GetList<T>() where T : IItem;

    List<T> GetDoneList<T>() where T : IExternalItem;

    void MakeBackup(string path);
}
