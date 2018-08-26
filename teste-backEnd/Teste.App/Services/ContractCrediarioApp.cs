using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Teste.App.viewModel;
using Teste.Domain.Entities;
using Teste.Domain.Repositories;

namespace Teste.App.Services
{
    public class ContractCrediarioApp
    {
        private IRepository<Crediario> _rep;
        private ContractSaleApp _appSale;
        private ContractPersonApp _appPerson;

        public ContractCrediarioApp(IRepository<Crediario> rep, ContractSaleApp appSale, ContractPersonApp appPerson)
        {
            _rep = rep;
            _appSale = appSale;
            _appPerson = appPerson;
        }

        public virtual List<CrediarioViewModel> GetAll()
        {
            var sales = _appSale.GetAll(null);

            var crediarios = _rep.GetAll(null);

            var result = (from cre in crediarios
                          join sale in sales on cre.Id equals sale.CreadiarioId
                          select new CrediarioViewModel
                          {
                              Id = cre.Id,
                              PersonId = cre.PersonId,
                              FinalValue = cre.FinalValue,
                              Rate = cre.Rate.Value,
                              Sales = sale == null ? null : new List<Sale>
                              {
                                  new Sale
                                  {
                                      Id = sale.Id,
                                      Value = sale.Value,
                                      PurchaseDate = sale.PurchaseDate,
                                      EnableSale = sale.EnableSale,
                                      CreadiarioId = sale.CreadiarioId
                                  }
                              }
                          }).ToList();

            return result; 
        }

        public virtual CrediarioViewModel GetById(int id)
        {
            try
            {
                var entity = _rep.Get(id);

                CrediarioViewModel Entrevista = new CrediarioViewModel
                {
                    Id = entity.Id,
                    PersonId = entity.PersonId,
                    SchedulingPayment = entity.SchedulingPayment,
                    FinalValue = entity.FinalValue,
                    UserId = entity.UserId,
                    Rate = entity.Rate.Value,
                    Sales = entity.Sales
                };

                return Entrevista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Crediario SaveCrediario(CrediarioViewModel modelView)
        {
            try
            {

                Crediario entity = new Crediario
                {
                    PersonId = modelView.PersonId,
                    UserId = modelView.UserId,
                    FinalValue = modelView.FinalValue,
                    Rate = modelView.Rate,
                    SchedulingPayment = modelView.SchedulingPayment,

                };
                _rep.Insert(entity);

                if (modelView.Sales != null && modelView.Sales.Count() > 0)
                {
                    modelView.Sales.ToList().ForEach(x => _appSale.SaveSale(new SaleViewModel{ Value = x.Value, EnableSale = x.EnableSale, PurchaseDate = x.PurchaseDate, CreadiarioId = modelView.Id.Value }));
                }
                return entity;
            }
            catch
            {
                throw new ValidationException();
            }

        }

        public virtual Crediario EditCrediario(CrediarioViewModel view)
        {
            try
            {

                Crediario crediario = _rep.Get(view.Id.Value);

                if (crediario != null)
                {
                    crediario.PersonId = view.PersonId;
                    crediario.Rate = view.Rate;
                    crediario.Sales = view.Sales;
                    crediario.UserId = view.UserId;
                    crediario.SchedulingPayment = view.SchedulingPayment;

                    _rep.Update(crediario);
                }

                return crediario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCrediario(int id)
        {
            Crediario crediario = _rep.Get(id);
            if (crediario != null)
            {
                _rep.Delete(crediario);
            }
        }
    }
}
