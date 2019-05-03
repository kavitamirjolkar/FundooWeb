using Common.Model;
using FundooBusiness.Interfaces;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooBusiness.Services
{
    public class LabelBusiness : ILabelsBusiness
    {
        private readonly ILabelsRepository labelsRepository;
        public LabelBusiness(ILabelsRepository labelsRepository)
        {
            this.labelsRepository = labelsRepository;
        }

        public string AddLabels(LabelModel label)
        {
            var result = this.labelsRepository.AddLabels(label);
            return result;
        }

        public string DeleteLabel(int id)
        {
            return this.labelsRepository.DeleteLabel(id);
        }

        public List<LabelModel> GetLabels(Guid UserId)
        {
            return this.labelsRepository.GetLabels(UserId);
        }

        public string UpdateLabels(int id, string newlabel)
        {
            return this.labelsRepository.UpdateLabels(id, newlabel);
        }
    }
}
