using System;
using System.Data;

namespace Tone.Infra.Context
{
    public interface IDB : IDisposable
    {
        IDbConnection Connection();
    }
}