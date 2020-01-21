using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class NodeGenerics<T>
    {
            public NodeGenerics<T> Next;
            public T Data;
            public NodeGenerics(T Data)
            {
                this.Data = Data;
            }
        
    }

}

