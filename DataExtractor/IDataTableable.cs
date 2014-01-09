using System;

namespace DataExtractor
{
    public interface IDataTableable
    {
        System.Data.DataTable GetData(ProviderSettings ps);
    }
}
