using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Club.Data.Modelos;
using Club.Negocio.Modelos;

namespace Club.Negocio.Infraestructura
{
    public static class AutoMapperConfig
    {
        private static MapperConfiguration VMToEntity
        {
            get
            {
                return new MapperConfiguration(config =>
                {
                    //Mapea entre un objeto de la capa de negocio y uno de la de datos.
                    config.CreateMap<SocioViewModel, Socio>();
                    config.CreateMap<CuentaViewModel, Cuenta>();
                    config.CreateMap<CuotaViewModel, Cuota>();
                });
            }

        }

        private static MapperConfiguration EntityToVM
        {
            get
            {
                return new MapperConfiguration(config =>
                {
                    config.CreateMap<Socio, SocioViewModel>();
                    config.CreateMap<Cuenta, CuentaViewModel>();
                    config.CreateMap<Cuota, CuotaViewModel>();
                });


            }
        }

        public static MapperConfiguration SocioVMToSocio
        {
            get => VMToEntity;
        }
        public static MapperConfiguration SocioToSocioVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration CuentaVMToCuenta
        {
            get => VMToEntity;
        }

        public static MapperConfiguration CuentaToCuentaVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration CuotaVMToCuota
        {
            get => VMToEntity;
        }

        public static MapperConfiguration CuotaToCuotaVM
        {
            get => EntityToVM;
        }
    }


}
