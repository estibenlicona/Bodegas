using AutoMapper;
using Bodegas.Domain.DTOs;
using Bodegas.Domain.Entities;

namespace Bodegas.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapperBodega();
            MapperBodegaAliado();
            MapperCaja();
            MapperResolucion();
            MapperSucursal();
            MapperCentroCosto();
            MapperTercero();
        }

        private void MapperTercero()
        {
            CreateMap<Tercero, TerceroDto>()
                .ForMember(x => x.Nit, opt => opt.MapFrom(y => y.Identificacion.Trim())).ReverseMap();
        }

        public void MapperBodega()
        {
            CreateMap<Bodega, BodegaDto>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.SucursalDto, opt => opt.MapFrom(y => y.CodigoSucursal.Trim()))
                .ForMember(x => x.SucursalDto, opt => opt.MapFrom(y => y.Sucursal))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(y => y.Nombre.Trim()))
                .ForMember(x => x.Direccion, opt => opt.MapFrom(y => y.Direccion.Trim()))
                .ForMember(x => x.Telefono, opt => opt.MapFrom(y => y.Telefono.Trim()))
                .ForMember(x => x.CentroCosto, opt => opt.MapFrom(y => y.CodigoCentroCosto.Trim()))
                .ForMember(x => x.Nit, opt => opt.MapFrom(y => y.CodigoTercero.Trim()))
                .ForMember(x => x.CodigoCiudad, opt => opt.MapFrom(y => y.CodigoCiudad.Trim()))
                .ForMember(x => x.ValidaReferencias, opt => opt.MapFrom(y => y.ValidaReferencias))
                .ForMember(x => x.Formato, opt => opt.MapFrom(y => "Aliado"))
                .ForMember(x => x.InformacionAliadoDto, opt => opt.MapFrom(y => y.BodegaAliado ?? new BodegaAliado()))
                .ForMember(x => x.CajaDto, opt => opt.MapFrom(y => y.Caja ?? new Caja()))
                .ForMember(x => x.ResolucionDto, opt => opt.MapFrom(y => y.Resolucion ?? new Resolucion()))
                .ForMember(x => x.NombreSucursal, opt => opt.MapFrom(y => y.Sucursal.Nombre.Trim()));

            CreateMap<BodegaDto, Bodega>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.CodigoSucursal, opt => opt.MapFrom(y => y.CodigoSucursal))
                .ForMember(x => x.Sucursal, opt => opt.MapFrom(y => y.SucursalDto))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(y => y.Nombre.Trim()))
                .ForMember(x => x.Direccion, opt => opt.MapFrom(y => y.Direccion.Trim()))
                .ForMember(x => x.Telefono, opt => opt.MapFrom(y => y.Telefono.Trim()))
                .ForMember(x => x.CodigoCentroCosto, opt => opt.MapFrom(y => y.CentroCosto.Trim()))
                .ForMember(x => x.CodigoTercero, opt => opt.MapFrom(y => y.Nit.Trim()))
                .ForMember(x => x.CodigoCiudad, opt => opt.MapFrom(y => y.CodigoCiudad.Trim()))
                .ForMember(x => x.ValidaReferencias, opt => opt.MapFrom(y => y.ValidaReferencias))
                .ForMember(x => x.Formato, opt => opt.MapFrom(y => "Aliado"))
                .ForMember(x => x.BodegaAliado, opt => opt.MapFrom(y => y.InformacionAliadoDto))
                .ForMember(x => x.Caja, opt => opt.MapFrom(y => y.CajaDto))
                .ForMember(x => x.Resolucion, opt => opt.MapFrom(y => y.ResolucionDto));
        }

        public void MapperBodegaAliado()
        {
            CreateMap<BodegaAliadoDto, BodegaAliado>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.CodigoBodega.Trim()))
                .ForMember(x => x.CodigoCentroCosto, opt => opt.MapFrom(y => y.CodigoBodega.Trim()))
                .ForMember(x => x.e_mail_cnt, opt => opt.MapFrom(y => y.EmailContable.Trim()))
                .ForMember(x => x.por_comision, opt => opt.MapFrom(y => y.PorcentjeComision))
                .ForMember(x => x.sector, opt => opt.MapFrom(y => y.Sector.Trim()))
                .ForMember(x => x.repre_legal, opt => opt.MapFrom(y => y.RepresentanteLegal.Trim()))
                .ForMember(x => x.ini_fact, opt => opt.MapFrom(y => y.InicioFacturacion))
                .ForMember(x => x.d_pagos, opt => opt.MapFrom(y => y.DiasPago))
                .ForMember(x => x.ind_ref, opt => opt.MapFrom(y => y.IndicadorReferidos))
                .ForMember(x => x.activo, opt => opt.MapFrom(y => y.Activo))
                .ForMember(x => x.rec_abo_aga, opt => opt.MapFrom(y => y.RecibeAbonos))
                .ForMember(x => x.f_activacion, opt => opt.MapFrom(y => y.FechaActivacion))
                .ForMember(x => x.f_inactivacion, opt => opt.MapFrom(y => y.FechaInActivacion))
                .ForMember(x => x.t_cupo, opt => opt.MapFrom(y => y.TipoCupo));

            CreateMap<BodegaAliado, BodegaAliadoDto>()
                .ForMember(x => x.CodigoBodega, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.EmailContable, opt => opt.MapFrom(y => y.e_mail_cnt.Trim()))
                .ForMember(x => x.PorcentjeComision, opt => opt.MapFrom(y => y.por_comision))
                .ForMember(x => x.Sector, opt => opt.MapFrom(y => y.sector))
                .ForMember(x => x.RepresentanteLegal, opt => opt.MapFrom(y => y.repre_legal))
                .ForMember(x => x.InicioFacturacion, opt => opt.MapFrom(y => y.ini_fact))
                .ForMember(x => x.DiasPago, opt => opt.MapFrom(y => y.d_pagos))
                .ForMember(x => x.IndicadorReferidos, opt => opt.MapFrom(y => y.ind_ref))
                .ForMember(x => x.Activo, opt => opt.MapFrom(y => y.activo))
                .ForMember(x => x.RecibeAbonos, opt => opt.MapFrom(y => y.rec_abo_aga))
                .ForMember(x => x.FechaActivacion, opt => opt.MapFrom(y => y.f_activacion))
                .ForMember(x => x.FechaInActivacion, opt => opt.MapFrom(y => y.f_inactivacion))
                .ForMember(x => x.TipoCupo, opt => opt.MapFrom(y => y.t_cupo));
        }

        public void MapperCaja()
        {
            CreateMap<Caja, CajaDto>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(y => y.nom_caj.Trim()))
                .ForMember(x => x.Bodega, opt => opt.MapFrom(y => y.cod_bod.Trim()))
                .ForMember(x => x.CentroCosto, opt => opt.MapFrom(y => y.cod_cco.Trim()))
                .ForMember(x => x.Prefijo, opt => opt.MapFrom(y => y.car_con.Trim()));

            CreateMap<CajaDto, Caja>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.nom_caj, opt => opt.MapFrom(y => y.Nombre.Trim()))
                .ForMember(x => x.cod_bod, opt => opt.MapFrom(y => y.Bodega.Trim()))
                .ForMember(x => x.cod_cco, opt => opt.MapFrom(y => y.CentroCosto.Trim()))
                .ForMember(x => x.car_con, opt => opt.MapFrom(y => y.Prefijo.Trim()));
        }

        public void MapperResolucion()
        {
            CreateMap<Resolucion, ResolucionDto>()
                .ForMember(x => x.NumeroResolucion, opt => opt.MapFrom(y => y.resol.Trim()))
                .ForMember(x => x.Caja, opt => opt.MapFrom(y => y.CodigoCaja.Trim()))
                .ForMember(x => x.ResolucionInicial, opt => opt.MapFrom(y => y.res_ini.Trim()))
                .ForMember(x => x.ResolucionFinal, opt => opt.MapFrom(y => y.res_fin.Trim()))
                .ForMember(x => x.Fecha, opt => opt.MapFrom(y => y.fecha))
                .ForMember(x => x.CodigoContable, opt => opt.MapFrom(y => y.cod_con.Trim()))
                .ForMember(x => x.CodigoAplicacion, opt => opt.MapFrom(y => y.cod_apl.Trim()))
                .ForMember(x => x.Prefijo, opt => opt.MapFrom(y => y.car_con.Trim()));

            CreateMap<ResolucionDto, Resolucion>()
                .ForMember(x => x.resol, opt => opt.MapFrom(y => y.NumeroResolucion.Trim()))
                .ForMember(x => x.CodigoCaja, opt => opt.MapFrom(y => y.Caja.Trim()))
                .ForMember(x => x.res_ini, opt => opt.MapFrom(y => y.ResolucionInicial.Trim()))
                .ForMember(x => x.res_fin, opt => opt.MapFrom(y => y.ResolucionFinal.Trim()))
                .ForMember(x => x.fecha, opt => opt.MapFrom(y => y.Fecha))
                .ForMember(x => x.des_con, opt => opt.MapFrom(y => $"CAJA{y.Caja}"))
                .ForMember(x => x.cod_con, opt => opt.MapFrom(y => y.CodigoContable.Trim()))
                .ForMember(x => x.cod_apl, opt => opt.MapFrom(y => y.CodigoAplicacion.Trim()))
                .ForMember(x => x.car_con, opt => opt.MapFrom(y => y.Prefijo.Trim()));
        }

        public void MapperSucursal()
        {
            CreateMap<Sucursal, SucursalDto>().ReverseMap();
        }

        public void MapperCentroCosto()
        {
            CreateMap<CentroCosto, CentroCostoDto>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.Nombre, opt => opt.MapFrom(y => y.nom_cco.Trim()));

            CreateMap<CentroCostoDto, CentroCosto>()
                .ForMember(x => x.Codigo, opt => opt.MapFrom(y => y.Codigo.Trim()))
                .ForMember(x => x.nom_cco, opt => opt.MapFrom(y => y.Nombre.Trim()));
        }
    }
}
