using System;
using System.Data;
using System.Text;

namespace JSONer
{
    public interface IConvertableToJSON
    {
        StringBuilder ConvertValuesInDataTableToJSON(DataTable dt, bool lcasepropnames, bool proptynamesinquotes);     
    }
}
