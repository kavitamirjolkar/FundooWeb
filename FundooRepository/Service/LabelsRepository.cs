using Common.Model;
using FundooRepository.DBContext;
using FundooRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FundooRepository.Service
{
    public class LabelsRepository : ILabelsRepository
    {
        public LabelsRepository(AuthenticationContext context)
        {
            this.Context = context;
        }

        public AuthenticationContext Context { get; }

       

        public string AddLabels([FromBody] LabelModel label)
        {
            var addLabel = new LabelModel()
            {
                UserId = label.UserId,
                Label = label.Label
            };
            try
            {
                this.Context.Labels.Add(addLabel);
                var result = this.Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public string DeleteLabel(int id)
        {
            LabelModel label = Context.Labels.Where(t => t.Id == id).FirstOrDefault();
            try
            {
                this.Context.Labels.Remove(label);
                var result = Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<LabelModel> GetLabels(Guid UserId)
        {
            try
            {
                var list = new List<LabelModel>();
                var labels = from t in this.Context.Labels where t.UserId == UserId select t;
                foreach (var items in labels)
                {
                    list.Add(items);
                }

                return list;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public string UpdateLabels(int id, string newlabel)
        {
            LabelModel labels = Context.Labels.Where(t => t.Id == id).FirstOrDefault();
            labels.Label = newlabel;
            try
            {
                var result = this.Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }        
    }
}
