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
    public class ContractSaleApp
    {
        private IRepository<Sale> _rep;

        public ContractSaleApp(IRepository<Sale> rep)
        {
            _rep = rep;
        }

        public virtual List<Sale> GetAll(string nome)
        {
            return _rep.GetAll(nome).ToList();
        }

        public virtual SaleViewModel GetById(int id)
        {
            try
            {

                var entity = _rep.Get(id);

                SaleViewModel Sale = new SaleViewModel
                {
                    Id = entity.Id,
                    PurchaseDate = entity.PurchaseDate,
                    EnableSale = entity.EnableSale,
                    CreadiarioId = entity.CreadiarioId.Value, 
                    Value = entity.Value
                };

                return Sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual Sale SaveSale(SaleViewModel modelView)
        {
            try
            {

                Sale entity = new Sale
                {
                    PurchaseDate = modelView.PurchaseDate,
                    Value = modelView.Value,
                    CreadiarioId = modelView.CreadiarioId,
                    EnableSale = modelView.EnableSale

                };
                _rep.Insert(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex.ToString());
            }

        }


        public virtual Sale EditSale(SaleViewModel view)
        {
            try
            {

                Sale sale = _rep.Get(view.Id.Value);

                if (sale != null)
                {
                    sale.PurchaseDate = view.PurchaseDate;
                    sale.CreadiarioId = view.CreadiarioId;
                    sale.EnableSale = view.EnableSale;
                    _rep.Update(sale);
                }

                return sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DisableSale(int id)
        {
            Sale sale = _rep.Get(id);
            if (sale != null)
            {
                sale.EnableSale = false;

                _rep.Update(sale);
            }
        }
    }
}
