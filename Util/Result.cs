using System;

namespace Util
{
    public class Result<T>
    {
        public bool Sucesso { get; set; }
        public string Erro { get; set; }
        public T Dado { get; set; }
    }
}
