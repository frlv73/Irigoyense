using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club.Negocio.Modelos
{
    public partial class SocioViewModel : ModelBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case (nameof(Nombre)):
                        errors = GetErrorsFromAnnotations(nameof(Nombre), Nombre);
                        break;
                    case (nameof(Direccion)):
                        errors = GetErrorsFromAnnotations(nameof(Direccion), Direccion);
                        break;
                    case (nameof(Localidad)):
                        errors = GetErrorsFromAnnotations(nameof(Localidad), Localidad);
                        break;
                    case (nameof(Estado)):
                        errors = GetErrorsFromAnnotations(nameof(Estado), Estado);
                        break;

                }
                if (errors != null && errors.Length != 0)
                {
                    ClearErrors(columnName);
                    AddErrors(columnName, errors);
                    hasError = true;
                }
                if (!hasError) ClearErrors(columnName);
                return string.Empty;
            }
        }
        public string Error { get; }
    }
}
